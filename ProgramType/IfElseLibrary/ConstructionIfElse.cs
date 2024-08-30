namespace IfElseLibrary
{
    public class ConstructionIfElse
    {
        void PatternMatсhing()
        {
            object obj = "Привет Академия!";

            if (obj is string str && str.Length > 0)
            {
                Console.WriteLine($"Строка - {str}");
            }
        }

        public ConstructionIfElse()
        {
            int temperature = 35;

            if (temperature > 30)
            {
                Console.WriteLine("Жарко!");
                Console.WriteLine("Очень!");
            }
            else if (temperature > 20)
                Console.WriteLine("Тепло и приятно!");
            else
                Console.WriteLine("Прохладно!");


            PatternMatсhing();
        }
    }
}
