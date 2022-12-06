System.Console.WriteLine("Задача 10");
while(false)
{
    Random random = new Random();
    int x = random.Next(100,1000);
    System.Console.WriteLine(x);
    System.Console.WriteLine((x % 100)/10);

    System.Console.WriteLine("Продолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

System.Console.WriteLine("Задача 13");

while(true)
{
    System.Console.Write("Какое по счёту число найти?: ");
    int val = int.Parse(Console.ReadLine());
    Random random = new Random();
    int x = random.Next();
    int x_bof = x;
    System.Console.WriteLine(x);

    string Discharge_string =  Convert.ToString(Math.Log10(Convert.ToDouble(x)));
    string[] Discharge_string_array = Discharge_string.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);

    int Discharge = Convert.ToInt32(Discharge_string_array[0]);

    if(Discharge >= val - 1)
    {
        int pre_perem = Discharge - (val - 1);
        int pre_res;

        try{pre_res = x / Convert.ToInt32(Math.Pow(Convert.ToDouble(10),pre_perem));} 
        catch(DivideByZeroException)
        {
            pre_res = x;
        }
        System.Console.WriteLine(pre_res % 10);
    }
    else
    {
        System.Console.WriteLine($"{val}-ого числа нет");
    }

    System.Console.WriteLine("Продолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

System.Console.WriteLine("Задача 15");
while(false)
{   
    System.Console.Write("Введите день недели: ");
    int msg = int.Parse(Console.ReadLine());
    
    string[] day_name = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};

    if (msg <= day_name.Length && msg > 0) System.Console.WriteLine(day_name[msg-1]);
    else System.Console.WriteLine("Такого дня нет в неделе");

    System.Console.WriteLine("Продолжим? (выход - q) ");
    string msg_ = Console.ReadLine();
    if (msg_ == "q")break;
}