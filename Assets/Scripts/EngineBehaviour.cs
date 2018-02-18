using UnityEngine;
using Core.Controllers;

namespace Car_Racing.Assets.Scripts
{
    public class EngineBehaviour : MonoBehaviour
    {
        [SerializeField] public Wheel[] TorqueWheels;

        private IEngineController _engineController;

        void Start() => _engineController = new EngineController(TorqueWheels);

        void Update() => _engineController.SpeedUp(Input.GetAxis("Vertical"));
    }
}