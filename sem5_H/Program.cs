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
        static void sum_NegAndPos(ref int sumNegative, ref int sumPositive,in int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] > 0) sumPositive += array[i];
                else sumNegative += array[i];
            }
        }
        static void Change_Vals_In_Array(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= -1;
            }
        }
        static string SearchElement(in int element, in int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == element) return "Да";
            }
            return null;
        }
        static int[] ProductOfNums(in int[] array)
        {
            int stoper = array.Length % 2 == 0 ? array.Length / 2 : array.Length / 2 + 1;
            int[] res_array = new int[stoper];

            for (int i = 0, end = array.Length - 1; i < stoper; i++,end--)
            {
                if(i == end) res_array[i] = array[i];
                else res_array[i] = array[i] * array[end];
            }
            return res_array;
        }
        static void Main(string[] args)
        {
            int[] array = createArray(13,-9,10);

            int[] array_copy = new int[array.Length];
            array.CopyTo(array_copy, 0);

            int sum_Negative_nums = 0;
            int sum_Positive_nums = 0;

            string SearchElem = SearchElement(6, array);
            SearchElem ??= "Нет";

            sum_NegAndPos(ref sum_Negative_nums, ref sum_Positive_nums, array);
            Change_Vals_In_Array(ref array_copy);
            
            System.Console.WriteLine(string.Join(' ', array));
            System.Console.WriteLine(string.Join(' ', array_copy));

            System.Console.WriteLine($"Сумма положительных - {sum_Positive_nums}\nСумма отрицательных - {sum_Negative_nums}");
            System.Console.WriteLine($"{SearchElem}");

            int[] ProductOfNum = ProductOfNums(array);

            System.Console.WriteLine(string.Join(' ', ProductOfNum));


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
                int[] array_38 = createArray(10,0,10);

                System.Console.WriteLine($"Разница макс и мин - {array_38.Max() - array_38.Min()}");

                System.Console.WriteLine("Продолжим? (выход - q) ");
                string msg = Console.ReadLine();
                if (msg == "q")break;
            }
        }
    }
}