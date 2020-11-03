using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_4_v4
{
    class Program
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("D:\\text.txt");
            string line;
           while((line = sr.ReadLine()) != null)
            {
                lineToArr(line);
            }
            sr.Close();
            Console.WriteLine("Исходный массив: ");
            printList();
           changePos();
            Console.WriteLine("Измененный массив: ");
            printList();
            writeToFile();
            
        }

        static void lineToArr(string line)
        {
            string[] arr = line.Split(' ');
            foreach(string str in arr)
            {

                if(!(str.Equals("")))
                {
                    int pars;

                    Int32.TryParse(str,out pars);
                    if((pars == 0 && str.Equals("0")) || pars != 0 )
                    {
                        list.Add(pars);
                    }
                    else
                    {
                        continue;
                    }
                    
                
                }
                
            }
        }

        static void printList()
        {
           
            foreach (int a in list)
            {
                Console.Write(a);
                Console.Write("  ");
            }
            Console.WriteLine();
        }
        static void changePos()
        {

            var min = list.IndexOf( list.Min());
            var max = list.IndexOf(list.Max());
            var temp = list.Min();

            list[min] = list[max];
            list[max] = temp;
        }
        static void writeToFile()
        {
            StringBuilder stringBuider = new StringBuilder();
            foreach(int number in list)
            {
                stringBuider.Append(number);
                stringBuider.Append(' ');
            }
            
            string str = stringBuider.ToString();

            StreamWriter sw = new StreamWriter("D:\\text.txt", false);
            sw.WriteLine(str);
            sw.Close();


        }
    }
}
