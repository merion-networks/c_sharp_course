using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramType.Type
{
    public class IntNumber
    {
        /// <summary>
        /// Целочисленные типы данных
        /// </summary>
        public IntNumber()
        {
            // 8 - битные целые числа
            /*
             * Диапазон: от -128 до 127
             * Размер: 1 байт
             */
            sbyte temperature = 15;

            /*
             * Диапазон: от 0 до 255
             * Размер: 1 байт
             */
            byte color = 255;

            // 16 - битные целые числа
            /*
             * Диапазон: от -32 768 до 32 767
             * Размер: 2 байта
             */
            short population = -1234;

            /*
             * Диапазон: от 0 до 65 535
             * Размер: 2 байта
             */
            ushort year = 1992;

            // 32 - битные целые числа
            /*
             * Диапазон: от -2 147 483 648 до 2 147 483 647
             * Размер: 4 байта
             */
            int populationDog = 1000000;

            /*
             * Диапазон: от 0 до 4 293 967 295
             * Размер: 4 байта
             */
            uint viewCount = 3000000000;

            // 64 - битные целые числа
            /*
             * Диапазон: от -9 223 372 036 854 775 808 до 9 223 372 036 854 775 807
             * Размер: 8 байта
             */
            long debit = 30000000000;

            /*
             * Диапазон: от 0 до 18 446 744 073 709 551 615
             * Размер: 8 байта
             */
            ulong galaxySaze = 10000000000000000000;
        }
    }
}
