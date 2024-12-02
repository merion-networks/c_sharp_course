using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyFiveProgram
{
    public class Subscriber
    {

        private string name;
        private readonly Publisher publisher;

        private EventHandler<EventArguments> eventHandler;

        private Action<string> eventActionHandler;

        public Subscriber(string name, Publisher publisher)
        {
            this.name = name;
            this.publisher = publisher;
        }

        public void Subscribe()
        {
            eventHandler = (sender, args) =>
            {
                Console.WriteLine($"Подписчик {name} получил сообщение: {args.Message}");
            };
            Console.WriteLine($"LogMessage - Подписчик {name}: Подписка на событие");
            publisher.EventOccurred += eventHandler;
        }


        public void UnSubscribe()
        {
            Console.WriteLine($"LogMessage - Подписчик {name}: Отписался от событие");

            publisher.EventOccurred -= eventHandler;
        }

        public void SubscribeAction()
        {
            eventActionHandler = (message) =>
            {
                Console.WriteLine($"Подписчик {name} получил сообщение: {message}");
            };
            Console.WriteLine($"LogMessage - Подписчик {name}: Подписка на событие");
            publisher.EventActionOccurred += eventActionHandler;
        }


        public void UnSubscribeAction()
        {
            Console.WriteLine($" LogMessage - Подписчик {name}: Отписался от событие");

            publisher.EventActionOccurred -= eventActionHandler;
        }
    }
}
