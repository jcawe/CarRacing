using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CarSensor))]
[RequireComponent(typeof(SteerWheel))]
[RequireComponent(typeof(Engine))]
public class AvoidObstacleAI : MonoBehaviour
{
    private SteerWheel _steerWheel;
    private Engine _engine;
    private bool _stucked;

    void Start()
    {
        _steerWheel = GetComponent<SteerWheel>();
        _engine = GetComponent<Engine>();
        GetComponent<CarSensor>().OnSensorActivate += AvoidObstacle;
    }

    private void AvoidObstacle(CarSensor.Sensor[] sensors, RaycastHit hit)
    {
        if (_stucked) return;
        var frontalObstacule = new CarSensor.Sensor[] { CarSensor.Sensor.Front, CarSensor.Sensor.FrontR, CarSensor.Sensor.FrontL };
        BroadcastMessage("SetAvoiding", true, SendMessageOptions.DontRequireReceiver);
        var steerAxis = 0f;

        if (sensors.Contains(CarSensor.Sensor.FrontL)) steerAxis += 1f;
        else if (sensors.Contains(CarSensor.Sensor.Left)) steerAxis += 0.5f;

        if (sensors.Contains(CarSensor.Sensor.FrontR)) steerAxis -= 1f;
        else if (sensors.Contains(CarSensor.Sensor.Right)) steerAxis -= 0.5f;

        if (steerAxis == 0 && frontalObstacule.All(x => sensors.Contains(x))) steerAxis += hit.normal.x < 0 ? -1f : 1f;

        _steerWheel.SetSteerAxis(steerAxis);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if(_stucked || (int)_engine.CurrentSpeed != 0) return;
        Debug.Log("Stucked!!");
        _stucked = true;
        BroadcastMessage("SetStucked", true, SendMessageOptions.DontRequireReceiver);

        Vector3 direction = Vector3.zero;

        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.green, 2f);
            var heading = transform.position - contact.point;
            var distance = heading.magnitude;

            direction += heading / distance;
        }
        Debug.DrawRay(transform.position, direction.normalized, Color.white, 2f);

        direction = transform.InverseTransformDirection(direction);

        Debug.DrawRay(transform.position, direction.normalized, Color.yellow, 2f);

        StartCoroutine(AvoidStuck(direction.normalized));
    }

    private IEnumerator AvoidStuck(Vector3 direction)
    {
        _engine.SetTorqueAxis(direction.z);
        _steerWheel.SetSteerAxis(-direction.x);
        yield return new WaitForSeconds(1f);

        BroadcastMessage("SetStucked", false, SendMessageOptions.DontRequireReceiver);
        _stucked = false;
        Debug.Log("Unstucked!!");
    }
}