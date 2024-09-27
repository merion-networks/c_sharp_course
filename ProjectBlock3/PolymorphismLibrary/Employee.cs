namespace PolymorphismLibrary
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public abstract decimal CalculatePay();
    }
}
