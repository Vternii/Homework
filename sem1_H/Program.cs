//Задача 2
Console.WriteLine("Задача 2");
Console.Write("Введите первое число: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите второе число: ");
int b = Convert.ToInt32(Console.ReadLine());
if (a > b)
{
    Console.WriteLine("Max: "+ a);
    Console.WriteLine("Min: "+ b);
}
else
{
    if(a == b)
    {
        Console.WriteLine("Числа равны");
    }
    else
    {
        Console.WriteLine("Max: "+ b);
        Console.WriteLine("Min: "+ a);
    }
}
//Задача 4

Console.WriteLine("Задача 3");
Console.Write("Напишите числа через пробел: ");
string nums = Console.ReadLine();
string[] nums_split = nums.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
int[] nums_ready = new int[nums_split.Length];
for(int i = 0; i < nums_split.Length; i++)
{
    nums_ready[i] = Convert.ToInt32(nums_split[i]);
}
int max = nums_ready[0];
for(int i = 0; i < nums_ready.Length; i++)
{
    if(nums_ready[i] > max)
    {
        max = nums_ready[i];
    }
}
Console.WriteLine("Max: " + max);

//Задача 6
Console.WriteLine("Задача 6");
Console.Write("Введите число: ");
int number = Convert.ToInt32(Console.ReadLine());
if((number % 2) == 0) Console.WriteLine("Число " + number + " четное");
else Console.WriteLine("Число " + number + " НЕчетное");

//Задача 8
Console.WriteLine("Задача 8");
Console.Write("Введите число: ");
int number_8 = Convert.ToInt32(Console.ReadLine());
for(int i = 0; i <= number_8; i++)
{
    if((i%2) == 1)
    {
        Console.Write(i + " ");
    }
}