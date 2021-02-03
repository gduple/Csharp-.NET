using System;
using static System.Console;

namespace WorkingWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "London";
            WriteLine($"{city} is {city.Length} characters long.");

            WriteLine($"First char is {city[0]} and third is {city[2]}.");

            string cities = "Paris,Berlin,Madrid,New York";

            string[] citiesArray = cities.Split(',');

            foreach (string item in citiesArray)
            {
                WriteLine(item);
            }

            string fullName = "Alan Jones";
            int indexOfTheSpace = fullName.IndexOf(' ');

            string firstName = fullName.Substring(
                startIndex: 0, length: indexOfTheSpace
            );

            string lastName = fullName.Substring(
                startIndex: indexOfTheSpace + 1
            );

            WriteLine($"{lastName}, {firstName}");

            string company = "Microsoft";

            bool startsWithM = company.StartsWith("M");

            bool containsN = company.Contains("N");

            bool endsWithT = company.EndsWith("t");

            WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}, ends with T: {endsWithT}");
                
        }
    }
}
