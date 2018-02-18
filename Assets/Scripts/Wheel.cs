using Core.Interfaces;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    public class Wheel : MonoBehaviour, IWheel
    {
        public float Brake { get; set; }

        [SerializeField]public float maxBrake;
        public float MaxBrake => maxBrake;

        [SerializeField]public float maxTorque;
        public float MaxTorque => maxTorque;

        public float Torque { get; set; }

        [SerializeField]public float maxSteerAngle;
        public float MaxSteerAngle => maxSteerAngle;

        public float SteerAngle { get; set; }

        protected WheelCollider _wheel;

        void Start() => _wheel = GetComponent<WheelCollider>();

        public virtual void Update()
        {
            _wheel.brakeTorque = Brake;
            _wheel.motorTorque = Torque;
            _wheel.steerAngle = SteerAngle;
        }
    }
}