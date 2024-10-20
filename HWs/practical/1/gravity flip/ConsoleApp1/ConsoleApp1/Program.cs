using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int key,j;
            int[] n1=new int[n];
            string t1 = Console.ReadLine();
            string[] s = t1.Split(' ');
            for(int i=0;i<n;i++)
            {
                n1[i] = int.Parse(s[i]);
            }

            for(int i=1;i<n;i++)
            {
                key = n1[i];
                j = i - 1;
                while (j >= 0 && (n1[j]>key))
                {
                    n1[j + 1] = n1[j];
                    j --;
                }
                n1[j + 1] = key;
            }

            for (int i = 0; i < n; i++)
            {
               Console.Write(n1[i]+" ");
            }
        }
    }
}
