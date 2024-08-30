using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfElseLibrary
{
    public class ConstractionSwitch
    {

        public void ExampleTraditional()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Monday;

            string result;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    result = "Начало недели";
                    break;
                case DayOfWeek.Friday:
                    result = "Конец рабочий недели";
                    break;
                case DayOfWeek.Sunday:
                    result = "Выходной";
                    break;
                default:
                    result = "Обычный день";
                    break;
            }

            Console.WriteLine(result);
        }


        public void Exapmle()
        {
            DayOfWeek dayOfWeek = DayOfWeek.Monday;

            string result = dayOfWeek switch
            {
                DayOfWeek.Monday => "Начало недели",
                DayOfWeek.Friday => "Конец рабочий недели",
                DayOfWeek.Sunday => "Выходной",
                _ => "Обычный день"
            };

            Console.WriteLine(result);
        }

        public void MappingToTipes()
        {
            object obj = 42;
            string typeDescription = obj switch
            {
                int i => $"Целое число {i}",
                string s => $"Строка длинное {s.Length}",
                _ => "Не известный тип"
            };

            Console.WriteLine(typeDescription);
        }

        public void ExampleWhen()
        {
            int number = 50;
            string description = number switch
            {
                < 0 => "Отрицательное число",
                0 => "Ноль",
                > 0 and < 10 => "Положительное число",
                _ when number % 2 == 0 => "Четное",
                _ => "Не четное положительное число"
            };

            Console.WriteLine(description);
        }

        public void ExampleTuple()
        {
            (int x, int y) = (3, 4);
            string pointDescription = (x, y) switch
            {
                (0, 0) => "Начало координат",
                (var a, var b) when a == b => "На диогонали",
                _ => "Обычная точка"
            };
            Console.WriteLine(pointDescription);
        }

        public ConstractionSwitch()
        {
        }
    }
}
