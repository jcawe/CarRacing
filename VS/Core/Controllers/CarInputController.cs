using Core.Inputs;
using Core.Interfaces;

namespace Core.Controllers
{
    public class CarInputController : IInputController
    {
        private readonly IController _controller;
        private readonly ICarController _carController;

        public CarInputController(IController controller, ICarController carController)
        {
            _controller = controller;
            _carController = carController;
        }

        public void ProcessInputs()
        {
            var inputs = _controller.ReadInputs();

            foreach (var input in inputs)
            {
                ProcessInput(input);
            }
        }

        private void ProcessInput(ControllerInput input)
        {
            switch (input.Type)
            {
                case InputType.VerticalAxis:
                    float amount = (input as ControllerInput<float>)?.Value ?? 0f;
                    _carController.SpeedUp(amount);
                    break;

                case InputType.HorizontalAxis:
                    float angle = (input as ControllerInput<float>)?.Value ?? 0f;
                    _carController.Steer(angle);
                    break;

                case InputType.Button1:
                    float brake = ((input as ControllerInput<bool>)?.Value ?? false) ? 1f : 0f;
                    _carController.Brake(brake);
                    break;

                default:
                    break;
            }
        }
    }
}