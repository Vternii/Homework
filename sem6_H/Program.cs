using System;

namespace sem_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            System.Console.WriteLine("Задача 41");

            int count = 0;
            while(true)
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
            System.Console.Write("Продолжим? ");
            Console.ReadLine();

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
                    double? x = ((double?)(perems[3] - perems[1]) / (double?)(perems[0] - perems[2]));
                    double? y = perems[0] * x + perems[1];
                    System.Console.WriteLine($"Точка пересечения - ({x:f2}, {y:f2})");
                }
                catch (System.DivideByZeroException)
                {
                    System.Console.WriteLine("Графики одинаковы");
                }
            }
        }
    }
}