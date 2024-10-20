using System;
using System.Linq;
public class Program
{
    public static bool okornot = false;
    public static void changescharacter(string gaam, string matnnahaii,string matn )
    {
        if (!okornot)
        {
            if (matn.Length == 1)
            {
                if (matn == matnnahaii)
                {
                    gaam += matnnahaii;
                    string[] ghadam = gaam.Split(' ');
                    ghadam = ghadam.Distinct().ToArray();
                    foreach (var a in ghadam)
                    {
                        System.Console.WriteLine(a);
                    }
                    okornot = true;
                }
            }
            else
            {
                for (int i = 0; i < matn.Length - 1; i++)
                {
                    gaam =gaam + matn;
                    gaam =gaam + " ";
                    changescharacter(gaam, matnnahaii,changes(i,matn) );
                }
            }
        }
    }
    public static string delete(string matn,char tables, int ind)
    {
        string matnjadid = "";
        for (int i = 0; i < matn.Length; i++)
        {
            if (i == ind)
            {
                matnjadid =matnjadid + tables;
                i += 1;
            }
            else
                matnjadid =matnjadid + matn[i];
        }
        return matnjadid;
    }
    public static void operat(string gaam, string matnnahaii, string matn)
    {
        changescharacter(gaam, matnnahaii,matn);
        if (!okornot)
        {
            System.Console.WriteLine("None exist!");
        }
    }
    public static string changes(int ind,string matn )
    {
        string[] sakhtar = { "aab", "abb", "aca", "bac", "bbb", "bca", "caa", "cbc", "ccc" };
        for (int i = 0; i < sakhtar.Length; i++)
        {
            if (matn[ind] == sakhtar[i][0] && matn[ind + 1] == sakhtar[i][1])
            {
                matn = delete(matn,sakhtar[i][2], ind );
                break;
            }
        }
        return matn;
    }
    public static void Main()
    {
        int op = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= op; i++)
        {
            okornot = false;
            string matn = Console.ReadLine();
            string matnnahaii = Console.ReadLine();
            string gaam = "";
            operat(gaam, matnnahaii,matn);
            if (i != op)
            {
                System.Console.WriteLine();
            }
        }
    }   
}
