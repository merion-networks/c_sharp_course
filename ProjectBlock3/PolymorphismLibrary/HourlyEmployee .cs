
namespace PolymorphismLibrary
{
    public class HourlyEmployee : Employee
    {
        public decimal HourlyRate { get; set; }

        public int HoursWorked { get; set; }
        public override decimal CalculatePay()
        {
            return HourlyRate * HoursWorked;
        }
    }
}
