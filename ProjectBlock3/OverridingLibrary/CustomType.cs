namespace OverridingLibrary
{
    public class CustomType
    {
        //public static explicit operator CustomType(Type value)
        //{
        //    // Реализация преобразования
        //}

        //public static implicit operator CustomType(Type value)
        //{
        //    // Реализация преобразования
        //}
    }


    public class Fahrenheit
    {
        public double Degrees { get; set; }

        public Fahrenheit(double degrees)
        {
            Degrees = degrees;
        }

        //Явное преобразование из Fahrenheit в Celsius
        public static explicit operator Celsius(Fahrenheit fahrenheit)
        {
            return new Celsius((fahrenheit.Degrees - 32) * 5 / 9);
        }
    }

    public class Celsius
    {
        public double Degrees { get; set; }

        public Celsius(double degrees)
        {
            Degrees = degrees;
        }

        //Неявное преобразование из Celsius в Fahrenheit
        public static implicit operator Fahrenheit (Celsius celsius)
        {
            return new Fahrenheit(celsius.Degrees * 9 / 5 + 32);
        }

    }



    public class Meter
    {
        public double Value { get; set; }

        public Meter(double value)
        {
            Value = value;
        }
    }


    public class Kilometer
    {
        public double Value { get; set; }

        public Kilometer(double value)
        {
            Value = value;
        }

        //Неявное преобразование из Meter в Kilometer
        public static implicit operator Kilometer(Meter meter)
        {
            return new Kilometer(meter.Value / 1000);
        }
    }
}
