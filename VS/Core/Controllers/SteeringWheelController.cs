using Core.Interfaces;

namespace Core.Controllers
{
    public class SteeringWheelController : ISteeringWheelController
    {
        private readonly IWheel[] _steerWheels;

        public SteeringWheelController(params IWheel[] steerWheels) => _steerWheels = steerWheels;

        public void Steer(float steerAngle)
        {
            foreach (var wheel in _steerWheels)
            {
                wheel.SteerAngle = steerAngle*wheel.MaxSteerAngle;
            }
        }
    }
}