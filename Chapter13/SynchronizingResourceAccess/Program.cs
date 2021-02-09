using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace SynchronizingResourceAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Please wait for the tasks to complete.");
            Stopwatch watch = Stopwatch.StartNew();
            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);
            Task.WaitAll(new Task[] { a, b });
            WriteLine();
            WriteLine($"Results: {Message}.");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
        }

        static Random r = new Random();
        static string Message; // a shared resource
        static object conch = new object();

        static void MethodA()
        {
            // lock (conch)
            try
            {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(r.Next(2000));
                        Message += "A";
                        Write(".");
                    }
                }
                else
                {
                    WriteLine("Method A failed to enter a monitor lock.");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }

        }

        static void MethodB()
        {
            // lock (conch)
            try
            {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(r.Next(2000));
                        Message += "B";
                        Write(".");
                    }
                }
                else
                {
                    WriteLine("Method B failed to enter a monitor lock.");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }
    }
}
