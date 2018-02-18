using System.Collections.Generic;
using Core.Inputs;
using Core.Interfaces;
using UnityEngine;

namespace Car_Racing.Assets.Scripts
{
    public class InputBehaviour : MonoBehaviour, IController
    {
        public ControllerInput[] ReadInputs()
        {
            Queue<ControllerInput> inputs = new Queue<ControllerInput>();

            inputs.Enqueue(new ControllerInput<float>(InputType.HorizontalAxis, Input.GetAxis("Horizontal")));
            inputs.Enqueue(new ControllerInput<float>(InputType.VerticalAxis, Input.GetAxis("Vertical")));
            inputs.Enqueue(new ControllerInput<bool>(InputType.Button1, Input.GetKey("space")));

            return inputs.ToArray();
        }
    }
}