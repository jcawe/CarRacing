using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSensor : MonoBehaviour
{
    public float SensorSize;
    public float SensorsLength;
    public float SensorAngle;
    public Vector3 FrontLeftSensorPosition;
    public Vector3 FrontSensorPosition;
    public Vector3 FrontRightSensorPosition;
    public Vector3 LeftSensorPosition;
    public Vector3 RightSensorPosition;

    public enum Sensor { Left, Right, Front, FrontL, FrontR}

    public event Action<Sensor[], RaycastHit> OnSensorActivate;

    // Update is called once per frame
    void FixedUpdate()
    {
        List<Sensor> sensors = new List<Sensor>();

        RaycastHit hit;

		if(ThrowRay(FrontLeftSensorPosition)) sensors.Add(Sensor.FrontL);
        if(ThrowRay(FrontSensorPosition, out hit)) sensors.Add(Sensor.Front);
        if(ThrowRay(FrontRightSensorPosition)) sensors.Add(Sensor.FrontR);
        if(ThrowRay(LeftSensorPosition, -SensorAngle)) sensors.Add(Sensor.Left);
        if(ThrowRay(RightSensorPosition, SensorAngle)) sensors.Add(Sensor.Right);

        if(sensors.Count > 0) OnSensorActivate?.Invoke(sensors.ToArray(), hit);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0.5f,0,0.2f);

        DrawSensor(FrontLeftSensorPosition);
        DrawSensor(FrontSensorPosition);
        DrawSensor(FrontRightSensorPosition);
        DrawSensor(LeftSensorPosition, -SensorAngle);
        DrawSensor(RightSensorPosition, SensorAngle);
    }

    private bool ThrowRay(Vector3 sensorPosition, float angle = 0f)
    {
        RaycastHit hit;
        return ThrowRay(sensorPosition, out hit, angle);
    }

    private bool ThrowRay(Vector3 sensorPosition, out RaycastHit hit, float angle = 0f)
    {
        if(Physics.Raycast(transform.TransformPoint(sensorPosition), Quaternion.AngleAxis(angle, transform.up) * transform.forward, out hit, SensorsLength, ~LayerMask.NameToLayer("Water") & ~LayerMask.NameToLayer("Checkpoints")))
        {
        	DrawSensor(sensorPosition, fPosition: hit.point, drawSphere: (c, r) => { return; }, drawLine: (sp, ep) => Debug.DrawLine(sp, ep, Color.red));
            return true;
        }

        return false;
    }

    private void DrawSensor(Vector3 sensorPosition, float angle = 0f, Action<Vector3, float> drawSphere = null, Action<Vector3, Vector3> drawLine = null, Vector3? fPosition = null)
    {
        drawSphere = drawSphere ?? Gizmos.DrawWireSphere;
        drawLine = drawLine ?? Gizmos.DrawLine;
        fPosition = fPosition ?? transform.TransformPoint(sensorPosition) + Quaternion.AngleAxis(angle, transform.up) * transform.forward * SensorsLength;

        drawSphere(transform.TransformPoint(sensorPosition), SensorSize);
        drawLine(transform.TransformPoint(sensorPosition), fPosition.GetValueOrDefault());
    }
}
