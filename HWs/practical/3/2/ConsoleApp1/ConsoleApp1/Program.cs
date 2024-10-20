using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        class Person
        {
            public string name;
            public int age;
            public float weight;
            public string gender;
            public Person(string names,int ages,float weights,string genders)
            {
                name = names;
                age = ages;
                weight = weights;
                gender = genders;
            }
        }
        class Node
        {
            public Node leftnode { get; set; }
            public Node rightnode { get; set; }
            public Person data { get; set; }    
        }
        class bst
        {
            public Node root =new Node();
            public Person Insert(string names, int ages, float weights, String genders)
            {
                int i = 0;
                Person m = new Person(names, ages, weights, genders);
                
                Node pish = null;
                Node pas = this.root;
                if(root.data ==null)
                {
                    root.data = m;
                    return m;
                }
                while (pas != null)
                {
                    i = i % 4;
                    if (i == 0)
                    {
                        i++;
                        pish = pas;
                        if (string.Equals(genders, "M"))
                        {
                            pas = pas.leftnode;
                        }
                        else
                        {
                            pas = pas.rightnode;
                        }
                    }
                    if (i == 1 && pas != null)
                    {
                        i++;
                        pish = pas;
                        if (pas.data.age >ages)
                        {
                            pas = pas.leftnode;
                        }
                        else
                        {
                            pas = pas.rightnode;
                        }
                    }
                    if (i == 2 && pas != null)
                    {
                        i++;
                        pish = pas;
                        if (pas.data.weight > weights)
                        {
                            pas = pas.leftnode;
                        }
                        else
                        {
                            pas = pas.rightnode;
                        }
                    }
                    if (i == 3 && pas != null)
                    {
                        pish = pas;
                        if (string.Compare(names,pas.data.name)<0)
                        {
                            pas = pas.leftnode;
                        }
                        else
                        {
                            pas = pas.rightnode;
                        }
                    }
                }
                Node jadid = new Node();
                jadid.data = m;
                if (this.root == null)
                {
                    root = jadid;
                }
                else
                {
                    i = i % 4;
                    if (i == 0)
                    {
                        if (string.Equals(genders, "M"))
                        {
                            pish.leftnode =jadid;
                        }
                        else
                        {
                            pish.rightnode = jadid;
                        }
                        
                    }
                    if (i == 1 )
                    {
                        if (pish.data.age > ages)
                        {
                            pish.leftnode = jadid;
                        }
                        else
                        {
                            pish.rightnode = jadid;
                        }
                    }
                    if (i == 2)
                    {
                        if (pish.data.weight > weights)
                        {
                            pish.leftnode = jadid;
                        }
                        else
                        {
                            pish.rightnode = jadid;
                        }
                    }
                    if (i == 3)
                    {
                        if (string.Compare(names, pas.data.name) < 0)
                        {
                            pish.leftnode = jadid;
                        }
                        else
                        {
                            pish.rightnode = jadid;
                        }
                    }
                    i++;
                }
                return m;
            }
            public bool Delete(Node a, string names, int? ages, float? weights, string genders)
            {
                Node b = a;
                Node m = del(root,names,ages,weights, genders);
                if (m == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public Node del(Node a,string names, int? ages, float? weights, String genders)
            {
                int f = 0;
                if(root ==null)
                {
                    f = 1;
                    return null;
                }
                if((string.Equals(a.data.gender,genders) || a.data.gender == null) && (a.data.age == ages || a.data.age == null) && (a.data.weight == weights || a.data.weight == null) && 
                    (a.data.name == names || a.data.name == null))
                {
                    if (a.leftnode == null)
                    {
                        f = 1;
                        a=a.rightnode;
                        return a;
                    }
                    else if (a.rightnode == null)
                    {
                        f = 1;
                        a=a.leftnode;
                        return a;
                    }
                    a.data = getmax(a.rightnode);
                    a.rightnode = del(a.rightnode, a.data.name,a.data.age,a.data.weight,a.data.gender);
                }
                if (genders != null)
                {
                    if (string.Equals(genders, "M"))
                    {
                        a = a.leftnode;
                    }
                    else
                    {
                        a = a.rightnode;
                    }
                    if (ages != null)
                    {
                        if (ages == a.data.age)
                        {
                            if ((a.data.weight == weights || a.data.weight == null) &&
                                (a.data.name == names || a.data.name == null))
                            {
                                if (a.leftnode == null)
                                {
                                    f = 1;
                                    a = a.rightnode;
                                    return a;
                                }
                                else if (a.rightnode == null)
                                {
                                    f = 1;
                                    a = a.leftnode;
                                    return a;
                                }
                                a.data = getmax(a.rightnode);
                                a.rightnode = del(a.rightnode, a.data.name, a.data.age, a.data.weight, a.data.gender);
                            }
                        }
                        if (ages < a.data.age)
                        {
                            a = a.leftnode;
                        }
                        else
                        {
                            a = a.rightnode;
                        }
                    }
                    if(ages == null)
                    {
                        if(weights == a.data.weight )
                        {
                            if(a.data.name == names || a.data.name == null)
                            {
                                if (a.leftnode == null)
                                {
                                    f = 1;
                                    a = a.rightnode;
                                    return a;
                                }
                                else if (a.rightnode == null)
                                {
                                    f = 1;
                                    a = a.leftnode;
                                    return a;
                                }
                                a.data = getmax(a.rightnode);
                                a.rightnode = del(a.rightnode, a.data.name, a.data.age, a.data.weight, a.data.gender);
                            }
                            if(string.Compare(names,a.data.name)<0)
                            {
                                a = a.leftnode;
                            }
                            else
                            {
                                a = a.rightnode;
                            }
                        }
                    }
                    
                }
                else
                {
                    if (ages != null)
                    {
                        if (ages == a.data.age)
                        {
                            if ((a.data.weight == weights || a.data.weight == null) &&
                                (a.data.name == names || a.data.name == null))
                            {
                                if (a.leftnode == null)
                                {
                                    f = 1;
                                    a = a.rightnode;
                                    return a;
                                }
                                else if (a.rightnode == null)
                                {
                                    f = 1;
                                    a = a.leftnode;
                                    return a;
                                }
                                a.data = getmax(a.rightnode);
                                a.rightnode = del(a.rightnode, a.data.name, a.data.age, a.data.weight, a.data.gender);
                            }
                        }
                        if (ages < a.data.age)
                        {
                            a = a.leftnode;
                        }
                        else
                        {
                            a = a.rightnode;
                        }
                    }
                    if (ages == null)
                    {
                        if (weights == a.data.weight)
                        {
                            if (a.data.name == names || a.data.name == null)
                            {
                                if (a.leftnode == null)
                                {
                                    f = 1;
                                    a = a.rightnode;
                                    return a;
                                }
                                else if (a.rightnode == null)
                                {
                                    f = 1;
                                    a = a.leftnode;
                                    return a;
                                }
                                a.data = getmax(a.rightnode);
                                a.rightnode = del(a.rightnode, a.rightnode.data.name, a.rightnode.data.age, a.rightnode.data.weight, a.rightnode.data.gender);
                            }
                            if (string.Compare(names, a.data.name) < 0)
                            {
                                a = a.leftnode;
                            }
                            else
                            {
                                a = a.rightnode;
                            }
                        }
                    }
                }
                if(f==1)
                {
                    return a;
                }
                else if(f==0 && ( a.leftnode !=null || a.rightnode !=null))
                {
                    a = del(a,names,ages,weights,genders);
                }
                else if(f==0 && a.leftnode == null && a.rightnode == null)
                {
                    return null;
                }
                return null;
            }
            public Person getmax(Node a)
            {
                Node b = a;
                List<Person> m1 = new List<Person>();
                List<Person> m = new List<Person>();
                m = preorder(b, m1);
                Person max = m[0];
                return max;
                ///or:
                ///int max=a.data;
                ///return max;
            }
            public List<Person> preorder(Node a, List<Person> outp)
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



            public List<Person> Search(Node a,List<Person> m,string names, int? ages, float? weights, string genders)
            {
                if (root == null)
                {
                    return null;
                }
                if ((a.data.gender == genders || a.data.gender == null) && (a.data.age == ages || a.data.age == null) && (a.data.weight == weights || a.data.weight == null) &&
                    (a.data.name == names || a.data.name == null))
                {
                    m.Add(a.data);
                }
                if (genders != null)
                {
                    if (string.Equals(genders,"M"))
                    {
                        a = a.leftnode;
                    }
                    else
                    {
                        a = a.rightnode;
                    }
                    if (ages != null)
                    {
                        if (ages == a.data.age)
                        {
                            if ((a.data.weight == weights || a.data.weight == null) &&
                                (a.data.name == names || a.data.name == null))
                            {
                                m.Add(a.data);

                            }
                        }
                        if (ages < a.data.age)
                        {
                            a = a.leftnode;
                        }
                        else
                        {
                            a = a.rightnode;
                        }
                    }
                    if (ages == null)
                    {
                        if (weights == a.data.weight)
                        {
                            if (a.data.name == names || a.data.name == null)
                            {
                                m.Add(a.data);
                            }
                            if (string.Compare(names, a.data.name) < 0)
                            {
                                a = a.leftnode;
                            }
                            else
                            {
                                a = a.rightnode;
                            }
                        }
                    }

                }
                else
                {
                    if (ages != null)
                    {
                        if (ages == a.data.age)
                        {
                            if ((a.data.weight == weights || a.data.weight == null) &&
                                (a.data.name == names || a.data.name == null))
                            {
                                m.Add(a.data);
                            }
                        }
                        if (ages < a.data.age)
                        {
                            a = a.leftnode;
                        }
                        else
                        {
                            a = a.rightnode;
                        }
                    }
                    if (ages == null)
                    {
                        if (weights == a.data.weight)
                        {
                            if (a.data.name == names || a.data.name == null)
                            {
                                m.Add(a.data);
                            }
                            if (string.Compare(names, a.data.name) < 0)
                            {
                                a = a.leftnode;
                            }
                            else
                            {
                                a = a.rightnode;
                            }
                        }
                    }
                }

                if (a.leftnode != null || a.rightnode != null)
                {
                    m = Search(a,m,names, ages, weights, genders);
                }
                return m;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bst tree = new bst();
            for(int i=0;i<n;i++)
            {
                string in1= Console.ReadLine();
                string[] inp = in1.Split(' ');
                Person a =tree.Insert(inp[0], int.Parse(inp[1]), float.Parse(inp[2]), inp[3]);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string in1 = Console.ReadLine();
                string[] inp = in1.Split(' ');
                if (inp[0] == "Insert")
                {
                    Person a =tree.Insert(inp[1], int.Parse(inp[2]), float.Parse(inp[3]), inp[4]);
                    Console.WriteLine(inp[1] + " " + inp[2] + " " + inp[3] + " " + inp[4]);
                }
                if(inp[0]=="Search")
                {
                    List<Person> out1 = new List<Person>();
                    string inp1,inp4;
                    int? inp2;
                    float? inp3;
                    if(string.IsNullOrEmpty(inp[1]))
                    {
                        inp1 = null;
                    }
                    else
                    {
                        inp1 = inp[1];
                    }
                    if (string.IsNullOrEmpty(inp[2]))
                    {
                        inp2 = null;
                    }
                    else
                    {
                        inp2 =int.Parse(inp[2]);
                    }
                    if (string.IsNullOrEmpty(inp[3]))
                    {
                        inp3 = null;
                    }
                    else
                    {
                        inp3 =float.Parse(inp[3]);
                    }
                    if (string.IsNullOrEmpty(inp[4]))
                    {
                        inp4 = null;
                    }
                    else
                    {
                        inp4 = inp[4];
                    }
                    out1 = tree.Search(tree.root, out1, inp1,inp2,inp3,inp4);
                    for(int j=0;j<out1.Count;j++)
                    {
                        Console.WriteLine("( "+out1[i].name + " " + out1[i].age + " " + out1[i].weight + " " + out1[i].gender+" )");
                    }
                }
                if(inp[0]=="Delete")
                {
                    string inp1,inp4;
                    int? inp2;
                    float? inp3;
                    if (string.IsNullOrEmpty(inp[1]))
                    {
                        inp1 = null;
                    }
                    else
                    {
                        inp1 = inp[1];
                    }
                    if (string.IsNullOrEmpty(inp[2]))
                    {
                        inp2 = null;
                    }
                    else
                    {
                        inp2 = int.Parse(inp[2]);
                    }
                    if (string.IsNullOrEmpty(inp[3]))
                    {
                        inp3 = null;
                    }
                    else
                    {
                        inp3 = float.Parse(inp[3]);
                    }
                    if (string.IsNullOrEmpty(inp[4]))
                    {
                        inp4 = null;
                    }
                    else
                    {
                        inp4= inp[4];
                    }
                    bool t = tree.Delete(tree.root,inp1, inp2,inp3,inp4);
                    Console.WriteLine(t);
                }
            }
        }
    }
}
