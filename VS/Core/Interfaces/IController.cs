using Core.Inputs;

namespace Core.Interfaces
{
    public interface IController
    {
         ControllerInput[] ReadInputs();
    }
}