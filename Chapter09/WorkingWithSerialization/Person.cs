using System;
using System.Collections.Generic;
using System.Xml.Serialization;

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

    [XmlAttribute("fname")]
    public string FirstName { get; set; }
    [XmlAttribute("lname")]
    public string LastName { get; set; }
    [XmlAttribute("dob")]
    public DateTime DateOfBirth { get; set; }
    public HashSet<Person> Children { get; set; }
    protected decimal Salary { get; set; }
  }
}