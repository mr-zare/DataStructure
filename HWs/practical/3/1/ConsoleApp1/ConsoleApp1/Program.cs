using System;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Node
    {
        public Node leftnode { get; set; }
        public Node rightnode { get; set; }
        public int data { get; set; }
    }
    class Bst
    {
        public Node root { get; set; }

        public int insert(int val)
        {
            Node pish = null;
            Node pas = this.root;
            while (pas != null)
            {
                pish = pas;
                if (pas.data > val)
                {
                    pas = pas.leftnode;
                }
                else
                {
                    pas = pas.rightnode;
                }
            }
            Node jadid = new Node();
            jadid.data = val;
            if (this.root == null)
            {
                root = jadid;
            }
            else
            {
                if (val < pish.data)
                {
                    pish.leftnode = jadid;
                }
                else
                {
                    pish.rightnode = jadid;
                }
            }
            return val;
        }

        public int getmax(Node a)
        {
            Node b = a;
            List<int> m1 = new List<int>();
            List<int> m = new List<int>();
            m = preorder(b, m1);
            int max = m[0];
            return max;
            ///or:
            ///int max=a.data;
            ///return max;
        }
        public int getmin(Node a)
        {
            Node b = a;
            int min = a.data;
            if (b.leftnode != null)
            {
                min = b.leftnode.data;
                a = b.leftnode;
            }
            return min;
        }
        public bool search(Node a, int val)
        {
            if (a == null)
            {
                return false;
            }
            if (a.data == val)
            {
                return true;
            }
            bool b = true;
            if (a.data <= val)
            {
                b = search(a.rightnode, val);
            }
            if (a.data > val)
            {
                b = search(a.leftnode, val);
            }
            return b;
        }
        public List<int> postorder(Node a, List<int> outp)
        {
            if (a.leftnode != null)
            {
                postorder(a.leftnode, outp);
            }
            if (a.rightnode != null)
            {
                postorder(a.rightnode, outp);
            }
            outp.Add(a.data);
            return outp;
        }
        public List<int> preorder(Node a, List<int> outp)
        {
            outp.Add(a.data);
            if (a.leftnode != null)
            {
                preorder(a.leftnode, outp);
            }
            if (a.rightnode != null)
            {
                preorder(a.rightnode, outp);
            }
            return outp;
        }
        public List<int> inorder(Node a, List<int> outp)
        {
            if (a.leftnode != null)
            {
                inorder(a.leftnode, outp);
            }
            outp.Add(a.data);
            if (a.rightnode != null)
            {
                inorder(a.rightnode, outp);
            }
            return outp;
        }
        public void delete(Node a, int val)
        {
            root = del(a, val);
        }
        public Node del(Node b, int val)
        {
            int flag = 0;
            if (b == null)
            {
                return null;
            }
            if (val > b.data)
            {
                b.rightnode = del(b.rightnode, val);
            }
            else if (val < b.data)
            {
                b.leftnode = del(b.leftnode, val);
            }
            else
            {
                flag = 1;
                if (b.leftnode == null)
                {
                    return b.rightnode;
                }
                else if (b.rightnode == null)
                {
                    return b.leftnode;
                }
                b.data = getmin(b.rightnode);
                b.rightnode = del(b.rightnode, b.data);
            }
            return b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            string m1 = Console.ReadLine();
            Bst a = new Bst();
            string[] a1 = (m1.Split(' '));
            for (int i = 0; i < a1.Length; i++)
            {
                int q = a.insert(int.Parse(a1[i]));
            }
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < a1.Length; i++)
            {
                string w1 = Console.ReadLine();
                string[] w = w1.Split(' ');
                if (w[0] == "insert")
                {
                    int q = a.insert(int.Parse(w[1]));
                    Console.WriteLine(q);
                }
                if (w[0] == "getmax")
                {
                    int q = a.getmax(a.root);
                    Console.WriteLine(q);
                }
                if (w[0] == "getmin")
                {
                    int q = a.getmin(a.root);
                    Console.WriteLine(q);
                }
                if (w[0] == "search")
                {
                    bool q = a.search(a.root, int.Parse(w[1]));
                    Console.WriteLine(q);
                }
                if (w[0] == "delete")
                {
                    bool r = a.search(a.root, int.Parse(w[1]));
                    Console.WriteLine(r);
                    a.delete(a.root, int.Parse(w[1]));
                }
                if (w[0] == "inorder")
                {
                    List<int> e = new List<int>();
                    List<int> e1 = a.inorder(a.root, e);
                    for (int j = 0; j < e1.Count; j++)
                    {
                        Console.Write(e1[j] + " ");
                    }
                    Console.WriteLine();
                }
                if (w[0] == "preorder")
                {
                    List<int> e = new List<int>();
                    List<int> e1 = a.preorder(a.root, e);
                    for (int j = 0; j < e1.Count; j++)
                    {
                        Console.Write(e1[j] + " ");
                    }
                    Console.WriteLine();
                }
                if (w[0] == "postorder")
                {
                    List<int> e = new List<int>();
                    List<int> e1 = a.postorder(a.root, e);
                    for (int j = 0; j < e1.Count; j++)
                    {
                        Console.Write(e1[j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}