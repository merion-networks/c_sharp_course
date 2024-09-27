namespace OverridingLibrary
{
    public class Calculator
    {
        public int Sum(int a, int b) {  return a + b; }

        public decimal Sum(decimal a, decimal b) { return a + b; }

        public double Sum(double a, double b) { return a + b; }
    }
}
