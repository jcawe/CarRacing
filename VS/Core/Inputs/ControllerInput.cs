namespace Core.Inputs
{
    public enum InputType
    {
        VerticalAxis,
        HorizontalAxis,
        Button1
    }

    public abstract class ControllerInput
    {
        public InputType Type { get; }

        protected ControllerInput(InputType type) => Type = type;
    }

    public class ControllerInput<T> : ControllerInput
    {
        public T Value{get;}

        public ControllerInput(InputType type, T value) : base(type) => Value = value;
    }
}