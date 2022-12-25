using System;
using System.Collections.Generic;
using System.Linq;

namespace Seminar8
{
    class Program
    {
        static Random random = new Random();
        static void SortArray(int[] array)
        {
            int counter = 1;
            while(counter < array.Length)
            {
                for (int i = 0; i < array.Length - counter; i++)
                {
                    if(array[i] > array[i+1])
                    {
                        int bofer = array[i+1];
                        array[i+1] = array[i];
                        array[i] = bofer;
                    }
                }
                counter++;
            }
        }
        static int[,] CreateMatrix(in int rows, in int cols, in int rand_start = 0, in int rand_end = 11)
        {
            int[,] res = new int[rows, cols];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i,j] = random.Next(rand_start, rand_end);
                }
            }
            return res;
        }
        static int[,,] CreateMatrix(in int deep,in int rows, in int cols)
        {
            int[,,] res = new int[deep,rows, cols];
            int count = 10;
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    for (int k = 0; k < res.GetLength(2); k++)
                    {
                        res[i,j,k] = count;
                        count++;
                    }
                }
            }
            return res;
        }
        static int[,] ResultMatrix(in int[,] arrayA, in int[,] arrayB)
        {
            if(arrayA.GetLength(1) != arrayB.GetLength(0)) return null;
            else
            {
                int[,] res = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
                for (int i = 0; i < res.GetLength(0); i++)
                {
                    for (int j = 0; j < res.GetLength(1); j++)
                    {
                        for (int k = 0; k < arrayA.GetLength(1); k++)
                        {
                            res[i,j] += arrayA[i,k] * arrayB[k,j];
                        }
                    }
                }
                return res;
            }
        }
        static void PrintArray(in int[,,] array_3D = null, in int[,] array_2D = null)
        {
            if(array_2D == null)
            {
                for (int i = 0; i < array_3D.GetLength(0); i++)
                {
                    for (int k = 0; k < array_3D.GetLength(1); k++)
                    {
                        for (int j = 0; j < array_3D.GetLength(2); j++)
                        {
                            System.Console.Write($"{array_3D[i,k,j]} ");
                        }
                        System.Console.WriteLine();
                    }
                    System.Console.WriteLine();
                }
                System.Console.WriteLine();
            }
            else
            {
            for (int k = 0; k < array_2D.GetLength(0); k++)
                {
                    for (int j = 0; j < array_2D.GetLength(1); j++)
                    {
                        System.Console.Write($"{array_2D[k,j]} ");
                    }
                    System.Console.WriteLine();
                }
                System.Console.WriteLine();
            }
        }
        static void SpiralFill(in int[,] array, int i = 0, int k = 0)
        {
            int count = 2;
            int move = 1;
            array[i,k] = 1;

            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            while (count <= rows * cols)
            {
                while (k+1 < cols && array[i,k+1] == 0)
                {
                    array[i,k+1] = count;
                    k++;
                    count++;
                }
                while (i+1 < rows && array[i+1,k] == 0)
                {
                    array[i+1,k] = count;
                    i++;
                    count++;
                }
                while (k-1 >= 0 && array[i,k-1] == 0)
                {
                    array[i,k-1] = count;
                    k--;
                    count++;
                }
                while(i-1 >= 0 && array[i-1,k] == 0)
                {
                    array[i-1,k] = count;
                    i--;
                    count++;
                }
            }
        }
        static void Main(string[] args)
        {
            // Задание 54
            System.Console.WriteLine("Задание 54");

            int[,] array = CreateMatrix(6,10,0,10);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] array1D = new int[array.GetLength(1)];
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    array1D[k] = array[i,k];
                }

                SortArray(array1D);
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    array[i,k] = array1D[k];
                }
            }
            PrintArray(array_2D: array);

            //Задание 56
            System.Console.WriteLine("Задание 56");

            int[] sums_rows = new int[array.GetLength(0)];
            int indexMaxSumRow = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    sums_rows[i] += array[i,k];
                }
                if(sums_rows[indexMaxSumRow] < sums_rows[i]) indexMaxSumRow = i;
            }
            System.Console.WriteLine($"Максимальная сумма элементов в {indexMaxSumRow + 1} строке массива выше^");

            //Задание 58 (Это математическое умножение, просто там в примере, я так понял для упрощения эту матрицу перевернули)
            System.Console.WriteLine("Задание 58");

            int[,] array1 = CreateMatrix(2,5);
            int[,] array2 = CreateMatrix(5,4);

            PrintArray(array_2D: array1);
            PrintArray(array_2D: array2);

            int[,] matrix = ResultMatrix(array1, array2);
            PrintArray(array_2D: matrix);

            // Задание 60
            System.Console.WriteLine("Задание 60");

            int[,,] array3D_ = CreateMatrix(2,4,4);
            PrintArray(array_3D: array3D_);

            for (int i = 0; i < array3D_.GetLength(0); i++)
            {
                for (int k = 0; k < array3D_.GetLength(1); k++)
                {
                    string[] pre_res = new string[array3D_.GetLength(2)];
                    for (int j = 0; j < array3D_.GetLength(2); j++)
                    {
                        pre_res[j] = $"{array3D_[i,k,j]}({i},{k},{j})";
                    }
                    System.Console.WriteLine(string.Join(' ', pre_res));
                    //System.Console.ReadLine();
                }
            }
            //Задание 62
            System.Console.WriteLine("Задание 62");

            int[,] sp = new int[7,9];
            SpiralFill(sp);
            PrintArray(array_2D:sp);
        }
    }
}