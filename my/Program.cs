// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Сколько у вас денег(Руб, Евр, Юан) ('сумма' 'валюта'): ");
            string user_val = Console.ReadLine();
            string[] user_val_m = user_val.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            double rub = 0.016, eur = 1.05, yan = 0.14;

            double user_money;
            bool res_money_convert = double.TryParse(user_val_m[0],out user_money);
            bool res_val_convert = (user_val_m[1] == "Руб"|user_val_m[1] == "Евр"|user_val_m[1] == "Юан");

            if (res_money_convert & res_val_convert)
            {
                switch (user_val_m[1])
                {
                    case "Руб":
                        System.Console.WriteLine("У тебя: " + (user_money * rub) + " $");
                        break;
                    case "Евр":
                        System.Console.WriteLine("У тебя: " + (user_money * eur) + " $");
                        break;
                    case "Юан":
                        System.Console.WriteLine("У тебя: " + (user_money * yan) + " $");
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Ошибка ввода");
            }
        }
    }
}

