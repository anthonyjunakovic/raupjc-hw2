using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment5
{

    public class Program
    {
        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished. Executing Thread : {1}", taskName,
            Thread.CurrentThread.ManagedThreadId);
        }

        public static void Main(string[] Argumnets)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(
                () => LongOperation("A"),
                () => LongOperation("B"),
                () => LongOperation("C"),
                () => LongOperation("D"),
                () => LongOperation("E")
            );
            stopwatch.Stop();
            Console.WriteLine("Parallel long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();
        }
    }
}
