using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_of_Life
{
    public class GFG
    {
        public static void Main()
        {
            Random rnd = new Random();

            Console.WriteLine("Ile generacji chcesz zobaczyć?");
            int generations = Convert.ToInt32(Console.ReadLine());
            generations = generations + 1;

            Console.WriteLine("Ile wierszy ma mieć plansza?");
            int M = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ile kolumn ma mieć plansza?");
            int N = Convert.ToInt32(Console.ReadLine());

            int[,] grid = new int[M, N];

            Console.WriteLine("0 generacja");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    grid[i, j] = rnd.Next(0, 2);
                    if (grid[i, j] == 0)
                        Console.Write(".");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int z = 1; z < generations; z++)
            {
                nextGeneration(grid, M, N, z);
            }

            Console.Write("Wciśnij ENTER żeby zakończyć..." +
                "");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        static void nextGeneration(int[,] grid, int M, int N, int z)
        {
            int[,] future = new int[M, N];

            for (int l = 1; l < M - 1; l++)
            {
                for (int m = 1; m < N - 1; m++)
                {
                    int aliveNeighbours = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                            aliveNeighbours +=
                                    grid[l + i, m + j];

                    aliveNeighbours -= grid[l, m];

                    if ((grid[l, m] == 1) &&
                                (aliveNeighbours < 2))
                        future[l, m] = 0;

                    else if ((grid[l, m] == 1) &&
                                 (aliveNeighbours > 3))
                        future[l, m] = 0;

                    else if ((grid[l, m] == 0) &&
                                (aliveNeighbours == 3))
                        future[l, m] = 1;

                    else
                        future[l, m] = grid[l, m];
                }
            }
            
            Console.WriteLine(z+" generacja");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (future[i, j] == 0)
                    {
                        Console.Write(".");
                        grid[i, j] = future[i, j];
                    }
                    else
                    {
                        Console.Write("*");
                        grid[i, j] = future[i, j];
                    }
                }
                Console.WriteLine();
            }
            Thread.Sleep(1000);
            //Console.ReadLine();
        }
    }
}
