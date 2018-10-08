using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter
{
    public class Person
    {
        public string lastName { get; set; }
        public string givenNames { get; set; }
        //private static List<Person> people = new List<Person>();

        public Person(string lastName, string givenNames)
        {
            this.lastName = lastName;
            this.givenNames = givenNames;

            
        }
    }
}
