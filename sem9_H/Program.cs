using System;
using System.Collections.Generic;
using System.Linq;

namespace Seminar9
{
    class Program
    {
        static string PrintAllNaturalReverse(int n)
        {
            if(n == 1 || n < 0) return $"{n}";
            return  $"{n}, " + PrintAllNaturalReverse(n-1);
        }
        static int SumBehindNatural(int m,int n)
        {
            if(n == m || n < m) return m;
            return SumBehindNatural(m,n-1) + n;
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
            System.Console.WriteLine(PrintAllNaturalReverse(10));
            System.Console.WriteLine(SumBehindNatural(1,15));
            System.Console.WriteLine(Akkerman(3,3));
        }
    }
}