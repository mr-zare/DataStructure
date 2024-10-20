using System;

namespace ConsoleApp1
{
    class Program
    {
        int[] stack = new int[1000];
        public  void push(int a,int i)
        {
            if(i<=999)
                stack[i] = a;   
        }
        public int  pop(int i)
        {
            int m=stack[i-1];
            stack[i-1] = 0;
            return m;
        }
        public  int peek(int i)
        {
            
            return stack[i-1];
        }
        public int size(int i)
        {
            return i;
        }
        public  bool isEmpty(int i)
        {
            if (i == 0)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            string line;
            int i = 0;
            Program a = new Program();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                string[] input = line.Split(' ');
                if (input[0]=="push")
                {
                    a.push(int.Parse(input[1]),i);
                    i++;
                }
                if (input[0] == "pop")
                {
                    int m = a.pop(i);
                    Console.WriteLine(m);
                    i--;

                }
                if (input[0] == "peek")
                {
                    int m = a.peek(i);
                    Console.WriteLine(m);
                }
                if (input[0] == "size")
                {
                    int m = a.size(i);
                    Console.WriteLine(m);
                }
                if (input[0] == "isEmpty")
                {
                    bool m=a.isEmpty(i);
                    if(m==true)
                        Console.WriteLine("True");
                    else
                        Console.WriteLine("False");
                }
            }
        }
    }
}
