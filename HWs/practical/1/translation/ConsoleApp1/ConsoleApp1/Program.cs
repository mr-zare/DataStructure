using System;

namespace ConsoleApp1
{
    class Program
    {

        static void Main()
        {
            int j=0;
            string s,t;
            s= Console.ReadLine();
            t = Console.ReadLine();
            string t1 = "";
            for(int i=s.Length-1;i>=0; i--)
            {
                t1+= s[i];
                j++;
            }
            if(string.Equals(t1,t))
            {
                Console.WriteLine("YES");
            }
            if(t1!=t)
            {
                Console.WriteLine("NO");
            }
        }
    }
}
