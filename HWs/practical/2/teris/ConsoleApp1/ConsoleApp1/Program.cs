using System;
using System.Collections.Generic;
using System.Collections;
namespace ConsoleApp1
{
    class Program
    {
        public class stack
        {
            string[] stack1 = new string[1000];

            public string peek(int i)
            {

                return stack1[i - 1];
            }
            public int size(int i)
            {
                return i;
            }
            public bool isEmpty(int i)
            {
                if (i == 0)
                    return true;
                else
                    return false;
            }
        }
        static void Main(string[] args)
        {
            List<string> listolgo = new List<string>();
            listolgo.Add("by");
            listolgo.Add("vs");
            listolgo.Add("cs");
            listolgo.Add("cp");
            listolgo.Add("to");
            listolgo.Add("py");
            listolgo.Add("md");
            listolgo.Add("cd");
            listolgo.Add("js");
            listolgo.Add("as");
            string input, amel;
            input = Console.ReadLine();

            for (int i = 0; i < input.Length - 1; i++)
            {
                amel = input[i].ToString() + input[i + 1].ToString();
                if (listolgo.Contains(amel))
                {
                    input = input.Replace(amel, "");
                    i = 0;
                }
            }
            Console.WriteLine(input);
        }
    }
}