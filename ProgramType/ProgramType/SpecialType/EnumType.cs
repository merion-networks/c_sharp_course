using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProgramType.SpecialType
{

    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {

            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()?
                            .GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
        }
    }


    enum DaysOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    [Flags]
    enum Permissions
    {
        [Display(Name = "Нет прав")]
        None = 0,
        [Display(Name = "Чтение")]
        Read = 1,
        [Display(Name = "Запись")]
        Write = 2,
        [Display(Name = "Запускать")]
        Execute = 4,
        [Display(Name = "Все права")]
        All = Read | Write | Execute,
        [Display(Name = "Чтение и запись")]
        ReadWrite = Read | Write,
    }
    public class EnumType
    {

        public EnumType()
        {
            DaysOfWeek daysOfWeek = DaysOfWeek.Monday;
            Console.WriteLine(daysOfWeek);


            Permissions permissions = Permissions.Read | Permissions.Write;
            Console.WriteLine(permissions);

            Console.WriteLine(permissions.GetDisplayName());

        }
    }
}
