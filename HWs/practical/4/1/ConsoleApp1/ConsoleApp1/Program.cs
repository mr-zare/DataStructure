using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> answer = new List<string>();
            int wwe = 0;
            string s = Console.ReadLine();
            while (s != "")
            {
                string[] s1 = s.Split();
                Int32 k = Int32.Parse(s1[0]);
                Int32 n = Int32.Parse(s1[1]);
                int[,] a = new int[k, n];
                int[] su = new int[k];
                int[] q1 = new int[k];
                for (int i = 0; i < k; i++)
                {
                    q1[i] = i;
                    su[i] = 0;
                    string w = Console.ReadLine();
                    string[] m = w.Split();
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(m[j]);
                        su[i] += a[i, j];
                    }
                }
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        for (int p = 0; p < n - 1; p++)
                        {
                            if (a[i, p] > a[i, p + 1])
                            {
                                int temp = a[i, p];
                                a[i, p] = a[i, p + 1];
                                a[i, p + 1] = temp;
                            }
                        }
                    }
                }
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k - 1; j++)
                    {
                        if (su[j] > su[j + 1])
                        {
                            int tt = su[j];
                            su[j] = su[j + 1];
                            su[j + 1] = tt;
                            int tt1 = q1[j];
                            q1[j] = q1[j + 1];
                            q1[j + 1] = tt1;
                        }
                    }
                }
                int[] q = new int[k];
                int[] minv = new int[k];
                for (int i = 0; i < k; i++)
                {
                    q[i] = i;
                    minv[i] = a[i, 0];
                }

                /*
                for(int i=0;i<k;i++)
                {
                    for(int j=0;j<k-1;j++)
                    {
                        if(minv[j]>minv[j+1])
                        {
                            int r1 = minv[j];
                            minv[j] = minv[j + 1];
                            minv[j + 1] = r1;
                            int r = q[j];
                            q[j] = q[j + 1];
                            q[j + 1] = r;     
                        }
                    }
                }

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(a[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                  /*
                   for(int i=0;i<k;i++)
                   {
                       Console.WriteLine(q[i]);
                   }

                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine(q1[i]+" sum "+su[i]);
                }

                Console.WriteLine();
               */
                List<int> li = new List<int>();
                bool o;
                for (int i = 0; i < k; i++)
                {
                    int temp = q1[i];
                    List<int> li2 = new List<int>();
                    li2.Add(q1[i]);
                    for (int j = i + 1; j < k; j++)
                    {
                        o = true;
                        for (int u = 0; u < n; u++)
                        {
                            if (a[temp, u] > a[q1[j], u])
                            {
                                o = false;
                                break;
                            }
                        }
                        if (o == true)
                        {
                            li2.Add(q1[j]);
                            temp = q1[j];
                        }
                    }
                    if (li2.Count > li.Count)
                    {
                        li.Clear();
                        for (int j = 0; j < li2.Count; j++)
                        {
                            li.Add(li2[j]);
                        }
                        li2.Clear();
                    }
                }
                answer.Add(li.Count+"\n");
                for (int i = 0; i < li.Count; i++)
                {
                    int m = li[i] + 1;
                    answer[wwe] += m + " ";
                }
                wwe++;
                s = Console.ReadLine();
            }
            for(int i=0;i<answer.Count;i++)
            {
                Console.WriteLine(answer[i]);
            }

        }
    }
}
