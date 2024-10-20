using System;

namespace ConsoleApp1
{
    class Program
    {
        static void algo(int[,] vorodi, int t, int aval, int akhar)
        {
            bool[] shpath = new bool[t];
            int[] cost = new int[t];
            for (int i = 0; i < t; i++)
            {
                shpath[i] = false;
                cost[i] = 987654321;
            }
            cost[aval] = 0;
            for (int i = 0; i <= t - 2; i++)
            {
                int m = mincost(shpath, t, cost);
                shpath[m] = true;
                for (int j = 0; j <= t - 1; j++)
                {
                    if (!shpath[j] && vorodi[m, j] != 0 && cost[m] + vorodi[m, j] < cost[j] && cost[m] != 987654321)
                        cost[j] = vorodi[m, j] + cost[m];
                }
            }

            int javab;
            if (cost[aval] > cost[akhar])
            {
                javab = cost[aval] - cost[akhar];
            }
            else
            {
                javab = cost[akhar] - cost[aval];
            }

            if (javab != 0)
            {
                Console.WriteLine(javab);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
        static int mincost(bool[] shpath, int t,int[] cost)
        {
            int indexm = -1,minimum = 987654321;
            for (int i = 0; i < t; i++)
                if (minimum >= cost[i] && shpath[i] == false )
                {
                    indexm = i;
                    minimum = cost[i];
                }
            return indexm;
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            string vo = Console.ReadLine();
            string[] noedge = vo.Split(' ');
            int tedge = int.Parse(noedge[1]);
            int tNode = int.Parse(noedge[0]);
            int[,] vorodi = new int[tNode, tNode];
            for (int i = 0; i < tNode; i++)
            {
                for (int j = 0; j < tNode; j++)
                {
                    vorodi[i, j] = 0;
                }
            }

            for (int i = 0; i < tedge; i++)
            {
                string in1 = Console.ReadLine();
                string[] inp = in1.Split(' ');
                int paycost = int.Parse(inp[2]);
                int akhar = int.Parse(inp[1]);
                int aval = int.Parse(inp[0]);
                vorodi[aval - 1, akhar - 1] = paycost; 
            }
            vo = Console.ReadLine();
            string[] vo2 =vo.Split(' ');
            int start = int.Parse(vo2[0]) - 1;
            int finish = int.Parse(vo2[1]) - 1;
            algo(vorodi, tNode, start, finish);
        }
    }
}
