namespace Core.Interfaces
{
    public interface ISteerWheel : IWheel
    {
        float MaxSteerAngle { get; }
        float SteerAngle { get; set; }
    }
}