// See https://aka.ms/new-console-template for more information


//Запрашивает координаты, переводит их в double и возвращает массив с точками и их координатами
int[] InitCoords(int count)
{
    System.Console.WriteLine("Первые введённые координаты определят измерение для расчёта");
    System.Console.Write($"Введи Координаты {count} точки в формате (x, y, z...): ");
    string msg = Console.ReadLine();
    string[] coords_str = msg.Split(new char[]{' ',','},StringSplitOptions.RemoveEmptyEntries);
    int[] coords = new int[coords_str.Length];
    for (int i = 0; i < coords_str.Length; i++)
    {
        try
        {coords[i] = int.Parse(coords_str[i]);}
        catch (System.Exception)
        {System.Console.WriteLine($"Взято слишком много координат, применены первые {coords.Length}");break;}
    }
    System.Console.WriteLine();
    return coords;
}

//Вычисляет дистанцию, определяет измерение для вычисления
double Distance(double[][] array_coords)
{
    double[] array_res = new double[array_coords[0].Length];
    for (int i = 0; i < array_coords[0].Length; i++)
    {
        double Difference = array_coords[1][i] - array_coords[0][i];
        array_res[i] = Math.Pow(Difference, 2);
    }
    double res = Math.Sqrt(array_res.Sum());
    return res;
}
System.Console.WriteLine("Задача 1\n");
while(true)
{
    double[][] AllCoords = new double[2][];
    for (int i = 0; i < AllCoords.Length; i++)
    {
        int[] coord = InitCoords(i+1);
        double[] conv_cords = new double[coord.Length];
        for (int k = 0; k < coord.Length; k++)
        {
            conv_cords[k] = Convert.ToDouble(coord[k]);
        }
        AllCoords[i] = conv_cords;
    }
    double res = Distance(AllCoords);
    System.Console.WriteLine("Расстояние - " + res + "\nПродолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

System.Console.WriteLine("Задача 23");
while (true)
{
    System.Console.WriteLine("Ввёдите число: ");
    double value = Convert.ToDouble(Console.ReadLine());
    for (int i = 0; i < value; i++)
    {
        System.Console.Write(Convert.ToInt32(Math.Pow((i+1),3)));
        if(i < value-1) System.Console.Write(", ");
        else System.Console.WriteLine();
    }
    System.Console.WriteLine("Продолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

System.Console.WriteLine("Задача 19");
while(true)
{
    System.Console.WriteLine("Введите число: ");
    long val = long.Parse(Console.ReadLine());
    string val_string = val.ToString();
    char[] val_array_chars = val_string.ToCharArray();

    Array.Reverse(val_array_chars);
    val_string = new String(val_array_chars);
    val = Convert.ToInt64(val_string);

    System.Console.WriteLine(val);

    System.Console.WriteLine("Продолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

System.Console.WriteLine("Доп. Задание");
while(true)
{
    System.Console.Write("Введите число: ");
    string msg = Console.ReadLine();
    string[] msg_array = msg.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);

    for (int i = msg_array.Length - 1, count = 0; i > msg_array.Length / 2 - 1; i--, count++)
    {
        string bofer = msg_array[count];
        msg_array[count] = msg_array[i];
        msg_array[i] = bofer;
    }

    System.Console.WriteLine();
    for (int i = 0; i < msg_array.Length; i++)
    {
        System.Console.Write(msg_array[i] + " ");
    }
}