using Xunit;

namespace MyFiveProgram.Test
{
    public class PublisherTests
    {
        [Fact]
        public void RaiseEvent_ShouldInvokeActionSubscribeHandler()
        {
            Publisher publisher = new Publisher();
            bool hendlerinvoke = false;

            publisher.EventActionOccurred += (message) =>
            {
                hendlerinvoke = true;
            };

            publisher.RaiseActionEvent("Тестовое сообщение");

            Assert.True(hendlerinvoke);
        }

        [Fact]
        public void RaiseEvent_ShouldInvokeSubscribeHandler()
        {
            Publisher publisher = new Publisher();
            bool hendlerinvoke = false;

            publisher.EventOccurred += (sender, args) =>
            {
                hendlerinvoke = true;
            };

            publisher.RaiseEvent("Тестовое сообщение");

            Assert.True(hendlerinvoke);
        }
    }
}
