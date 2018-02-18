using UnityEngine;
using Core.Controllers;
using CoreCarController = Core.Controllers.CarController;

namespace Car_Racing.Assets.Scripts
{
    public class CarBehaviour : MonoBehaviour
    {
        [SerializeField] public Wheel[] Wheels;
        public ICarController CarController { get; set; }

        void Awake()
        {
            var engine = new EngineController(Wheels);
            var brake = new BrakeController(Wheels);
            var steering = new SteeringWheelController(Wheels);

            CarController = new CoreCarController(engine, brake, steering);
        }
    }
}