using System;

int[][] array = new int[5][];

array[0] = new int[8];
array[1] = new int[3];
array[2] = new int[6];
array[3] = new int[2];
array[4] = new int[9];

Random random = new Random();

for (int i = 0; i < array.Length; i++)
{
    for (int k = 0; k < array[i].Length; k++)
    {
        array[i][k] = random.Next(100);
    }
}

for (int i = 0; i < array.Length; i++)
{
    for (int k = 0; k < array[i].Length; k++)
    {
        System.Console.Write(array[i][k] + "\t");
    }
    System.Console.WriteLine();
}
