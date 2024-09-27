namespace PolymorphismLibrary
{
    public class SalariedEmployee : Employee
    {
        public decimal AnnyalSalary { get; set; }

        public override decimal CalculatePay()
        {
            return AnnyalSalary / 12;
        }
    }
}
