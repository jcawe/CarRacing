using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SteerWheel : MonoBehaviour
{
    public float MaxSteerAngle;
    public WheelCollider[] SteerWheels;

    private float _steerAxis;

    public void SetSteerAxis(float steerAxis) => _steerAxis = steerAxis;
    public float SteerAxis => _steerAxis;

    private float SteerAngle => _steerAxis * MaxSteerAngle;
    private void ApplySteerAngle(float steerAngle) => SteerWheels.ToList().ForEach(wheel => wheel.steerAngle = steerAngle);

    void FixedUpdate()
    {
        ApplySteerAngle(SteerAngle);
    }
}