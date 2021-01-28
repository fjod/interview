using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MemoryTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int i = 0;
            while (i < 100000)
            {
                var range = Enumerable.Range(0, 10000);
                List<int> test = new List<int>();
                foreach (var i1 in range)
                {
                    test.Add(i1);
                }
                Console.Write(test.Sum() + " ");
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(300);
                i++;
            }

            
        }
    }
}