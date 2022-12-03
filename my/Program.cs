using System;



int[,] array_2D = new int[10,6];

Random random = new Random();

int height = array_2D.GetLength(0);
int width = array_2D.GetLength(1);

for (int x = 0; x < height; x++)
{
    for (int y = 0; y < width; y++)
    {
        array_2D[x,y] = random.Next(100);
    }
}

for (int x = 0; x < height; x++)
{
    for (int y = 0; y < width; y++)
    {
        System.Console.Write(array_2D[x,y] + " ");
    }
    System.Console.WriteLine();
}

