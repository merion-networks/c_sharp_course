using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLibrary
{
    public class Logger
    {
        public static void LogMethodExecution(object obj, string methodName, params object[] args)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName);
            if (method != null)
            {
                if (method.GetCustomAttribute<LogExecutioAttribute>() != null) {

                    Console.WriteLine(method.Name);
                }

                method.Invoke(obj, args);
            }
            else
            {
                throw new Exception("Метод не найден!");
            }
        }
    }
}
