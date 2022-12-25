using System;
using System.Collections.Generic;
using System.Linq;

namespace Seminar9
{
    class Program
    {
        static void PrintAllNatural(int n)
        {
            if(n == 1 || n < 0) System.Console.Write($"{n}");
            else
            {
                PrintAllNatural(n-1);
                System.Console.Write($", {n}");
            }
        }
        static string PrintAllNatural(int m,int n)
        {
            if(n == m || n < m) return $"{m} ";
            return PrintAllNatural(m,n-1) + $"{n} ";
        }
        static int SumNums(int n)
        {
            if(n / 10 == 0) return n%10;
            return SumNums(n/10) + n%10;
        }
        static int DegreeOf(int num, int degree)
        {
            if(degree == 1 || degree < 1) return num;
            return DegreeOf(num, degree-1) * num;
        }
        static int Akkerman(int m, int n)
        {
            if(m == 0) return n + 1;
            else
            {
                if(m > 0 && n == 0) return Akkerman(m - 1, 1);
                else return Akkerman(m-1, Akkerman(m, n - 1));
            }
        }
        static void Main(string[] args)
        {
            PrintAllNatural(14);
            System.Console.WriteLine(PrintAllNatural(3,10));
            System.Console.WriteLine(SumNums(4325));

            System.Console.WriteLine(DegreeOf(10,5));
            System.Console.WriteLine(Akkerman(3,3));
        }
    }
}