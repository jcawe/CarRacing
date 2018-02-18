namespace Core.Interfaces
{
    public interface IWheel
    {
        float MaxBrake { get; }
        float Brake { get; set; }

        float MaxTorque { get; }
        float Torque { get; set; }

        float MaxSteerAngle { get; }
        float SteerAngle { get; set; }
    }
}