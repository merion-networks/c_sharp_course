using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramType.ReferenceType
{

    public class ObjectType
    {
        public ObjectType()
        {
            //Базовый тип для всех других типов C#
            //Может хранить в себе значения любого типа 
            //Требует явного приведения типов при извлечении значений

            object obj = 42;
            object objString = "Привет!";

            int number = (int)obj;
            string text = (string)objString;

        }
    }
}
