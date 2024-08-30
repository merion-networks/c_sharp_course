namespace CycleLibrary
{
    public class ForCycle
    {

        void Example()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"Итерация - {i}");
            //}

            for (int i = 0; i < 10; i++)
            {
                if (i > 6)
                {
                    break;
                }

                for (int j = 0; j < 10; j++)
                {
                    if (i == 5 && j > 5)
                    {
                        continue;
                    }

                    Console.WriteLine($"Итерация - {i} - [{j}]");
                }

            }

        }

        void ExampleSintax()
        {
            //Компактность 
            //Ясность
            //Гибкость

            for (int i = 0; i < 10; i++)
            {

            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // n циклов
                }
            }

            //for(; ; ) { } - Бесконечный цикл

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // n циклов

                    continue;


                    // код не выполниться
                }

                break;
            }


            for (int i = 10; i > 0; i--)
            {

            }

            for (int i = 0; i < 100; i *= 3)
            {

            }
        }


        public ForCycle()
        {
            Example();
        }
    }
}
