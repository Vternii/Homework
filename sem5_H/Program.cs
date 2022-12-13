namespace Own
{
    class Program
    {
        static Random random = new Random();
        static int[] createArray(in int Length, in int random_start = 0, in int random_end = 9)
        {
            int[] res = new int[Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = random.Next(random_start, random_end);
            }
            return res;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Задача 34");
            while(true)
            {
                int[] array_34 = createArray(11,100,1000);
                int count = 0;

                for (int i = 0; i < array_34.Length; i++)
                {
                    if(array_34[i] % 2 == 0) count++;
                }
                System.Console.WriteLine($"{ string.Join(' ', array_34) }\nКоличество чётных чисел = {count}");
                
                System.Console.WriteLine("Продолжим? (след. задание - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }
            
            System.Console.WriteLine("Задача 35");
            while(true)
            {
                int[] array_35 = createArray(123,0,151);
                int count = 0;
                for (int i = 0; i < array_35.Length; i++)
                {
                    if (array_35[i] >= 10 && array_35[i] <= 99)
                    {
                        count++;
                    }
                }
                System.Console.WriteLine(string.Join(' ', array_35));
                System.Console.WriteLine($"Чисел в промежутке [10,99] - {count}");

                System.Console.WriteLine("Продолжим? (след. задание - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }

            System.Console.WriteLine("Задача 36");
            while(true)
            {
                int[] array_36 = createArray(random.Next(10,99),random.Next(-50,0),random.Next(0,51));
                int sum = 0;

                for (int i = 1; i < array_36.Length; i += 2)
                {
                    sum += array_36[i];
                }

                System.Console.WriteLine($"Сумма чисел на нечётных позициях - {sum}");

                System.Console.WriteLine("Продолжим? (след. задание - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }

            System.Console.WriteLine("Задача 38");
            while(true)
            {
                int[] array_38 = createArray(10,0,100);

                //Чё изобретать велосипед)
                System.Console.WriteLine($"Разница макс и мин - {array_38.Max() - array_38.Min()}");

                System.Console.WriteLine("Продолжим? (выход - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }
        }
    }
}