namespace AbstractionLibrary
{
    public class Player : IMovable
    {
        private string name;
        public string Name => name;

        public void Move(int x, int y)
        {
            // реализация перемещения
        }
    }
}
