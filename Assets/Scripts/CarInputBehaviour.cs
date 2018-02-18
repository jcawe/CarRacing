using Core.Controllers;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    [RequireComponent(typeof(CarBehaviour))]
    public class CarInputBehaviour : MonoBehaviour
    {
        [SerializeField] public InputBehaviour Controller;
        private IInputController _carInputController;

        void Awake()
        {
            var carController = GetComponent<CarBehaviour>().CarController;
            _carInputController = new CarInputController(Controller, carController);
        }

        void Update() => _carInputController.ProcessInputs();
    }
}