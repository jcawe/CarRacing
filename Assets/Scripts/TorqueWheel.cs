using UnityEngine;
using Core.Interfaces;

namespace Car_Racing.Assets.Scripts
{
    public class TorqueWheel : Wheel, ITorqueWheel
    {
        public float Torque { get; set; }

        override public void Update()
        {
            _wheel.motorTorque = Torque;
            Debug.Log($"Torque: {Torque}");
            base.Update();
        }
    }
}