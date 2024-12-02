using System.ComponentModel;

namespace NullableLibrary
{
    public class NullableExample
    {
        public void Example()
        {
            int? nullableInt = null;
            bool? nullableBool = null;

            if (nullableInt.HasValue)
            {
                Console.WriteLine($"Значение - {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("Переменная равна null.");
            }

            int defaultValue = 10;

            int result = nullableInt ?? defaultValue;// Равно 10

            nullableInt ??= 5;

            string? message = null;
            int? length = message?.Length;

            int[]? numbers = null;
            //int? first = numbers?.FirstOrDefault();
            int? first = numbers?[0];

            DoWorking(message!);
        }

        private void DoWorking(string message)
        {
            if (string.IsNullOrEmpty(message)) { Console.WriteLine("Null"); }
        }

        public void ExampleConsoleWork()
        {
            Console.WriteLine("Введите читсло:");
            string? inputNumber = Console.ReadLine();
            int? nunber = int.TryParse(inputNumber, out int result) ? result : null;
            int finalNumber = nunber ?? 0;
            Console.WriteLine($"Вы ввели число {finalNumber}");
        }

        public void ExampleDataBase()
        {
            List<User> users = new List<User>();
            // Добавляем пользователей с полным набором данных
            users.Add(new User
            {
                Id = 1,
                FirstName = "Алексей",
                MiddleName = "Петрович",
                LastName = "Сидоров"
            });

            users.Add(new User
            {
                Id = 2,
                FirstName = "Ольга",
                LastName = "Морозова"
            });

            users.Add(new User
            {
                Id = 3,
                FirstName = "Дмитрий",
                MiddleName = "Иванович",
                LastName = "Иванов"
            });

            users.Add(new User
            {
                Id = 4,
                FirstName = "Елена",
                MiddleName = "Сергеевна"
            });

            foreach (var user in users)
            {
                string fullName = $"{user.FirstName ?? "_"} {user.LastName?.ToLower() ?? "_"} {user.MiddleName?.ToUpper() ?? "_"}";
                Console.WriteLine(fullName);
            }
        }
    }
}
