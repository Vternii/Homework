using System;
using System.Linq;

namespace Seminar7
{
 
    class Program
    {
        static Random random = new Random();
        static double[,] CreateArray2D(in int rows, in int cols, in int randMin = 0, in int randMax = 10)
        {
            double[,] res = new double[rows,cols];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int k = 0; k < res.GetLength(1); k++)
                {
                    res[i,k] = random.NextDouble() * random.Next(randMin, randMax);
                }
            }
            return res;
        }
        static void FindElement(in double[,] array,in int indexRow,in int indexCol)
        {
            if(indexRow >= array.GetLength(0) || indexRow < 0 || indexCol >= array.GetLength(1) || indexCol < 0)
            {
                System.Console.WriteLine($"Элемента с индексом [{indexRow}, {indexCol}] не существует");
            }
            else
            {
                System.Console.WriteLine($"Элемент с индексом [{indexRow}, {indexCol}] = {array[indexRow, indexCol]}");
            }
        }
        static double[] AverageValueToCols(in double[,] array)
        {
            double[] res = new double[array.GetLength(1)];
            for(int i = 0; i < array.GetLength(1); i++)
            {
                double[] intermediate = new double[array.GetLength(0)];
                for (int k = 0; k < array.GetLength(0); k++)
                {
                    intermediate[k] = array[k,i];
                }
                res[i] = intermediate.Average();
            }
            return res;
        }
        static void PrintArray(in double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    System.Console.Write($"{array[i,j]:N3}\t");
                }
                System.Console.WriteLine();
            }
        }
        static int[][] PascalTriangle(in int row)
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
            double[,] array = CreateArray2D(4,7,-2,10);
            PrintArray(array);
            System.Console.WriteLine("Средние по колонкам:");

            double[] average = AverageValueToCols(array);
            for (int i = 0; i < average.Length; i++)
            {
                System.Console.Write($"{average[i]:N3}\t");
            }

            System.Console.WriteLine();
            FindElement(array, 0,3);

            int myRow = 10; // How many strings in PascalTriangle?
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
