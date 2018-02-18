using Core.Controllers;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    public class BrakeBehaviour : MonoBehaviour
    {
        [SerializeField] public Wheel[] Wheels;
        
        private IBrakeController _brakeController;

        void Start() => _brakeController = new BrakeController(Wheels);
        void Update() => _brakeController.Brake(Input.GetKey("space") ? 1f : 0f);
    }
}