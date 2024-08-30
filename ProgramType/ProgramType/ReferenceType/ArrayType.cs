using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramType.ReferenceType
{
    public class ArrayType
    {

        void MaxItem()
        {
            int[] arr = { 1, 4, 7, 3, 7, 9, 100, 0, 22, 23, 54 };

            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine($"Максимальный элемент массива {max}");
        }
        public void TwoDimensionalArrays()
        {

            Console.WriteLine("++++++++++");

            int[,] matrix = new int[3, 3];
            int[,] predefined = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            //Свойства и методы двумерных массивов

            Console.WriteLine(matrix.Rank); //Количество измерений
            Console.WriteLine(matrix.GetLength(0)); // Количество строк
            Console.WriteLine(matrix.GetLength(1)); // Количество столбцов

            Console.WriteLine("++++++++++");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public void ThreeDimensionalArrays()
        {
            Console.WriteLine("++++++++++");

            int[,,] cube = new int[3, 3, 3];
            cube[0, 2, 1] = 11;

            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        Console.Write($"{cube[i, j, k],3}, ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }


        public void SumMatrix(int[,] oldMatrix, int[,] newMatrix)
        {
            int[,] result = new int[2, 2];

            for (int i = 0; i < result.Rank; i++)
            {
                for (int j = 0; j < result.Rank; j++)
                {
                    result[i, j] = oldMatrix[i, j] + newMatrix[i, j];
                }
            }


            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write($"{result[i, j],3} ");
                }

                Console.WriteLine();
            }
        }

        public void JaggedArray()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
            jaggedArray[1] = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            jaggedArray[2] = new int[5] { 4, 5, 6, 7, 8 };


            Console.WriteLine("Вывод зубчатого массива");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Строка ({i}) ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j],3} ");
                }
                Console.WriteLine();
            }



        }

        public void Multiplikator()
        {
            int[,] multiplikatorTable = new int[10, 10];

            for (int i = 0; i < multiplikatorTable.GetLength(0); i++)
            {
                for (int j = 0; j < multiplikatorTable.GetLength(1); j++)
                {
                    multiplikatorTable[i,j] = (i + 1) * (j + 1);
                }
            }

            for (int i = 0; i < multiplikatorTable.GetLength(0); i++)
            {
                for (int j = 0; j < multiplikatorTable.GetLength(1); j++)
                {
                    Console.Write($"{multiplikatorTable[i, j],3} ");
                }

                Console.WriteLine();
            }

            List<int> divisibleByThree = new List<int>();

            foreach (int number in multiplikatorTable)
            {
                if(number % 3 == 0 && !divisibleByThree.Contains(number))
                {
                    divisibleByThree.Add(number);
                }
            }

            divisibleByThree.Sort();
            foreach (var item in divisibleByThree)
            {
                Console.WriteLine($"{item} ");

            }

        }

        public ArrayType()
        {
            int[] array = new int[5];
            string[] fruits = { "Банан", "Яблоко", "Кокос" };

            //Доступ к элементам и изменение значений
            array[0] = 1;

            Console.WriteLine(fruits[0]); //Банан
            Console.WriteLine(fruits[1]); //Яблоко
            Console.WriteLine(fruits[2]); //Кокос

            //Свойства и методы массивов
            Console.WriteLine(array.Length);

            Array.Sort(array);

            int index = Array.IndexOf(fruits, "Яблоко");

            //Перебор элементов масива

            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            for (int i = 0; i < array.Length; i++) { Console.WriteLine(array[i]); }

            int[,] matrix = { { 1, 4 }, { 4, 5 } };
            int[,] matrix2 = { { 1, 4 }, { 4, 5 } };
            SumMatrix(matrix, matrix2);

            ThreeDimensionalArrays();
            JaggedArray();
            Multiplikator();
        }
    }
}

