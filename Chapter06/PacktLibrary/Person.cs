using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        // static method to "multiply"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        // instance method to "multiply"
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        // operator to "multiply"
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        // method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                    $"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localNumber) // local function
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }

        }

        // public delegate field
        public event EventHandler Shout;

        // data field
        public int AngerLevel;
        
        // method
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // if something is listening...
                if (Shout != null)
                {
                    // ...then call the delegate
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // compare the Name Lengths...
            int result = x.Name.Length.CompareTo(y.Name.Length);

            // ...if they are equal...
            if (result == 0)
            {
                // ...then compare by the Names...
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // ...otherwise compare by the Lengths
                return result;
            }
        }
    }

    public class Thing
    {
        public object Data = default(object);

        public string Process(object input)
        {
            if (Data == input)
            {
                return "Data and input are the same.";
            }
            else
            {
                return "data and input are NOT the same.";
            }
        }
    }

}
