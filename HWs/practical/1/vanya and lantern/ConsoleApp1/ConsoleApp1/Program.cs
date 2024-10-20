using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string n1 = Console.ReadLine();
            int  j;
            double m = 0,key;
            string[] q = n1.Split(' ');
            int n = int.Parse(q[0]);
            int l = int.Parse(q[1]);
            double[] f = new double[n];
            string y = Console.ReadLine();
            string[] y1 = y.Split(' ');
            for (int i = 0; i < n; i++)
            {
                f[i] = double.Parse(y1[i]);
            }

            for (int i = 1; i <= n - 1; i++)
            {
                key = f[i];
                j = i - 1;
                while (j >= 0 && f[j] > key)
                {
                    f[j + 1] = f[j];
                    j--;
                }
                f[j + 1] = key;
            }
            for (int i = 1; i < n; i++)
            {
                if (((f[i] - f[i - 1]) / 2) > m)
                    m = (f[i] - f[i - 1]) / 2;
            }
            if (((l - f[n - 1])) > m)
            {
                m = (l - f[n - 1]);
            }
            if (((f[0])) > m)
            {
                m = f[0];
            }
            Console.WriteLine(m.ToString("f10"));
        }
    }
}