using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Engine : MonoBehaviour
{
    public float MaxTorque;
    public float MaxBrake;
    [SerializeField] public WheelCollider[] TorqueWheels;
    private WheelCollider[] _wheels;
    private Rigidbody _rigidbody;
    private float _torqueAxis;

    public void SetTorqueAxis(float torqueAxis) => _torqueAxis = torqueAxis;
    public void FixedBrake() => ApplyBrake(MaxBrake);

    public float CurrentSpeed => transform.InverseTransformVector(_rigidbody.velocity).z * 3.6f;

    private float CurrentTorqueDirecction => transform.InverseTransformDirection(_rigidbody.velocity).z;
    private bool IsReverseTorque => CurrentTorqueDirecction * _torqueAxis < 0;
    private float Torque => _torqueAxis * MaxTorque;
    private float Brake => Mathf.Abs(_torqueAxis * MaxBrake);
    private void ApplyTorque(float torque) => TorqueWheels.ToList().ForEach(wheel => wheel.motorTorque = torque);
    private void ApplyBrake(float brake)
    {
        _wheels.ToList().ForEach(wheel => wheel.brakeTorque = brake);
        if(brake > 0) BroadcastMessage("BrakeLight", SendMessageOptions.DontRequireReceiver);
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _wheels = GetComponentsInChildren<WheelCollider>();
    }

    void FixedUpdate()
    {
        if (IsReverseTorque) ApplyBrake(Brake);
        else ApplyTorque(Torque);
    }

    void LateUpdate()
    {
        if(!IsReverseTorque) ApplyBrake(0f);
    }
}