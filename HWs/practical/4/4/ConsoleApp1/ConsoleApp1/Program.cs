using System;
using System.Linq;
using System.Collections.Generic;

namespace consoleapp1
{
    class Program
    {
        static int minimum = int.MaxValue;
        static int ss;
        struct ability
        {
            public int a, b;

            public ability(int a, int b)
            {
                this.b = b;
                this.a = a;
            }
        }
        static List<List<ability>> makegp(List<List<ability>> val, int ind)
        {
            List<List<ability>> temp = new List<List<ability>>();
            for (int i = 0; i < val.Count; i++)
            {
                if (i == ind)
                    temp.Add(val[i].Concat(val[i + 1]).ToList());
                else if (i == ind + 1)
                    continue;
                else
                    temp.Add(val[i]);
            }
            return temp;
        }
        class node
        {
            public List<List<ability>> val;
            public node before;
            public List<node> group = new List<node>();

            public node(List<List<ability>> value,node qabl)
            {
                this.val = value;
                this.before = qabl;
            }
            public int mohasebecost()
            {
                int before = 0;
                int pay = 0;
                for (int i = 0; i < val.Count; i++)
                {
                    int sum = val[i].Sum(x => x.b) + before + ss;
                    before = sum;

                    for (int j = 0; j < val[i].Count; j++)
                        pay = pay + sum * val[i][j].a;
                }
                return pay;
            }
        }
        static void find(node jari)
        {
            for (int i = 0; i < jari.val.Count - 1; i++)
                jari.group.Add(new node(makegp(jari.val, i),jari));

            int pay = jari.mohasebecost();
            if (pay < minimum)
                minimum = pay;

            if (jari.val.Count == 2)
            {
                return;
            }
            else
                foreach (var x in jari.group)
                    find(x);
        }
        static void Main(string[] args)
        {
            string q = Console.ReadLine();
            int n = int.Parse(q);
            string q2 = Console.ReadLine();
            ss = int.Parse(q2);

            ability[] ab = new ability[n];
            for (int i = 0; i < n; i++)
            {
                string m = Console.ReadLine();
                string[] vorodi = m.Split(' ');
                int t1 = int.Parse(vorodi[1]);
                int t2 = int.Parse(vorodi[0]);
                ab[i] = new ability(t1,t2);
            }
            List<List<ability>> all = new List<List<ability>>();
            foreach(var abil in ab)
            {
                List<ability> temp = new List<ability> { abil };
                all.Add(temp);
            }
            node aval = new node(all,null);
            find(aval);
            Console.WriteLine(minimum);
        }
    }
}
