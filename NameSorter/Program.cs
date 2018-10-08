using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person(lastName, givenNames);

            // Define variables
            //List<string> listOfNames = new List<string>();
            string lastName = "", givenNames = "";
            Person person = new Person(lastName, givenNames);
            //Person p = new Person(lastName, givenNames);
            List<Person> listOfPeople = new List<Person>();

            //// Read names from file
            using (StreamReader reader = new StreamReader(args[0]))
            {
                String line;

                Console.WriteLine("Unsorted list of people //////////////////////////");
                while ((line = reader.ReadLine()) != null)
                {                   
                    int index = line.LastIndexOf(' ');

                    // Split the name in to two strings at the last occurence of ' '
                    string[] splitName = new string[] { line.Substring(0, index), line.Substring(index + 1) };

                    person.lastName = splitName[1];
                    person.givenNames = splitName[0];

                    listOfPeople.Add(person);
                    
                    Console.WriteLine(person.lastName + ", " + person.givenNames);           
                }
            }

            Console.WriteLine();




            List<Person> sortedList = listOfPeople.OrderByDescending(p => p.lastName).ToList();
            Person poo = new Person(lastName, givenNames);
            sortedList.ForEach(Console.WriteLine(poo.givenNames));

            //foreach (Person p2 in sortedList)
            //{
            //    Console.WriteLine(p2.lastName); 
            //}



            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }
    }
}
