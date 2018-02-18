using Core.Interfaces;

namespace Core.Controllers
{
    public class EngineController : IEngineController
    {
        private readonly IWheel[] _torqueWheels;

        public EngineController(params IWheel[] torqueWheels) => _torqueWheels = torqueWheels;

        public void SpeedUp(float torque)
        {
            foreach (var wheel in _torqueWheels) wheel.Torque = torque*wheel.MaxTorque;
        }
    }
}