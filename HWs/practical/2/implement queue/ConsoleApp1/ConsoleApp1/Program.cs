using System;

namespace ConsoleApp1
{
    class Program
    {
        int[] queue = new int[1000];
        public void enqueue(int e,int j)
        {
            queue[j] = e;
        }
        public int dequeue(int i,int j)
        {
            int m = queue[i];
            queue[i] = 0;
            return m;
        }
        public int size(int i,int j)
        {
            return j - i;
        }
        public bool isEmpty(int i,int j)
        {
            if (i == j)
            {
                return true;
            }
            else
                return false;
        }
        static void Main(string[] args)
        {
            string line;
            int i = 0,j = 0;
            Program a = new Program();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                string[] input = line.Split(' ');
                if (input[0] == "enqueue")
                {
                    a.enqueue(int.Parse(input[1]),j);
                    j++;
                }
                if (input[0] == "dequeue")
                {
                    int m=a.dequeue(i, j);
                    i++;
                    Console.WriteLine(m);
                }
                if (input[0] == "size")
                {
                    int m=a.size(i, j);
                    Console.WriteLine(m);

                }
                if (input[0] == "isEmpty")
                {
                    bool m = a.isEmpty(i, j);
                    if (m == true)
                        Console.WriteLine("True");
                    else
                        Console.WriteLine("False");
                }
            }
        }
    }
}
