using PolymorphismLibrary.Interface;

namespace PolymorphismLibrary.Service
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Оплата кредитной картой");
        }
    }
}
