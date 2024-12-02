using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLibrary
{
    public class ExampleReflection
    {

        public void Example()
        {

            Type type = typeof(DataConteiner);
            Console.WriteLine($"Имя типа {type.Name}");

            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"Имя свойства - {property.Name}, Тип свойства - {property.PropertyType}");
            }


            object odj = Activator.CreateInstance(type) ?? "Не получили объект;";

            Console.WriteLine(odj.GetType());

            MethodInfo methodInfo = type.GetMethod(nameof(DataConteiner.ProcessOrder));
            methodInfo.Invoke(odj, new object[] { });

            DisplayMethodInfo(type);

            DataConteiner dataConteiner = new DataConteiner();

            Logger.LogMethodExecution(dataConteiner, nameof(DataConteiner.ProcessOrder));
        }


        void DisplayMethodInfo(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var method in methods)
            {
                Console.WriteLine($"Имя метода - {method.Name}");

                var attributes = method.GetCustomAttributes(true);
                foreach (var attribute in attributes)
                {
                    Console.WriteLine($"Атрибуты - {attribute.GetType().Name}");
                }

                var devInfo = method.GetCustomAttribute<DeveloperInfoAttribute>(true);
                if (devInfo != null)
                {
                    Console.WriteLine($"Имя: {devInfo.DeveloperName} Время создания: {devInfo.LastModified}");
                }

            }

            var devInfoattribute = type.GetCustomAttribute<DeveloperInfoAttribute>(true);
            if (devInfoattribute != null)
            {
                Console.WriteLine($"Атрибут {devInfoattribute.GetType()} - Имя: {devInfoattribute.DeveloperName} Время создания: {devInfoattribute.LastModified}");
            }
        }

        public void ExampleValidate()
        {


            List<Order> orders = new List<Order>()
            {
            new Order()
                {
                    OrderId = 1,
                    Name = "Заказ номер 1000",
                    Price = 3.55M
                },
           new Order()
                {
                    Name = "Заказ номер 1001",
                } 
            };


            foreach (var order in orders)
            {
                if (Validator.Validate(order, out var validatorError))
                {
                    foreach (var error in validatorError)
                    {
                        Console.WriteLine($"Валидация нашла ошибки: {error}");
                    }
                }
                else
                {
                    Console.WriteLine("Заказ верный");
                }
            }
        }
    }
}
