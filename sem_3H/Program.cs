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
    System.Console.WriteLine("Расстояние - " + res + "Продолжим? (след. задание - q) ");
    string msg = Console.ReadLine();
    if (msg == "q")break;
}

