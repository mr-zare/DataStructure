using System;

namespace ConsoleApp1
{
    class Program
    {
        public static int[] insertion(int[] f1)
        {
            int key,j;
            for (int k = 1; k <= f1.Length - 1; k++)
            {
                key = f1[k];
                j = k - 1;
                while (j >= 0 && f1[j] > key)
                {
                    f1[j + 1] = f1[j];
                    j--;
                }
                f1[j + 1] = key;
            }
            return f1;
        }
        public static int[] insertiondesc(int[] f1)
        {
            int key,flag;
            for(int i=1;i<f1.Length;i++)
            {
                key = f1[i];
                flag = 0;
                for(int j=i-1;j>=0 && flag==0;)
                {
                    if (key > f1[j])
                    {
                        f1[j + 1] = f1[j];
                        j--;
                        f1[j + 1] = key;
                    }
                    else
                        flag = 1;
                }
            }
            return f1;      
        }
        public static Boolean is_sorted(bool t)
        {
            int[] f1 = Program.makeaaray();
            int[] f2 = new int[f1.Length];
            Array.Copy(f1, f2, f1.Length);
            f2 = Program.insertion(f2);
            if (t==true)
            {
                int[] f3 = new int[f2.Length];
                int h = 0;
                for (int k = f2.Length - 1; k >= 0; k--)
                {
                    f3[h] = f2[k];
                    h++;
                }
                Array.Copy(f3, f2, f3.Length);
            }
            bool booll = true;
            for (int k = 0; k < f2.Length; k++)
            {
                if (f2[k] != f1[k])
                    booll = false;
            }
            return booll;
        }
        public static int[] get_histogram(string bin)
        {
            int[] f1 = Program.makeaaray();
            f1 = Program.insertion(f1);
            int length = (int)Math.Ceiling(((double)f1[f1.Length - 1] - (double)f1[0]) / double.Parse(bin));
            int bins = int.Parse(bin);
            int[] num = new int[bins];
            for (int k = 0; k < bins; k++)
            {
                num[k] = 0;
            }
            for (int k = 0; k < f1.Length; k++)
            {
                int ee = 0;

                for (int e = 0; e < bins; e++)
                {
                    if (ee != (bins - 1))
                    {
                        if ((f1[0] + ee * length) <= f1[k] && (f1[0] + (ee + 1) * length) > f1[k])
                        {
                            num[ee]++;
                        }
                    }
                    else
                    {
                        if ((f1[0] + ee * length) <= f1[k] && (f1[0] + (ee + 1) * length) >= f1[k])
                        {
                            num[ee]++;
                        }
                    }
                    ee++;
                }
            }
            return num;
        }

        public static int[] sort(bool t)
        {
            int[] f1 = Program.makeaaray();
            if(t==true)
            {
                f1 = Program.insertiondesc(f1);
            }
            else
                f1 = Program.insertion(f1);

            return f1;
        }
        public static int getmax()
        {
            int[] f1 = Program.makeaaray();
            f1 = Program.insertion(f1);
            return f1[f1.Length - 1];
        }
        public static int[] makeaaray()
        {
            string t = Console.ReadLine();
            string[] f = new string[100];
            f = t.Split(' ');
            int[] f1 = new int[f.Length];
            for (int k = 0; k < f.Length; k++)
            {
                f1[k] = int.Parse(f[k]);
            }
            return f1;
        }

        public static int[] appendsorted(string w)
        {
            int[] f1 = Program.makeaaray();
            f1 = Program.insertion(f1);
            int[] f2 = new int[f1.Length + 1];
            int adad = int.Parse(w);
            if (f1[0] >= adad)
            {
                f2[0] = adad;
                for (int k = 1; k < f1.Length + 1; k++)
                {
                    f2[k] = f1[k - 1];
                }
            }
            else if (f1[f1.Length - 1] <= adad)
            {
                f2[f1.Length] = adad;
                for (int k = 0; k < f1.Length; k++)
                {
                    f2[k] = f1[k];
                }
            }
            else
            {
                for (int k = 0; k < f1.Length - 1; k++)
                {
                    if (f1[k] <= adad && f1[k + 1] >= adad)
                    {
                        int j = 0;
                        for (j = 0; j <= k; j++)
                        {
                            f2[j] = f1[j];
                        }
                        f2[j] = adad;
                        for (int q = j + 1; q < f2.Length; q++)
                        {
                            f2[q] = f1[q - 1];
                        }
                        break;
                    }
                }
            }
            return f2;
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = new string[2],output=new string[n];
            string m;
            for(int i=0;i<n;i++)
            {
                m = Console.ReadLine();
                input = m.Split(' ');
                if (input[0] == "SORT")
                {
                    bool t;
                    if(Array.Exists(input, element => element == "DESCENDING"))
                    {
                        t = true;
                    }
                    else
                    {
                        t = false;
                    }
                    int[] f1 = sort(t);
                    for (int k = 0; k < f1.Length; k++)
                    {
                        string q = f1[k].ToString();
                        if (k == f1.Length - 1)
                        {
                            output[i] += q;
                        }
                        else
                        {
                            output[i] += q + " ";
                        }
                    }
                }
                if(input[0]== "IS_SORTED")
                {
                    bool t;
                    if (Array.Exists(input, element => element == "DESCENDING"))
                    {
                        t = true;
                    }
                    else
                    {
                        t = false;
                    }
                    bool booll = is_sorted(t);
                    if (booll == false)
                        output[i] = "NO";
                    else
                        output[i] = "YES";
                }
                if (input[0] == "GETMAX")
                {
                    output[i] = getmax().ToString();
                }
                if (input[0] == "GET_HISTOGRAM")
                {
                    int[] num=get_histogram(input[1]);
                    for(int k=0;k<num.Length;k++)
                    {
                        if(k!=(num.Length-1))
                            output[i] += num[k] + " ";
                        else
                        {
                            output[i] += num[k];
                        }
                    }
                }
                if (input[0] == "APPEND")
                {
                    int[] f2 = appendsorted(input[1]);
                    for (int k = 0; k < f2.Length; k++)
                    {
                        if (k != f2.Length - 1)
                            output[i] += f2[k] + " ";
                        else
                            output[i] += f2[k];
                    }
                }
            }
            for(int i=0;i<n;i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
