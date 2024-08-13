namespace ProgramType.Type
{
    /// <summary>
    /// Десятичные типы
    /// </summary>
    public class DecimalNumber
    {
        public DecimalNumber()
        {
            // 128 - битное десятичное чило
            /*
             * Диапазон: от ±1,0 x 10^-28 до ±7,9228 x 10^28
             * Точность: ~28-29 значащих цифр
             * Размер: 16 байт
             */
            decimal accountBalance = 10000.50M;
        }
    }
}
