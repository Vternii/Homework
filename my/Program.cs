using System;

class Program
{
    static void interFace(int [,] folder1, string folder_y, int[] folder_x, int[,] folder2, int player)
    {
        int player1 = player == 1 ? 1 : 2;
        int player2 = player1 == 1 ? 2 : 1;
        System.Console.WriteLine(player);
        System.Console.WriteLine($"\tPlayer {player1}\t\t\t\t\tPlayer {player2}");
        System.Console.Write("\t");
        for (int i = 0; i < folder_x.Length; i++)
        {
            System.Console.Write(folder_x[i]+"  ");
        }

        System.Console.Write("\t\t\t");
        for (int i = 0; i < folder_x.Length; i++)
        {
            System.Console.Write(folder_x[i]+"  ");
        }

        System.Console.WriteLine();
        System.Console.WriteLine();

        for (int i = 0; i < folder1.GetLength(0); i++)
        {
            System.Console.Write(folder_y[i] + "\t");
            for (int k = 0; k < folder1.GetLength(1); k++)
            {
                System.Console.Write(folder1[i,k] + "  ");
            }
            System.Console.Write("\t\t" + folder_y[i] + "\t");

            for (int k = 0; k < folder2.GetLength(1); k++)
            {
                System.Console.Write(folder2[i,k] + "  ");
            }
            System.Console.WriteLine();
        }
    }
    static void interFace(int [,] folder1, string folder_y, int[] folder_x, string[,] folder2)
    {
        System.Console.WriteLine("\tPlayer 1\t\t\t\t\tPlayer 2");
        System.Console.Write("\t");
        for (int i = 0; i < folder_x.Length; i++)
        {
            System.Console.Write(folder_x[i]+"  ");
        }

        System.Console.Write("\t\t\t");
        for (int i = 0; i < folder_x.Length; i++)
        {
            System.Console.Write(folder_x[i]+"  ");
        }

        System.Console.WriteLine();
        System.Console.WriteLine();

        for (int i = 0; i < folder1.GetLength(0); i++)
        {
            System.Console.Write(folder_y[i] + "\t");
            for (int k = 0; k < folder1.GetLength(1); k++)
            {
                System.Console.Write(folder1[i,k] + "  ");
            }
            System.Console.Write("\t\t" + folder_y[i] + "\t");

            for (int k = 0; k < folder2.GetLength(1); k++)
            {
                System.Console.Write(folder2[i,k] + "  ");
            }
            System.Console.WriteLine();
        }
    }
 
