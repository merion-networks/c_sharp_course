using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramType.ReferenceType
{
    public class DynamicType
    {
        public DynamicType()
        {
            //Позволяет обойти статическую проверку типов
            //Тип определяется во время выполнения программы
            //Может вызывать исключения , в случае если операция не поддерживается

            dynamic dynamicVar = 10;
            Console.WriteLine(dynamicVar.GetType()); //System.Int32

            dynamic dynamicString = "Привет!";
            Console.WriteLine(dynamicString.GetType()); //System.String
        }
    }
}
