using System;
using System.Linq;
using Packt.Shared;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine( "Processing. Please wait..." );
            Recorder.Start();

            // simulate a process that requires some memory resources...
            int[] largeArrayOfInts =
                Enumerable.Range(1, 10_000).ToArray();

            // ...and takes some time to complete
            System.Threading.Thread.Sleep(
                new Random().Next( 5, 10 ) * 1000 );

            Recorder.Stop();
        }
    }
}