    static int[][] build_mark(int[,] folder,int core, int build_position, int start_building, string build_label) //выдаёт ошибку
    {
        int[][] res = new int[core][];
        {
            int stop = 0;
            if(build_label == "X" || build_label == "1")
            {   
                while(stop == 0)
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
                            System.Console.WriteLine("Недостаточно места для размещения корабля, введите новые координаты (Y X): ");
                            System.Console.Write("Строка - : ");
                            build_position = int.Parse(Console.ReadLine()) - 1;
                            System.Console.Write("Столбец | : ");
                            start_building = int.Parse(Console.ReadLine()) - 1;
                        }
                        else
                        {
                            res[build - start_building] = new int[2]{build_position ,build};
                            System.Console.WriteLine($"{build_position} , {build}");
                            stop = 1;
                        }
                    }
                }
            }
            else
            {
                while(stop == 0)
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
                            System.Console.WriteLine("Недостаточно места для размещения корабля, введите новые координаты (Y X): ");
                            System.Console.Write("Столбец | : ");
                            build_position = int.Parse(Console.ReadLine()) - 1;
                            System.Console.Write("Строка - : ");
                            start_building = int.Parse(Console.ReadLine()) - 1;
                        }
                        else
                        {
                            res[build - start_building] = new int[2]{build,build_position};
                            System.Console.WriteLine($"{build} , {build_position}");
                            stop = 1;
                        }
                    }
                }
            }
        }
        return res;
    }
    static int[,] build_core(int[,] folder,int[][] build, string build_label, int CoreChar, int CoreFolderChar)
    {
        int[,] res = folder;
        if(build_label == "Y" || build_label == "2")
        {
            for (int i = 0; i < build.Length; i++)
            {
                res[build[i][0], build[i][1]] = CoreChar;
                
                try {res[build[i][0], build[i][1]-1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                try {res[build[i][0], build[i][1]+1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                if(i == build.Length - 1)
                {
                    try {res[build[i][0]+1, build[i][1]-1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]+1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                }
                if(i == 0)
                {
                    try {res[build[i][0]-1, build[i][1]-1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]-1, build[i][1]] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]-1, build[i][1]+1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                }
            }
        }
        else
        {
            for (int i = 0; i < build.Length; i++)
            {
                res[build[i][0], build[i][1]] = CoreChar;
                
                try {res[build[i][0]-1, build[i][1]] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                try {res[build[i][0]+1, build[i][1]] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                if(i == build.Length - 1)
                {
                    try {res[build[i][0]-1, build[i][1]+1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0], build[i][1]+1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]+1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                }
                if(i == 0)
                {
                    try {res[build[i][0]-1, build[i][1]-1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0], build[i][1]-1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                    try {res[build[i][0]+1, build[i][1]-1] = CoreFolderChar;} catch(IndexOutOfRangeException){}
                }
            }
        }
        return res;
    }

    static void InterpritatorForPlayer(int[,] folder_enemy,string folder_y,int[] folder_x, int[,] folder)
    {
        string[,] folder_play = new string[10,10];
        for (int i = 0; i < folder_play.GetLength(0); i++)
        {
            for (int k = 0; k < folder_play.GetLength(1); k++)
            {
                if ( folder[i,k] == 1 ) folder_play[i,k] = "#";
                if ( folder[i,k] == 3 ) folder_play[i,k] = "X";
                if ( folder[i,k] == 4 ) folder_play[i,k] = "@";
                if ( folder[i,k] == 0 || folder[i,k] == 2) folder_play[i,k] = "O";
            }
        }
        interFace(folder_enemy, folder_y, folder_x,folder_play);
    }
    static Tuple<int[][][], int[,], string[]> LaunchCores(int[] cores_count,int[][][] cores_array,
                            int cores_sum,int[,] folder, string[] cores_orient,
                            int[] folder_x, string folder_y, int[,] folder_enemy, int player)
    {
        while(true)
        {
            System.Console.WriteLine("Если по горизонтали (1) то сначала Строка потом Столбец");
            System.Console.WriteLine("Если по вертикали (2) то сначала Столбец потом Строка");
            System.Console.WriteLine("Куда вьебать кораблик, товарищ адмирал? (1 5 5 2) или (q)");

            string msg = Console.ReadLine(); 
            string[] msg_ = msg.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            int[] msg_s = new int[4];
            for (int k = 0; k < msg_.Length; k++) msg_s[k] = int.Parse(msg_[k]);
            bool stoper = false;
            
            while(!stoper)
            {
                switch (msg_s[0])
                {
                    case 4:
                    if(cores_count[0] == 0) System.Console.WriteLine("У вас нет возможности разместить этот корабль снова!");
                    else
                    {
                        cores_count[0]--;
                        stoper = true;
                    }
                    break;

                    case 3:
                    if(cores_count[1] == 0) System.Console.WriteLine("У вас нет возможности разместить этот корабль снова!");
                    else
                    {
                        cores_count[1]--;
                        stoper = true;
                    }
                    break;

                    case 2:
                    if(cores_count[2] == 0) System.Console.WriteLine("У вас нет возможности разместить этот корабль снова!");
                    else
                    {
                        cores_count[2]--;
                        stoper = true;
                    }
                    break;

                    case 1:
                    if(cores_count[3] == 0) System.Console.WriteLine("У вас нет возможности разместить этот корабль снова!");
                    else
                    {
                        cores_count[3]--;
                        stoper = true;
                    }
                    break;

                    default:
                    System.Console.WriteLine("Таких кораблей нет");
                    break;
                }
                if(!stoper)
                {
                    System.Console.Write("Выберите корабль снова: ");
                    msg_s[0] = int.Parse(Console.ReadLine());
                }
            }

            int[][] core_coordinat = build_mark(folder,msg_s[0],msg_s[1]-1,msg_s[2]-1,msg_[3]);

            if (msg_s[0] == 4) cores_array[cores_sum] = core_coordinat;
            if (msg_s[0] == 3) cores_array[cores_sum] = core_coordinat;
            if (msg_s[0] == 2) cores_array[cores_sum] = core_coordinat;
            if (msg_s[0] == 1) cores_array[cores_sum] = core_coordinat;
            cores_orient[cores_sum] = msg_[3];

            cores_sum++;

            folder = build_core(folder,core_coordinat,msg_[3], 1, 2);
            interFace(folder,folder_y,folder_x, folder_enemy, player);  

            for (int i = 0; i < cores_count.Length; i++)
            {
                switch (i)
                {
                    case 0:
                    System.Console.WriteLine($"4 - Линкор: {cores_count[i]} шт");
                    break;
                    case 1:
                    System.Console.WriteLine($"3 - Трехмачтовый: {cores_count[i]} шт");
                    break;
                    case 2:
                    System.Console.WriteLine($"2 - Катер: {cores_count[i]} шт");
                    break;
                    case 3:
                    System.Console.WriteLine($"1 - Лодка: {cores_count[i]} шт");
                    break;
                }
            }
            if (cores_sum == 10) break;
        }
        var res = Tuple.Create(cores_array, folder, cores_orient);
        return res;
    }
    static int[,] AnotherPlayer( int[,] folder_enemy, int[][][] cores_array,string[] cores_orient, int[] folder_x, string folder_y, int[,] folder)
    {
        bool next = true;
        while(next)
        {
            InterpritatorForPlayer(folder_enemy,folder_y,folder_x,folder);
            System.Console.Write("Ваш ход: ");
            string msg = Console.ReadLine();

            string[] msg_ = msg.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int[] log = new int[2];

            for (int i = 0; i < msg_.Length; i++)
            {
                log[i] = int.Parse(msg_[i]) - 1;
            }
            System.Console.WriteLine($"{log[0]} - {log[1]}");

            bool event_0 = false;
            bool event_1 = false;
            bool event_2 = false;
            bool event_3 = false;

            for (int i = 0; i < folder.GetLength(0); i++)
            {
                for (int k = 0; k < folder.GetLength(1); k++)
                {
                    //проверяет есть ли такая координата
                    if(log[0] == i && log[1] == k) 
                    {
                        event_1 = true;
                        //проверяет нет ли там корабля, и не поражённая ли это клетка
                        if(folder[i,k] == 3 || folder[i,k] == 4) event_3 = true;
                        //проверяет клетку на девственность
                        else if (folder[i,k] == 0 ||folder[i,k] == 2) event_0 = true;
                        //проверяет есть ли под клектой неразрушенный корабль
                        else if(folder[i,k] == 1) event_2 = true;
                    }
                }
            }
            if(event_1)
            {
                if (event_0)
                {
                    folder[log[0],log[1]] = 4;
                    next = false;
                }
                if(event_2)
                {
                    folder[log[0],log[1]] = 3;
                    System.Console.WriteLine("Вы попали во вражеский корабль, ходите ещё раз");
                }
                if(event_3)
                {
                    System.Console.WriteLine("Вы не можете ударить по этим координатам");
                    continue;
                }
            }
            else
            {
                System.Console.WriteLine("Таких координат нет");
                continue;
            }
            for (int i = 0; i < cores_array.Length; i++)
            {
                for (int k = 0, core_size = 0; k < cores_array[i].Length; k++)
                {
                    if(folder[cores_array[i][k][0], cores_array[i][k][1]] == 3)
                    {
                        core_size++;
                    }
                    if(core_size == cores_array[i].Length)
                    {
                        folder = build_core(folder,cores_array[i],cores_orient[i], 3, 4);
                    }
                }
            }
            //InterpritatorForPlayer(folder1,folder_y,folder_x);
            Console.ReadLine();
        }
        System.Console.WriteLine("Ваш ход окончен");
        return folder;
    }
    static void Main(string[] args)
    {
        int[,] folder1 = new int[10,10];
        int[,] folder2 = new int[10,10];

        string folder_y = "ABCDEFGHIJ";
        int[] folder_x = new int[10]{1,2,3,4,5,6,7,8,9,10};

        int[] cores_count = {1,2,3,4};
        string[] cores_orient = new string[10];
        int[][][] cores_array = new int[10][][];  //[корабль][количество координат][сами координаты(их там 2(Y,X))]
        int[][] logs = new int[10000][];

        int cores_sum = 0;
        int player = 1;
        int launch = 0;

        while(true)    
        {
            bool player_b = player == 1 ? true : false;
            int[,] P1 = player_b ? folder1 : folder2;
            int[,] P2 = player_b ? folder2 : folder1;

            if(launch < 2)
            {
                interFace(P1,folder_y,folder_x,P2,player);
                var trew = LaunchCores(cores_count, cores_array, cores_sum, P1, cores_orient, folder_x, folder_y,P2,player);

               cores_array = trew.Item1;
                P1 = trew.Item2;
                cores_orient = trew.Item3;

                launch++;
                player = player == 1 ? 2 : 1;
                continue;
            }

            P1 = AnotherPlayer(P1, cores_array, cores_orient, folder_x, folder_y,P2);
            player = player == 1 ? 2 : 1;
            continue;
        }

        
    }
}
