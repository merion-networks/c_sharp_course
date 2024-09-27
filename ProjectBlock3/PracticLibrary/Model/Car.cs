using PracticLibrary.Interface;

namespace PracticLibrary.Model
{
    public class Car : Transport, IDriveble, IServiceable
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет!");
        }

        public void Service()
        {
            Console.WriteLine("Машина обслуживается!");
        }

        public override void Start()
        {
            Console.WriteLine("Машина заводится!");
        }
    }
}
