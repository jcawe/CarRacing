using Core.Interfaces;

namespace Core.Controllers
{
    public class BrakeController : IBrakeController
    {
        private readonly IWheel[] _wheels;

        public BrakeController(params IWheel[] wheels) => _wheels = wheels;

        public void Brake(float brakeForce)
        {
            foreach (var wheel in _wheels)
            {
                wheel.Brake = brakeForce*wheel.MaxBrake;
            }
        }
    }
}