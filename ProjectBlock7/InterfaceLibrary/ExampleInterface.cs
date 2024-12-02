namespace InterfaceLibrary
{
    public class ExampleInterface : IExampleInterfaceA, IExampleInterfaceB
    {
        public void DoWork()
        {
            Console.WriteLine(nameof(ExampleInterface));
        }

    }
}
