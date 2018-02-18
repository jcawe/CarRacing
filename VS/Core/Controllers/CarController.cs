namespace Core.Controllers
{
    public class CarController : ICarController
    {
        private readonly IEngineController _engine;
        private readonly IBrakeController _brake;
        private readonly ISteeringWheelController _steering;

        public CarController(IEngineController engine, IBrakeController brake, ISteeringWheelController steering)
        {
            _engine = engine;
            _brake = brake;
            _steering = steering;
        }

        public void Brake(float amount)
        {
            _brake?.Brake(amount);
        }

        public void SpeedUp(float amount)
        {
            _engine?.SpeedUp(amount);
        }

        public void Steer(float amount)
        {
            _steering?.Steer(amount);
        }
    }
}