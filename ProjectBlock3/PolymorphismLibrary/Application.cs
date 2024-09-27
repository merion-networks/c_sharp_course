namespace PolymorphismLibrary
{
    public class Application
    {
        private ILogger logger;

        public Application (ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            //Какая то логика
            logger.Log("Приложение запущено!");
        }
    }
}
