using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace ConsoleApp2
{
    internal class Program
    {

        private static
            List<Entity.GC_Data> List_Data_GC = new List<Entity.GC_Data>();

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            string Path_File = "D:\\Project\\Visual Studio 2022\\Console\\Console_Test\\ConsoleApp2\\File\\Genom.txt";
            
            var File = new StreamReader(Path_File);

            Entity.GC_Data Data = null;
            string Line = "";
            while ((Line = File.ReadLine()) != null)
            {
                if (Line.Contains(">Rosalind"))
                {
                    if (Data == null)
                    {
                        Data = new Entity.GC_Data()
                        {
                            Name = Line,
                            Count_GC = 0,
                            Length_Str = 0
                        };
                    }
                    else
                    {
                        List_Data_GC.Add(Data);
                        Data = new Entity.GC_Data()
                        {
                            Name = Line,
                            Count_GC = 0,
                            Length_Str = 0
                        };
                    }
                }
                else
                {
                    Data.Count_GC += Count_GC(Line);
                    Data.Length_Str += Line.Length;
                }
            }
            Print(List_Data_GC);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"Time : {sw.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        private static
            int Count_GC(string str)
        {
            int counter = 0;
            foreach (var item in str)
            {
                if (item == 'G'
                    || item == 'C'
                    || item == 'g'
                    || item == 'c')
                {
                    counter++;
                }
            }
            return counter;
        }

        private static 
            void Print(List<Entity.GC_Data> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Name : {item.Name} \t GC-Content : {((double)item.Count_GC/item.Length_Str)*100}%");
            }
        }
    }
}
