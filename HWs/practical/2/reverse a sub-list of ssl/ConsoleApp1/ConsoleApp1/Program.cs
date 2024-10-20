using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    public class node
    {
        public object valuee;
        public node nextval;
    }

    public class lls
    {
        private node jari;
        private node head;
        public int num;

        public lls()
        {
            head = new node();
            jari = head;
        }

        public void addakhar(object data)
        {
            if (!(head.valuee == null && head.nextval == null))
            {
                node jari = head;
                while (jari.nextval != null)
                {
                    jari = jari.nextval;
                }
                jari.nextval = new node() { valuee = data, nextval = null };
                return;
            }
            else
            {
                num++;
                head = new node() { valuee = data, nextval = null };
                return;
            }
        }
        public string print()
        {
            string outp = head.valuee + " ";
            node jarii = head;
            while (jarii.nextval != null)
            {
                jarii = jarii.nextval;
                if (jarii.valuee != null)
                    outp += jarii.valuee + " ";
            }
            return outp;
        }

        public void Insert(int n, object data)
        {
            node jari = head;
            for (int i = 1; i <= n-1; i++)
            {
                jari = jari.nextval;
            }
            if (n != 0)
            {
                node miani = new node() { valuee = data, nextval = jari.nextval };
                jari.nextval = miani;
            }
            else
            {
                node new1 = new node() { valuee = data, nextval = head };
                head = new1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] input = line.Split();
            string line2 = Console.ReadLine();
            string[] input2 = line2.Split();
            lls lls1 = new lls();
            int a = int.Parse(input2[0]);
            int b = int.Parse(input2[1]);
            for (int i = 0; i < input.Length; i++)
            {
                if (i >b || i < a)
                {
                    lls1.addakhar(input[i]);
                }
            }
            for (int j =a; j <=b; j++)
            {
                lls1.Insert(a,input[j]);
            }
            Console.WriteLine(lls1.print());
        }
    }
}
