System.Console.WriteLine("Задача 10");
while(true)
{
    Random random = new Random();
    int x = random.Next(100,1000);
    System.Console.WriteLine(x);
    System.Console.WriteLine((x % 100)/10);

    System.Console.WriteLine("Продолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

System.Console.WriteLine();

