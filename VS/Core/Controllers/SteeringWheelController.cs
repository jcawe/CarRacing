using Core.Interfaces;

namespace Core.Controllers
{
    public class SteeringWheelController : ISteeringWheelController
    {
        private readonly ISteerWheel[] _steerWheels;

        public SteeringWheelController(params ISteerWheel[] steerWheels) => _steerWheels = steerWheels;

        public void Steer(float steerAngle)
        {
            foreach (var wheel in _steerWheels)
            {
                wheel.SteerAngle = steerAngle*wheel.MaxSteerAngle;
            }
        }
    }
}