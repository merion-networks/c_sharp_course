using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    /// <summary>
    /// Тема: Условные конструкции
    /// </summary>
    public class MyConditionalConstruction
    {

        public MyConditionalConstruction()
        {
            //if - else 
            //switch
            //Pattern Matching в switch

            // Демонстрация использования if-else

            int age = 20;
            string status = string.Empty;
            if (age >= 70)
            {
                status = "Пенсионер";
            }
            else if (age >= 18)
            {
                status = "Совершеннолетний";
            }
            else
            {
                status = "Несовершеннолетний";
            }

            Console.WriteLine(status);

            // Демонстрация использования switch

            var dayOfWeek = DateTime.Now.DayOfWeek;
            Console.WriteLine(dayOfWeek);
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Friday:
                    Console.WriteLine("Рабочие дни!");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Выходные дни!");
                    break;
                default:
                    Console.WriteLine("Не верные дни недели!");
                    break ;
            }

            // Демонстрация использования Pattern Matching в switch
            int code = 140;

            var oldCollection = new int[] { 77, 40, 55 };
            var newCollection = new int[] { 177, 140, 155 };

            switch (code)
            {
                case var c when oldCollection.Contains(c) :
                    Console.WriteLine($"Код из старой коллекции. Значение {c}");
                    break;

                case var c when newCollection.Contains(c):
                    Console.WriteLine($"Код из новой коллекции. Значение {c}");
                    break;
                default:
                    Console.WriteLine($"Не известный код {code}");
                    break;
            }

        }
    }
}
