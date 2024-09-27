namespace OverridingLibrary
{
    public class Operation
    {
        /*
         * Нельзя перегрузить :
         * . (Точка)
         * ?: (Тернарный оператор)
         * => (Лямбда оператор)
         * sizeof
         * typeof
         * checked
         * uncheked
         */

        /*
         * Можно перегрузить:
         * - Унарные: +, -, !, ~, ++, --, true, false
         * – Бинарные : `+`, `-`, `*`, `/`, `%`, `&`, `|`, `^`, `<<`, `>>`
         * - Сравнения: `==`, `!=`, `<`, `>`, `<=`, `>=`
         */
    }

    public class Vector
    {
        public int X { get; }
        public int Y { get; }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

    }
}
