using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 100).ToList();
            numbers.ParallelForEachAsync(10, async number =>
            {
                var writtenNumbers = new List<int>();
                Console.WriteLine($"Writing number {number}");
                Thread.Sleep(1);
                Console.WriteLine($"Finished writing number {number}");
            });
        }
    }
}