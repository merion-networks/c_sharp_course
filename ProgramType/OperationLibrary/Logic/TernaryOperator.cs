﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationLibrary.Logic
{
    public class TernaryOperator
    {
        /*
        +------------------------+---------------------------+---------------------------+
        |       Критерий         |    Тернарный оператор     |          if-else          |
        +------------------------+---------------------------+---------------------------+
        | Простота выражения     | Подходит для простых      | Лучше для сложных         |
        |                        | и кратких выражений       | выражений и логики        |
        +------------------------+---------------------------+---------------------------+
        | Читаемость             | Улучшает для очень        | Более понятен для         |
        |                        | коротких выражений        | сложной логики            |
        +------------------------+---------------------------+---------------------------+
        | Многострочность        | Не подходит               | Хорошо подходит           |
        +------------------------+---------------------------+---------------------------+
        | Множественные действия | Не подходит               | Отлично подходит          |
        +------------------------+---------------------------+---------------------------+
        | Вложенность            | Ухудшает читаемость       | Легче понять при          |
        |                        | при вложенности           | правильном форматировании |
        +------------------------+---------------------------+---------------------------+
        | Возврат значений       | Отлично подходит          | Требует больше кода       |
        +------------------------+---------------------------+---------------------------+
        | Присваивание значений  | Компактно и эффективно    | Более многословно         |
        +------------------------+---------------------------+---------------------------+
        */

        public string GetStatus(bool isActive)
        {
            if (isActive)
            {
                return "Активно";
            }
            else
            {
                return "НЕ Активно";
            }
        }

        public string GetStatusTernary(bool isActive) => isActive ? "Активно" : "НЕ Активно";


        public void Difficult()
        {
            int a = 10, b = 40, c = 35, d = 20;
            string result = a > b ? "A" : (c > d ? "C" : "D");

            if (a > b)
            {
                result = "A";
            }
            else if (c > d)
            {
                result = "C";
            }
            else
            {
                result = "D";
            }

        }

        public TernaryOperator()
        {
            int dateTimeHour = DateTime.Now.Hour;
            string status = dateTimeHour >= 21 ? "Магазин закрыт" : "Магазин открыт";

            bool isActive = false;
            if (isActive)
            {
                status = "Активно";
            }
            else
            {
                status = "НЕ Активно";
            }

            status = isActive ? "Активно" : "НЕ Активно";

            int x = 10, y = 15, result;

            if (x > y)
            {
                result = x;
            }
            else
            {
                result = y;
            }

            result = x > y ? x : y;

        }
    }
}
