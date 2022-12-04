using System;

class Program
{
    static void interFace(int[,] folder1, int[,] folder2, string folder_y, int[] folder_x)
    {
        System.Console.Write("\t");
        for (int i = 0; i < folder_x.Length; i++)
        {
            System.Console.Write(folder_x[i]+"  ");
        }

        System.Console.WriteLine();
        System.Console.WriteLine();

        for (int i = 0; i < folder1.GetLength(0); i++)
        {
            System.Console.Write(folder_y[i] + "\t");
            for (int k = 0; k < folder2.GetLength(1); k++)
            {
                System.Console.Write(folder1[i,k] + "  ");
            }
            System.Console.WriteLine();
        }
    }

    static int[][] build_mark(int[,] folder,int core, int build_position, int start_building, string build_label)
    {
        int[][] res = new int[core][];

        {
            if(build_label == "X" || build_label == "1")
            {   
                bool HaveARange = true;
                if((folder.GetLength(0) + 1 - (start_building + core)) < 0) HaveARange = false;

                for (int build = start_building; build < start_building + core; build++)
                {
                    if(folder[build_position, build] == 1 || folder[build_position, build] == 2) HaveARange = false;
                }
                
                for (int build = start_building; build < start_building + core; build++)
                {
                    if(!HaveARange)
                    {
                        System.Console.WriteLine("Недостаточно места для размещения корабля");
                        break;
                    }
                    res[build - start_building] = new int[2]{build_position ,build};
                    System.Console.WriteLine($"{build_position} , {build}");
                }
            }
            else
            {
                bool HaveARange = true;
                if((folder.GetLength(0) + 1 - (start_building + core)) < 0) HaveARange = false;

                for (int build = start_building; build < start_building + core; build++)
                {
                    if(folder[build, build_position] == 1 || folder[build_position, build] == 2) HaveARange = false;
                }
                
                for (int build = start_building; build < start_building + core; build++)
                {
                    if(!HaveARange)
                    {
                        System.Console.WriteLine("Недостаточно места для размещения корабля");
                        break;
                    }
                    res[build - start_building] = new int[2]{build,build_position};
                    System.Console.WriteLine($"{build} , {build_position}");
                }
            }
        }
        return res;
    }
    static int[,] build_core(int[,] folder,int[][] build, string build_label)
    {
        int[,] res = folder;
        if(build_label == "Y" || build_label == "2") //Поменять на X, ращобраться с координатной навигацией
        {
            for (int i = 0; i < build.Length; i++)
            {
                res[build[i][0], build[i][1]] = 1;
                
                try {res[build[i][0], build[i][1]-1] = 2;} catch(IndexOutOfRangeException){}
                try {res[build[i][0], build[i][1]+1] = 2;} catch(IndexOutOfRangeException){}
                if(i == build.Length - 1)
                {
                    try {res[build[i][0]+1, build[i][1]-1] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]+1] = 2;} catch(IndexOutOfRangeException){}
                }
                if(i == 0)
                {
                    try {res[build[i][0]-1, build[i][1]-1] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]-1, build[i][1]] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]-1, build[i][1]+1] = 2;} catch(IndexOutOfRangeException){}
                }
            }
        }
        else
        {
            for (int i = 0; i < build.Length; i++)
            {
                res[build[i][0], build[i][1]] = 1;
                
                try {res[build[i][0]-1, build[i][1]] = 2;} catch(IndexOutOfRangeException){}
                try {res[build[i][0]+1, build[i][1]] = 2;} catch(IndexOutOfRangeException){}
                if(i == build.Length - 1)
                {
                    try {res[build[i][0]-1, build[i][1]+1] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0], build[i][1]+1] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]+1] = 2;} catch(IndexOutOfRangeException){}
                }
                if(i == 0)
                {
                    try {res[build[i][0]-1, build[i][1]-1] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0], build[i][1]-1] = 2;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]-1] = 2;} catch(IndexOutOfRangeException){}
                }
            }
        }
        return res;
    }

    static void Main(string[] args)
    {
        int[,] folder1 = new int[10,10];
        int[,] folder2 = new int[10,10];

        string folder_y = "ABCDEFGHIJ";
        int[] folder_x = new int[10]{1,2,3,4,5,6,7,8,9,10};

        Random random = new Random();

        int[]cores = {1,2,3,4};

        while(true)
        {
            System.Console.WriteLine("Введите какой корабль где разместить в формате(4 4 6 2");
            string msg = Console.ReadLine(); 

            string[] msg_ = msg.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int[] msg_s = new int[4];

            for (int k = 0; k < msg_.Length; k++)
            {
                msg_s[k] = int.Parse(msg_[k]);
            }

            folder1 = build_core(folder1,build_mark(folder1,msg_s[0],msg_s[1],msg_s[2],msg_[3]),msg_[3]);
            interFace(folder1,folder2,folder_y,folder_x);  
            
            for (int i = 0; i < cores.Length; i++)
            {
                switch (i)
                {
                    case 0:
                    System.Console.WriteLine($"4 - Линкор: {cores[i]} шт");
                    break;
                    case 1:
                    System.Console.WriteLine($"3 - Трехмачтовый: {cores[i]} шт");
                    break;
                    case 2:
                    System.Console.WriteLine($"2 - Катер: {cores[i]} шт");
                    break;
                    case 3:
                    System.Console.WriteLine($"1 - Лодка: {cores[i]} шт");
                    break;
                }
            }
        }
    }
}
