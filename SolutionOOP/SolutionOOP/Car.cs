namespace SolutionOOP
{
    public class Car
    {
        //Поля (Данные)

        private int speed;
        private int mileage;
        public static int totalCar;

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value >= 0 && value <= 300)
                    speed = value;
            }
        }

        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }

        //Метод (Поведение)
        public static Car CreateSportCar()
        {
            return new Car() { Make = "Ferrary", Year = 2024 };
        }


        public void StartEngine()
        {
            Console.WriteLine("Двигаель запущен!");
        }

        public void StopEngine()
        {
            Console.WriteLine("Двигаель остановлен!");
        }

        public void Accelerate()
        {
            speed += 10; // speed = speed + 10;
            Console.WriteLine($"Скорость увеличена на 10 км/ч! Текущая скорость - {speed}");

            mileage = speed * 10;
            Console.WriteLine($"Пробег увеличен на - {speed * 10} и равен - {mileage}");
        }

        public int CalculeteAge(int currentYear)
        {
            return currentYear - Year;
        }


        // Конструктор
        public Car()
        {
            totalCar = 1000;
            mileage = 0;
        }

        public Car(string model, string make)
        {
            Make = make;
            Model = model;
        }

        public Car(string model, string make, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
    }
}
