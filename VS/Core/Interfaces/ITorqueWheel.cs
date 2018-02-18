namespace Core.Interfaces
{
    public interface ITorqueWheel
    {
        float MaxTorque { get; }
        float Torque { get; set; }
    }
}