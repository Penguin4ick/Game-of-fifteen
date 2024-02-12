using System.Data.Common;
Console.Title = "Пятнашки";
Console.WriteLine("GAME OF FIFTEEN");
Console.OutputEncoding = System.Text.Encoding.UTF8;
//создание массива для поля
int[,] pole = new int [4, 4];
Random rnd = new Random();
//мандом массива
var values =
    Enumerable
        .Range(1, 4 * 4)
        .OrderBy(n => rnd.Next(0,15))
        .ToArray();
for (int i = 0; i < pole.GetLength(0); i++)
{
    for (int j = 0; j < pole.GetLength(1); j++)
    {
        pole[i,j]=  values[i*4+j];
    }

}
Console.WriteLine("↑ - сместить число вверх");
Console.WriteLine("↓ - сместить число вниз");
Console.WriteLine("← - сместить число влево");
Console.WriteLine("→ - сместить число вправо");
Console.WriteLine("Нажмите Enter для начала игры\nЧтобы закончить игру нажмите Esc");
Console.WriteLine();
ConsoleKeyInfo key = Console.ReadKey();
Console.CursorVisible = false;

    while (key.Key !=ConsoleKey.Escape)
    {
        Console.Clear();
        Console.WriteLine("↑ - сместить число вверх");
        Console.WriteLine("↓ - сместить число вниз");
        Console.WriteLine("← - сместить число влево");
        Console.WriteLine("→ - сместить число вправо");
        for (int a = 0; a < pole.GetLength(0); a++)
        {
            Console.WriteLine("+----+----+----+----+");
            for (int b = 0; b < pole.GetLength(1); b++)
            {
                int r = pole[a, b];
                Console.Write("| ");
                if (r < 10) Console.Write(" ");
                if (r == 16)
                {
                    Console.Write("   ");
                }
                else Console.Write("{0} ", r);
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("+----+----+----+----+");
        ConsoleKeyInfo po = Console.ReadKey();
        int xz = 0;
        switch (po.Key)
        {
            case ConsoleKey.DownArrow:
                {
                    for (int c = 0; c < pole.GetLength(0); c++)
                    {
                        for (int d = 0; d < pole.GetLength(1); d++)
                        {
                            if (pole[c, d] == 16)
                            {
                            if (c - 1 == -1)
                            {
                                break;
                            }
                                int r = pole[c - 1, d];
                                pole[c, d] = r;
                                pole[c - 1, d] = 16;
                            }
                        }
                    }
                    break;
                }
            case ConsoleKey.UpArrow:
                {
                    for (int c = 0; c < pole.GetLength(0); c++)
                    {
                        for (int d = 0; d < pole.GetLength(1); d++)
                        {
                            if (pole[c, d] == 16)
                            {
                            if (c + 1 == 4)
                            {
                                break;
                            }
                                int r = pole[c + 1, d];
                                pole[c, d] = r;
                                pole[c + 1, d] = 16;
                                xz = 1;
                                break;
                            }
                        }
                        if (xz == 1)
                        { break; }
                    }
                    break;
                }
            case ConsoleKey.RightArrow:
                {
                    for (int c = 0; c < pole.GetLength(0); c++)
                    {
                        for (int d = 0; d < pole.GetLength(1); d++)
                        {
                            if (pole[c, d] == 16)
                            {
                            if (d - 1 == -1 )
                            {
                                break;
                            }
                                int r = pole[c, d - 1];
                                pole[c, d] = r;
                                pole[c, d - 1] = 16;
                            }
                        }
                    }
                    break;
                }
            case ConsoleKey.LeftArrow:
                {
                    for (int c = 0; c < pole.GetLength(0); c++)
                    {
                        for (int d = 0; d < pole.GetLength(1); d++)
                        {
                        if (pole[c, d] == 16)
                        { 
                            if (d + 1 == 4)
                            {
                                break;
                            }
                                int r = pole[c, d + 1];
                                pole[c, d] = r;
                                pole[c, d + 1] = 16;
                                xz = 1;
                                break;
                            }
                        }
                        if (xz == 1)
                        { break; }
                    }
                    break;

                }
            //Автоматическая победа
            case ConsoleKey.L:
            {
                int l = 1;
                for (int c = 0; c < pole.GetLength(0); c++)
                {
                    for (int d = 0; d < pole.GetLength(1); d++)
                    {
                        pole[c, d] = l;
                        l++;
                    }
                }
                break;
            }
            case ConsoleKey.Escape: 
            { Environment.Exit(0);
                break;
            }
        }
    int i = 1;
    int j = 0;
    for (int column = 0; column < pole.GetLength(0); column++)
    {
        for (int row = 0; row < pole.GetLength(1); row++)
        { 
            if (pole[column,row] == i) 
            {
                i++;
                j++;
            }
        }
    }
    if (j == 16)
    {
    Console.Clear();
        Console.WriteLine("YOU WIN!!!");
        Console.ReadKey();
        Environment.Exit(0); }

    }