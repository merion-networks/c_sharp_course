using PolymorphismLibrary.Interface;


namespace PolymorphismLibrary.Service
{
    public class OrderService
    {
        public void ProcessOrder(Order order, IPaymentStrategy paymentStrategy)
        {
            // Логика 
            paymentStrategy.Pay(order.TotalAmount);
        }
    }
}
