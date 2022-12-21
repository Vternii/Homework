using System;


namespace Seminar7
{
    class Program
    {
        static void TransformArray_1(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = i + j;
                }
            }
        }

        static void TransformArray_2(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i += 2)
            {
                for (int j = 0; j < array.GetLength(1); j += 2)
                {
                    array[i,j] = (int)Math.Pow(array[i,j],2);
                }
            }
        }

//         Задача 49: Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные, и замените эти элементы на их квадраты.
// ​        (в примере подсчет индексов начинается с 1 , как в математике)
//          Например, изначально массив
//          выглядел вот так:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

        static void PrintArray(in int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    System.Console.Write($"{array[i,j]} ");
                }
                System.Console.WriteLine();
            }
        }
        static int[][] PascalTriangle(in int row = 2)
        {
            int[][] res = new int[row][];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[i + 1];
                for (int j = 0; j < res[i].Length; j++)
                {
                    if (j == res[i].Length-1 || j == 0)
                    {
                        res[i][j] = 1;
                    }
                    else
                    {
                        res[i][j] = res[i-1][j-1] + res[i-1][j];
                    }
                }
            }
            return res;
        }
        
        static void Main(string[] args)
        {
            int[,] myArray = new int[4,4];
            
            TransformArray_1(myArray);
            PrintArray(myArray);

            System.Console.WriteLine();

            TransformArray_2(myArray);
            PrintArray(myArray);

            int myRow = 20; // How many strings in PascalTriangle?
            int[][] Triangle = PascalTriangle(myRow);

            string[] TriangleString = new string[myRow];
            for (int i = 0; i < Triangle.Length; i++)
            {
                TriangleString[i] = string.Join(" ", Triangle[i]);
            }

            int LengthLastRow = TriangleString[^1].Length;

            for (int i = 0; i < TriangleString.Length; i++)
            {
                int countSpaces = (LengthLastRow - TriangleString[i].Length) / 2;
                while(countSpaces >= 0)
                {
                    System.Console.Write(" ");
                    countSpaces--;
                }
                System.Console.WriteLine(TriangleString[i]);
            }
        }
    }
}
