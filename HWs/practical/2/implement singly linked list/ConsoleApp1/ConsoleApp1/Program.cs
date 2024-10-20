using System;

namespace consoleapp7
{
    public class node
    {
        public node nextval { get; set; }
        public string data { get; }
        public node(string valuee)
        {
            nextval = null;
            data = valuee;
            nextval = null;
        }
    }
    class lls
    {
        node Head;
        public lls()
        {
            Head = null;
        }
        public void Append(string val)
        {
            node neww = new node(val);
            if (Head == null)
            {
                Head = neww;
                return;
            }
            node last = Head;

            while (last.nextval != null)
                last = last.nextval;
            last.nextval = neww;
        }
        public void Insert(string x, int y)
        {
            node neww = new node(x);
            node miani = this.Head;
            int i = 0;
            while (miani.nextval != null && i < y - 1)
            {
                miani = miani.nextval;
                i++;
            }
            node new1 = miani.nextval;
            miani.nextval = neww;
            neww.nextval = new1;
        }
        public void Add(string val)
        {
            node neww = new node(val);
            neww.nextval = Head;
            this.Head = neww;
        }
        public int IndexOf(string key)
        {
            node miani = Head;
            int index = 0;
            while (miani.data != key)
            {
                if (miani == null) return -1;
                miani = miani.nextval;
                index++;
            }
            return index;
        }
        public void Delete(int y)
        {
            node miani = Head;
            int i = 0;
            while (miani.nextval != null && i < y - 1)
            {
                miani = miani.nextval;
                i++;
            }
            miani.nextval = miani.nextval.nextval;
        }
        public string PrintSLL()
        {
            node miani = Head;
            string print = "";
            while (miani.nextval != null)
            {
                print = print + miani.data + " ";
                miani = miani.nextval;
            }

            print += miani.data;
            return print;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            lls sll = new lls();
            string[] inout;
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                inout = line.Split(' ');
                if (inout[0] == "insert")
                {
                    sll.Insert(inout[2], int.Parse(inout[1]));
                }
                if (inout[0] == "append")
                {
                    sll.Append(inout[1]);
                }
                if (inout[0] == "add")
                {
                    sll.Add(inout[1]);
                }
                if (inout[0] == "indexOf")
                {
                    int m = sll.IndexOf(inout[1]);
                    Console.WriteLine(m);
                }
                if (inout[0] == "delete")
                {
                    int m = int.Parse(inout[1]);
                    sll.Delete(m);
                }
                if (inout[0] == "printSLL")
                {
                    string m = sll.PrintSLL();
                    Console.WriteLine(m);
                }
            }

        }
    }
}

