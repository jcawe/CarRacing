namespace Core.Controllers
{
    public interface ICarController
    {
         void SpeedUp(float amount);
         void Steer(float amount);
         void Brake(float amount);
    }
}