using Core.Controllers;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    public class SteeringWheelBehaviour : MonoBehaviour
    {
        [SerializeField]public SteerWheel[] SteerWheels;
        private ISteeringWheelController _steeringWheelController;

        void Start() => _steeringWheelController = new SteeringWheelController(SteerWheels);
    }
}