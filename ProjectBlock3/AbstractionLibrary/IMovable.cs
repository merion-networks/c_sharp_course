namespace AbstractionLibrary
{
    public interface IMovable
    {
        string Name { get; }
        void Move(int x, int y);
    }
}
