using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AttributeLibrary
{

    [DeveloperInfo("Сергей", "2024-11-14")]
    public class ExampleAttribute
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int x, int y);

        [Obsolete("Этот метод усторел. Используйте NewMethod вместо него.")]
        void OldMethod()
        {
            //Какая то старая логика
        }

        [DeveloperInfo("Петр Петров", "2024-11-15")]
        public void SimpleMetod([NotNull] string data)
        {
            if(data == null)
            {
                throw new ArgumentException(nameof(data));
            }
        }

        public ExampleAttribute() {

            OldMethod();
        }

    }

    [Serializable]
    [DeveloperInfo("Сергей", "2024-11-15")]
    public class DataConteiner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }

        [DeveloperInfo("Сергей", "2024-11-15")]
        [LogExecutio("LogProcessOrder", nameof(ProcessOrder))]
        public void ProcessOrder()
        {
            Console.WriteLine("Вызов по рефлексии.");
        }

        [DeveloperInfo("Сергей", "2024-11-14")]
        public void GetOrder()
        {

        }
    }

    public class Order
    {
        [Required]
        public int? OrderId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
