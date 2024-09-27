namespace PracticLibrary
{
    public abstract class Transport
    {
        public string ModelName { get; set; }

        public string Make {  get; set; }

        public abstract void Start();
    }
}
