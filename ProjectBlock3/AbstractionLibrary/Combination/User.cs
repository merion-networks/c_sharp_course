namespace AbstractionLibrary.Combination
{
    public class User : BaseEntity, IRepository
    {
        public string UserName { get; set; }

        public void Save()
        {
            //Реализовывает сохронение пользователя
        }
    }
}
