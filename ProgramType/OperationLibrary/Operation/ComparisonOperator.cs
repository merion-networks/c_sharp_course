using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationLibrary.Operation
{
    public class ComparisonOperator
    {
        public ComparisonOperator()
        {
            //Равно (==) и Не равно (!=)

            bool isEqual = (5 == 5); //True
            bool isNotEqual = ("abs" != "ABS"); //True

            // Больше (>) , Меньше (<), Больше или равно (>=) и меньше или равно (<=)

            bool isGrater = (10 > 5);
            bool isLessOrEqual = ('a' <= 'b'); //Сравнение по ASCII - коду

            //if-else конструкции и циклы

            int age = 20;
            if (age >= 18)
            {
                //Что-то делаем
            }

        }
    }
}
