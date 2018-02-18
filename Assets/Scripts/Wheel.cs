using Core.Interfaces;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    public class Wheel : MonoBehaviour, IWheel
    {
        public float Brake { get; set; }

        protected WheelCollider _wheel;

        void Start()
        {
            _wheel = GetComponent<WheelCollider>();
        }

        public virtual void Update()
        {
            _wheel.brakeTorque = Brake;
        }
    }
}