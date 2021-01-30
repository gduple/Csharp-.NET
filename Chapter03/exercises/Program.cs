using System;
using static System.Console;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // for (int i = 1; i <= 100; i++)
            // {
            //     if (i % 3 == 0 && i % 5 != 0)
            //     {
            //         Write("Fizz ");
            //     }
            //     else if (i % 5 == 0 && i % 3 != 0)
            //     {
            //         Write("Buzz ");
            //     }
            //     else if (i % 3 == 0 && i % 5 == 0)
            //     {
            //         Write("FizzBuzz ");
            //     }
            //     else
            //     {
            //         Write($"{i} ");
            //     }
            // }

            // byte a = 0;
            // byte b = 0;

            try
            {
                WriteLine("Enter a number between 0 and 255: ");
                byte a = byte.Parse(ReadLine());
                decimal x = a;
                WriteLine("Enter another number between 0 and 255: ");
                byte b = byte.Parse(ReadLine());
                decimal y = b;
                decimal c = Math.Round(x / y, 2, MidpointRounding.AwayFromZero);
                WriteLine($"{a} divided by {b} is {c}");
            }
            catch (FormatException)
            {
                WriteLine("Entry was not a number!");
            }
            catch (OverflowException)
            {
                WriteLine("Entered number was not between 0 and 255!");
            }
            catch
            {
                WriteLine("Oops! Something went wrong.");
            }
        }
    }
}
