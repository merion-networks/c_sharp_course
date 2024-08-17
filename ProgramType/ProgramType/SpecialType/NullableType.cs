namespace ProgramType.SpecialType
{
    public class NullableType
    {

        void ConditionalOperator()
        {
            string? name = "null";
            int? length = name?.Length;
           // Console.WriteLine(length);
        }

        void CombineOperator()
        {
            string? name = "null";
            int? length = name?.Length;

            var result = length ?? 0;
            Console.WriteLine(result);

        }

        public NullableType()
        {
            //Оператор ? - оператор услолвного null
            ConditionalOperator();

            //Оператор ?? - оператор объединения с null
            CombineOperator();

            int? nullableInt = null;
            double? nullableDouble = 3.14;

            if (nullableInt.HasValue)
            {
                Console.WriteLine(nullableInt.Value);
            }
            else
            {
                Console.WriteLine("nullableInt is null");
            }

            if (nullableDouble.HasValue)
            {
                Console.WriteLine(nullableDouble.Value);
            }
            else
            {
                Console.WriteLine("nullableDouble is null");

            }

        }
    }
}
