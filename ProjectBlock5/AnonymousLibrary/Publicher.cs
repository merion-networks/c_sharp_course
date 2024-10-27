namespace AnonymousLibrary
{
    public class Publicher
    {
        public event EventHandler<string> OnMessage;

        public void DoSamething()
        {
            Console.WriteLine($"{nameof(Publicher)}: Что то делаем!");

            OnMessage?.Invoke(this, "Работа завершена!");

        }

        public void SoSo()
        {
            OnMessage?.Invoke(this, "Привет, Academy!");
        }
    }
}
