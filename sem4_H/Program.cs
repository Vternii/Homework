using System;

namespace Own
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Задача 25");
            while(false)
            {
                System.Console.Write("Введите 1 число: ");
                int x = int.Parse(Console.ReadLine());

                System.Console.Write("Введите 2 число: ");
                int y = int.Parse(Console.ReadLine());

                int res = 1;
                for (int i = 0; i < y; i++)
                {
                    res *= x;
                }

                System.Console.WriteLine($"{x} ^ {y} = {res}");

                System.Console.WriteLine("Продолжим? (выход - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }

            System.Console.WriteLine("Задача 27");
            while(false)
            {
                System.Console.Write("Введите число: ");
                int x = int.Parse(Console.ReadLine());
                int x_copy = x;

                int res = 0;
                for (int i = 0; i < 1;)
                {
                    res += x % 10;
                    x /= 10;
                    if (x == 0)
                    {
                        i++;
                    }
                }
                System.Console.WriteLine($"{x_copy}\n{res}");

                System.Console.WriteLine("Продолжим? (выход - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }

            System.Console.WriteLine("Задача 29");
            while(true)
            {
                string[] msg = Console.ReadLine().Split(new char[]{' ',','}, StringSplitOptions.RemoveEmptyEntries);
                int Length = msg?.Length ?? 0;

                int[] res = new int[Length];

                for (int i = 0; i < Length; i++)
                {
                    res[i] = Convert.ToInt32(Convert.ToString(msg[i]));
                }

                System.Console.WriteLine(string.Join(' ', res));

                System.Console.WriteLine("Продолжим? (выход - q) ");
                string msg_ = Console.ReadLine();
                if (msg_ == "q")break;
            }
        }
    }
}