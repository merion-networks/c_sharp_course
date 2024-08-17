namespace ProgramType.ReferenceType
{
    /// <summary>
    /// Строковый тип данных
    /// </summary>
    public class StringType
    {
        public enum ThreeDaysOfWeek
        {
            Monday,
            Tuesday,
            Wednesday
        }

        public void Create()
        {
            // Создание строки
            string name = "Петя, привет!";
            string text = @"Привет
                            этот текст можно 
                            переносить и все будет в порядке";
        }


        public void Interpolation()
        {
            //Интерполяция строк
            string nameGirl = "Алиса";
            int age = 20;

            string massage = $"Мое имя {nameGirl} и мне {age} лет!";

            //Вставка выражения в интреполяцию

            string result = $"Результат выражения 2 + 3 = {2 + 3}";

            decimal price = 19.99M;

            string formatedPrice = $"Цена - {price:C2}";

            const string constName = "Academy";
            const string constMessage = $"Привет, {constName}";
        }

        public void CheckNull()
        {
            //Null и пустые строки 
            string nullstr = null;

            string strEmpty = string.Empty; // "";

            if (string.IsNullOrEmpty(nullstr) ||
            string.IsNullOrEmpty(strEmpty))
            {
                string.IsNullOrWhiteSpace(nullstr);
            }
        }

        public void Coding()
        {
            //Кодировка
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        }

        public StringType()
        {
            // Операции  со строками 
            //Сравнение: string.Compare(), string.Equals(), string.CompareTo(), StringComparison 
            //Конкатинация: оператор +, string.Concat(), StringBilder
            //Форматирование: string.Format(), составные форматные строки
            //Методы Substring(), Trim(), ToUpper(), ToLower(), Replace(), Split(), Conteins(), StartsWhith(), EndsWith()

            //Строковые литералы
            //Обычные: "Привет"
            //Буквенные: @"C:\User\Name"
            //Интерполированные: $"Name: {name}"
        }
    }
}
