using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            s = s.Replace("1111111", "2");
            s= s.Replace("0000000", "2");
            bool b = false;
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='2')
                {
                    b = true;
                }
            }
            if (b == true)
            {
                Console.WriteLine("YES");
            }
            else
                Console.WriteLine("NO");
        }
    }
}
