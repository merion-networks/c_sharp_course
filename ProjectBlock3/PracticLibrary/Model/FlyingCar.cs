using PracticLibrary.Interface;

namespace PracticLibrary.Model
{
    public class FlyingCar : Transport, IDriveble, IFlyable, IServiceable
    {
        public void Drive()
        {
            Console.WriteLine("Летающая машина едет!");
        }

        public void Fly()
        {
            Console.WriteLine("Летающая машина летит!");
        }

        public void Service()
        {
            Console.WriteLine("Летающая машина обслуживается!");
        }

        public override void Start()
        {
            Console.WriteLine("Летающая машина готова к использованию!");
        }
    }
}
