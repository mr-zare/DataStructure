using System;

namespace ConsoleApp1
{
    class Program
    {
        public class stack1
        {
            int t = 0;
            char[] stack = new char[1000];
            public void push(char a)
            {
                if (t <= 999)
                    stack[t] = a;
                t++;
            }
            public char pop()
            {
                char m = stack[t - 1];
                stack[t - 1] = ' ';
                t--;
                return m;
            }
            public char peek()
            {

                return stack[t - 1];
            }
            public int size()
            {
                return t;
            }
            public bool isEmpty()
            {
                if (t == 0)
                    return true;
                else
                    return false;
            }
        }
        static void Main(string[] args)
        {
            stack1 a = new stack1();
            string line;
            int f = 1;
            line=Console.ReadLine();
            int k = line.Length;
            if(k==0)
            {
                f = 0;
            }
            for(int i=0;i<k;i++)
            {
                char m = line[i];
                if(m==')' && (a.isEmpty()==true || a.pop()!='('))
                {
                    f = 0;
                    continue;
                }
                else if (m == ']' && (a.isEmpty() == true || a.pop() != '['))
                {
                    f = 0;
                    continue;
                }
                else if (m == '}' && (a.isEmpty() == true || a.pop() != '{'))
                {
                    f = 0;
                    continue;
                }
                else if(m!=')' && m != '}' && m != ']')
                {
                    a.push(m);
                }
            }
            if (a.isEmpty() == true && f == 1)
            {
                Console.WriteLine("1");
            }
            else
                Console.WriteLine("0");
        }
    }
}
