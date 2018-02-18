using Core.Interfaces;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    public class SteerWheel : Wheel, ISteerWheel
    {
        public float SteerAngle { get; set; }

        public override void Update()
        {
            _wheel.steerAngle = SteerAngle;
            base.Update();
        }
    }
}