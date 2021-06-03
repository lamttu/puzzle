using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class Extension
    {
        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, int partitions, Func<T, Task> body)
        {
            async Task AwaitPartition(IEnumerator<T> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { await body(partition.Current); }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(partitions)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)));
        }
    }
}