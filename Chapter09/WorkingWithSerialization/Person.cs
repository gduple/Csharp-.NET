using System;
using System.Collections.Generic;

namespace Packt.Shared
{
  public class Person
  {
    public Person() {} /* necessary to avoid exception that Person
    can't be serialized bc it doesn't have a parameterless constructor */
    public Person(decimal initialSalary)
    {
      Salary = initialSalary;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public HashSet<Person> Children { get; set; }
    protected decimal Salary { get; set; }
  }
}