namespace CycleLibrary
{
    public class GameClass
    {

        public void Start()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 400);
            int attemps = 0;
            int guess;

            do
            {
                Console.WriteLine("Угадай число от 1 400");
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    attemps++;
                    if (guess < secretNumber)
                        Console.WriteLine("Больше!");
                    else if (guess > secretNumber)
                        Console.WriteLine("Меньше");
                    else Console.WriteLine($"Вы угадали за {attemps} попыток!");
                }
            } while (guess != secretNumber);
        }
        public GameClass() {  }
    }
}
