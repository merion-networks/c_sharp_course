namespace OverridingLibrary
{
    public class Complex : IEquatable<Complex>
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));

            if (b is null)
                throw new ArgumentNullException(nameof(b));

            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));

            if (b is null)
                throw new ArgumentNullException(nameof(b));

            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));

            if (b is null)
                throw new ArgumentNullException(nameof(b));

            double realPart = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imaginaryPart = a.Real * b.Imaginary + a.Imaginary * b.Real;

            return new Complex(realPart, imaginaryPart);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));

            if (b is null)
                throw new ArgumentNullException(nameof(b));

            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            if (denominator == 0)
                throw new DivideByZeroException("Знаменатель не должен быть равен 0");


            double realPart = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
            double imaginaryPart = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;

            return new Complex(realPart, imaginaryPart);
        }

        public static bool operator ==(Complex a, Complex b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
            {
                return false;
            }

            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }

        public bool Equals(Complex? other)
        {
            if (other is null)
                return false;

            return Real == other.Real && Imaginary == other.Imaginary;
        }

        public override bool Equals(object other)
        {
            return Equals(other as Complex);
        }

        public override int GetHashCode()
        {

            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Real.GetHashCode();
                hash = hash * 23 + Imaginary.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            string imaginaryPart = Imaginary >= 0 ? $"+ {Imaginary}i" : $"- {-Imaginary}i";
            return $"{Real} {imaginaryPart}";
        }


    }
}
