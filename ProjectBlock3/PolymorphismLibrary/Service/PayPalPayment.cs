using PolymorphismLibrary.Interface;

namespace PolymorphismLibrary.Service
{
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Оплата сервисом PayPal");
        }
    }
}
