using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLibrary
{
    public class Validator
    {
        public static bool Validate(object obj, out List<string> errors)
        {
            errors = new List<string>();

            Type type = obj.GetType();
            foreach (var property in type.GetProperties())
            {
                var value = property.GetValue(obj);
                var requiredAttribute = property.GetCustomAttribute<RequiredAttribute>();
                if (requiredAttribute != null && value == null)
                {
                    errors.Add($"{property.Name} обязательно для заполнения");
                }

                var maxLengtAttribute = property.GetCustomAttribute<MaxLengthAttribute>();

                if (maxLengtAttribute != null && value is string strValue && strValue.Length > maxLengtAttribute.Length)
                {
                    errors.Add($"{property.Name} превысил допустимый лимит длинны строки {maxLengtAttribute}");
                }
            }

            return errors.Count > 0;
        }
    }
}
