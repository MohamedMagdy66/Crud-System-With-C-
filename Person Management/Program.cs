using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Mohamed",23);
            Console.WriteLine($"my name is {person.Name}, and my age is {person.Age}");
            Manager manager = new Manager();

        }
    }
}
