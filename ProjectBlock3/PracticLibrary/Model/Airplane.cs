using PracticLibrary.Interface;

namespace PracticLibrary.Model
{
    public class Airplane : Transport, IFlyable, IServiceable
    {
        public void Fly()
        {
            Console.WriteLine("Самолет летит!");
        }

        public void Service()
        {
            Console.WriteLine("Самолет обслуживается!");
        }

        public override void Start()
        {
            Console.WriteLine("Самолет запускает двигатели!");
        }
    }
}
