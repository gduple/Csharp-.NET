using static System.Convert;
using System;
using static System.Console;

namespace CastingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // int a = 10;
            // double b = a; // an int can be safely cast into a double
            // WriteLine(b);

            // double c = 9.8;
            // int d = (int)c;
            // WriteLine(d); // d is 9 losing the .8 part

            // long e = 10;
            // int f = (int)e;
            // WriteLine($"e is {e:N0} and f is {f:N0}");
            // // e = long.MaxValue;
            // e = 5_000_000_000;
            // f = (int)e;
            // WriteLine($"e is {e:N0} and f is {f:N0}");

                // double g = 9.8;
                // int h = ToInt32(g);
                // WriteLine($"g is {g} and h is {h}");

            // double[] doubles = new[]
            //     { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };
            
            // foreach(double n in doubles)
            // {
            //     WriteLine($"ToInt({n}) is {ToInt32(n)}");
            // }

            // foreach (double n in doubles)
            // {
            //     WriteLine(format:
            //         "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
            //         arg0: n,
            //         arg1: Math.Round(value: n, digits: 0,
            //                 mode: MidpointRounding.AwayFromZero));
            // }

                // int number = 12;
                // WriteLine(number.ToString());

                // bool boolean = true;
                // WriteLine(boolean.ToString());

                // DateTime now = DateTime.Now;
                // WriteLine(now.ToString());

                // object me = new object();
                // WriteLine(me.ToString());

            // // allocate the array of 128 bytes
            // byte[] binaryObject = new byte[128];

            // // populate the array with random bytes
            // (new Random()).NextBytes(binaryObject);

            // WriteLine("Binary Object as bytes:");

            // for(int index = 0; index < binaryObject.Length; index++)
            // {
            //     Write($"{binaryObject[index]:X} ");
            // }
            // WriteLine();

            // // convert to Base64 string and output as text
            // string encoded = Convert.ToBase64String(binaryObject);

            // WriteLine($"Binary Object as Base64: {encoded}");

                // int age = int.Parse("37");
                // DateTime birthday = DateTime.Parse("24 January 1984");

                // WriteLine($"I was born {age} years ago.");
                // WriteLine($"My birthday is {birthday}.");
                // WriteLine($"My birthday is {birthday:D}.");

                // int count = int.Parse("abc");

            Write("How many eggs are there? ");
            int count;
            string input = ReadLine();

            if (int.TryParse(input, out count))
            {
                WriteLine($"There are {count} eggs.");
            }
            else
            {
                WriteLine("I could not parse the input.");
            }
        }
    }
}
