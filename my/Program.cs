using System;
using System.Linq;

// int[] meas = { 1,4,77,23,54,87,87,10,55,32,55,77,1,4 };
// System.Console.WriteLine(meas.Average());
// System.Console.WriteLine(meas.Min());
// System.Console.WriteLine(meas.Where(i => i%2 == 0).Sum());
// System.Console.WriteLine(meas.Where(i => i%2 == 1).Min());

// System.Console.WriteLine();
// int[] res_mnojestvo = meas.Distinct().ToArray();
// for (int i = 0; i < res_mnojestvo.Length; i++) System.Console.Write(res_mnojestvo[i]+" ");

// System.Console.WriteLine();
// int[] sort_res = meas.OrderBy(i => i).ToArray(); //OrderByDecending - в обратном порядке(сортировка)
// for (int i = 0; i < sort_res.Length; i++) System.Console.Write(sort_res[i]+" ");

// System.Console.WriteLine();

// Array.Sort(meas);
// Array.Find(meas, i => i > 50); //Find - превый встречный, FindLast - первый с конца
// Array.FindAll(meas, i => i > 50); // Создаёт массив с ними
// System.Console.WriteLine(Array.FindIndex(meas,i => i == 55)); //Ищет индекс, если нет, то -1
// Array.Reverse(meas); //Разворачивает массив

int[] box = new int[]{4,5,3,6,8,3,2};
System.Console.WriteLine(box[^1]); // ^1 получить 1-ый с конца элемент
int[] box_under = box[1..4]; //срез массива(последний не попадает) [..5] -от начала [5..] - до конца
System.Console.WriteLine(box_under[0]);

Index myIndex = ^2; //Индекс, это тип данных
Index myIndex_1 = new Index(4,true); //  == ^4
System.Console.WriteLine($"value index - {myIndex.Value}, isFromEnd - {myIndex.IsFromEnd}");

Range myRange = 1..4;
myRange = ^4..^1;
Range myRange_1 = new Range(1,4); // ==  1..4(конец не входит), 1 и 4 это ИНДЕКСЫ(тип данных)
int[] myBox = box[myRange];

string msg = "Helllo wwworllld!!!";
System.Console.WriteLine(msg[3..9]);