using System;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string m;
            bool t;
            List<string> a=new List<string>();
            int n =Int32.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                m = Console.ReadLine();
                t = a.Contains(m);
                if(t==true)
                {
                    a.Remove(m);
                    a.Insert(0, m);
                }
                else
                {
                    a.Insert(0,m);
                }
            }
            for(int i=0;i<a.Count;i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
