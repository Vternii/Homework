using System;

namespace sem_6
{
    class Program
    {
        static string BinaryTransform(in int x)
        {
            if(x / 2 == 0) return $"{x % 2}";
            return BinaryTransform(x / 2) + $"{x % 2}";
        }

        static bool TryTriangle(int a, int b, int c)
        {
            bool res = true;
            if(a > b + c) res = false;
            else if(b > a + c) res = false;
            else if(c > b + a) res = false;
            return res;
        }

        static int[] FibNums(int N)
        {
            int[] res = new int[N];
            res[0] = 0;
            res[1] = 1;
            for (int i = 2; i < res.Length; i++)
            {
                res[i] = res[i-1] + res[i-2];
            }
            return res;
        }

        static int[] CopyArray(in int[] original)
        {
            int[] res = new int[original.Length];

            for (int i = 0; i < original.Length; i++)
            {
                res[i] = original[i];
            }

            return res;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(BinaryTransform(255));
            if (TryTriangle(7,4,3))
            {
                System.Console.WriteLine("Такой треугольник возможен");
            }
            else
            {
                System.Console.WriteLine("Такой треугольник невозможен");
            }

            int[] fib = FibNums(7);
            System.Console.WriteLine($"[{string.Join(' ', fib)}]");

            int[] fib_copy = CopyArray(fib);
            fib_copy[0] = 123;

            System.Console.WriteLine($"[{string.Join(' ', fib)}]");
            System.Console.WriteLine($"[{string.Join(' ', fib_copy)}]");

            Console.Clear();
            System.Console.WriteLine("Задача 41");

            int count = 0;
            while(false)
            {
                System.Console.Write("Введите число или 'stop': ");
                string message = Console.ReadLine();

                if(message == "stop")
                {
                    System.Console.WriteLine($"Чисел больше нуля: {count}");
                    break;
                }

                int number;
                bool result = int.TryParse(message, out number);

                if (result)
                {
                    if (number > 0) count++;
                }
                else System.Console.WriteLine("Неверный формат числа");
            }

            Console.Clear();
            System.Console.WriteLine("Задача 43");

            int?[] perems = {null,null,null,null};
            string[] perems_str = {"k1", "b1", "k2", "b2"};
            var perem = Tuple.Create(perems, perems_str);

            System.Console.WriteLine("y = k1 * x + b1");
            System.Console.WriteLine("y = k2 * x + b2");

            for (int i = 0; i < perems.Length; i++)
            {
                while(true)
                {
                    System.Console.Write($"Введите значение для {perems_str[i]}: ");
                    string message = Console.ReadLine();

                    int number;
                    bool result = int.TryParse(message, out number);    

                    if (result)
                    {
                        perems[i] = number;
                        break;
                    }
                    else System.Console.WriteLine("Неверный формат числа");
                }

                var k1 = perems[0] == null ? perems_str[0] : Convert.ToString(perems[0]);
                var b1 = perems[1] == null ? perems_str[1] : Convert.ToString(perems[1]);
                var k2 = perems[2] == null ? perems_str[2] : Convert.ToString(perems[2]);
                var b2 = perems[3] == null ? perems_str[3] : Convert.ToString(perems[3]);

                Console.Clear();

                System.Console.WriteLine($"y = {k1} * x + {b1}");
                System.Console.WriteLine($"y = {k2} * x + {b2}");
            }

            if(perems[0] == perems[2] && perems[1] != perems[3])
            {
                System.Console.WriteLine("Графики параллельны");
            }
            else
            {
                try
                {
                    double? x = (double?)((perems[3] - perems[1]) / (perems[0] - perems[2]));
                    double? y = perems[0] * x + perems[1];
                    System.Console.WriteLine($"Точка пересечения - ({x}, {y})");
                }
                catch (System.DivideByZeroException)
                {
                    System.Console.WriteLine("Графики одинаковы");
                }
            }
        }
    }
}