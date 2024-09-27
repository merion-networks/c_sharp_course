namespace AbstractionLibrary
{
    public class GameObject : IMovable, IRenderable
    {
        private string name;
        public string Name => name;


        #region IMovable

        public void Move(int x, int y)
        {
            // реализация перемещения
        }

        #endregion

        #region IRenderable

        public void Render()
        {
            // реализация отображения
        }

        #endregion
    }
}
