// 1. Afprøv og undersøg programmet: 3c.Opgave 1.cs fra CsharpExercises projektet (henter processer fra din pc).
// 2. Omskriv programmet så du benytter Implicitly typed local variables og Object Initializer
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CsharpExercises
{
    static class Opgave_1
    {
        delegate Boolean Predicate<T>(T obj);

        static void Main(string[] args)
        {
            
            DisplayProcesses(Filter);
        }

        static void DisplayProcesses(Predicate<long> x)
        {
            var processes = new List<ProcessData>();

            var ps = new[] {
                new { Id = 1, Name = "Hat", Memory = 111 },
                new { Id = 2, Name = "Cat", Memory = 222 },
                new { Id = 3, Name = "Mat", Memory = 333 },
            };
            foreach (object p in ps)
            {
            }
            foreach (Process process in Process.GetProcesses())
            {
                if (process.WorkingSet64 >= 20 * 1024 * 1024)
                {
                    var newProcess = new ProcessData { Id = process.Id, Name = process.ProcessName, Memory = process.WorkingSet64 };
                    //newProcess.Id = process.Id;
                    //newProcess.Name = process.ProcessName;
                    //newProcess.Memory = process.WorkingSet64;
                    processes.Add(newProcess);
                }
                
            }

            List<long> memList = new List<long>();
            
            foreach (ProcessData item in processes)
            {
                if (Filter(item.Memory))
                Console.WriteLine("Id: {0} - Name: {1} - Memory: {2}", item.Id, item.Name, item.Memory);
                memList.Add(item.Memory);
                
            }

            long totalMem = SumMemory(memList.ToArray());
            Console.WriteLine("Total Memory Used: " + totalMem);
            long highestMem = SumHighestMem(memList.ToArray());
            Console.WriteLine("Total of heaviest 2 loads: " + highestMem);
        }
        private static Boolean Filter(long x)
        {
            return x > 99999999;
        }
        private static long SumMemory(this IEnumerable<long> memoryArr)
        {
            long res = 0;
            foreach (long number in memoryArr)
            {
                res += number;
            }
            return res;
        }
        private static long SumHighestMem(this IEnumerable<long> memoryArr)
        {
            return memoryArr.OrderByDescending(n => n).Take(2).Sum(n => n);
           
        }
    }

    class ProcessData
    {
        public int Id { get; set; }
        public long Memory { get; set; }
        public string Name { get; set; }
    }
}
