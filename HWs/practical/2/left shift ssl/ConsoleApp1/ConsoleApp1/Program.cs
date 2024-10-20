using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    public class node
    {
        public node nextval;
        public object Val;
    }

    public class lls
    {
        private node head;
        private node jari;
        public int num;

        public lls()
        {
            head = new node();
            jari = head;
        }

        public void addakhar(object data)
        {
            if (!(head.Val == null && head.nextval == null))
            {
                node jari = head;
                while (jari.nextval != null)
                {
                    jari = jari.nextval;
                }
                jari.nextval = new node() { Val =data, nextval = null };
                return;
            }
            else
            {
                num++;
                head = new node() { Val = data, nextval = null };
                return;
            }
        }

        public void addaval(object data)
        {
            if (head != null)
            {
                num++;
                node jadid = new node() { Val = data };
                jadid.nextval = head;
                head = jadid;
            }
            else
            {
                num++;
                head = new node() { Val = data, nextval = null };
            }
        }

        public node Delete(int j)
        {
            if (j != 0)
            {
                node jari = head;
                for (int i = 1; i <= j; i++)
                {
                    jari = jari.nextval;
                }
                jari.nextval = jari.nextval.nextval;
                return head;
            }
            else
            {
                head = head.nextval;
                return head;
            }

        }

        public string print()
        {
            string outp = head.Val + " ";
            node jar = head;
            while (jar.nextval != null)
            {
                jar = jar.nextval;
                if (jar.Val != null)
                    outp += jar.Val + " ";
            }
            return outp;
        }

        public int Find(object dade)
        {
            int y = 0;
            node jari = head;
            while (jari.nextval != null)
            {
                jari = jari.nextval;
                if (jari.Val != null)
                    y += 1;
            }
            return y;
        }

        public void Insert(int m, object data)
        {
            node jari = head;
            for (int i = 1; i < m; i++)
            {
                jari = jari.nextval;
            }
            if (m != 0)
            {
                node t2 = new node() { Val = data, nextval = jari.nextval };
                jari.nextval = t2;
            }
            else
            {
                node new1 = new node() { Val = data, nextval = head };
                head = new1;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = Convert.ToInt32(Console.ReadLine()) % input.Length;
            lls lls1 = new lls();

            for (int i = n; i < n + input.Length; i++)
            {
                lls1.addakhar(input[i % input.Length]);
            }
            Console.WriteLine(lls1.print());

        }
    }
}
