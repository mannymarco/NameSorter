using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//NAMESORTER DOTNET FRAMWORK NOT CORE
namespace NameSorterProject
{
    public class NameSorter
    {
        static List<Person> unsortedList;
        static List<Person> sortedList;
        static List<Person> omittedList;

        static string startDirectory = Directory.GetCurrentDirectory();

        public static void Main(string[] args)
        {
            ReadFile(args);    
            sortedList = SortList(unsortedList);
            PrintNames();
            WriteFile();

            Console.WriteLine("\nPress any key to finish");
            Console.ReadKey();
        }

        // Read names from unsorted-names-list.txt and populate
        public static void ReadFile(string[] path)
        {
            unsortedList = new List<Person>();
            omittedList = new List<Person>();

            bool nameOk;

            try
            {
                using (StreamReader reader = new StreamReader(path[0]))
                {
                    string line;

                    // Read each line while lines exist
                    while ((line = reader.ReadLine()) != null)
                    {

                        line = CheckNameIntegrity(line);
                        nameOk = IsValid(line);

                        if (nameOk == false)
                        {
                            omittedList.Add(new Person(line));
                            continue;
                        }

                        // Split the name in to 2 strings at the last occurence of ' '
                        int index = line.LastIndexOf(' ');
                        string[] splitName = new string[] { line.Substring(0, index), line.Substring(index + 1) };

                        // Populate the list
                        unsortedList.Add(new Person()
                        {
                            givenNames = splitName[0],
                            lastName = splitName[1]
                        });

                    }

                    Console.WriteLine("\nOMITTED NAMES");
                    Console.WriteLine("===================================");
                    foreach (Person p in omittedList)
                    {
                        Console.WriteLine(p.omittedNames);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("catch block");
            }


        }

        // Ensure that all strings are free of whitespace
        public static string CheckNameIntegrity(string s)
        {
            // Trim whitespace
            s = s.Trim();

            // Remove double spaces
            while (s.Contains("  ")) { s = s.Replace("  ", " "); }

            return s;
        }

        // Identify invalid names
        public static bool IsValid(string s)
        {
            int result = 0;

            foreach (string t in s.Split(' ')) { result++; }

            if (result < 2 || result > 4) { return false; }
            else return true;

        }


        // Sort Names by last name and then by given name(s)
        public static List<Person> SortList(List<Person> listToSort)
        {
            List<Person> sortedList = listToSort.OrderBy(person => person.lastName).ThenBy(person => person.givenNames).ToList();

            return sortedList;
        }

        // Print sorted list to Console
        public static void PrintNames()
        {
            Console.WriteLine("\nSORTED LIST");
            Console.WriteLine("===================================");
            foreach (Person p in sortedList)
            {
                Console.WriteLine(p.givenNames + " " + p.lastName);
            }
        }

        // Write sorted list to sorted-names-list.txt
        public static void WriteFile()
        {

            using (StreamWriter writer = new StreamWriter(startDirectory + "\\sorted-names-list.txt"))
            {
                foreach (Person p in sortedList)
                {
                    writer.WriteLine(p.givenNames + " " + p.lastName);
                }
            }
        }
    }

    public class Person
    {
        public string lastName { get; set; }
        public string givenNames { get; set; }
        public string omittedNames { get; set; }
        //private static List<Person> people = new List<Person>();

        public Person()
        {

        }

        public Person(string omittedNames)
        {
            this.omittedNames = omittedNames;
        }

        public Person(string lastName, string givenNames)
        {
            this.lastName = lastName;
            this.givenNames = givenNames;
        }

    }
}
