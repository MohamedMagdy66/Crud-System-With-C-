using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Management
{

    internal class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private string name;
        private int age;
        public string Name {
            get => name;
            set => name = !string.IsNullOrEmpty(value) ? value : string.Empty;
        }
        public int Age
        {
            get => age;
            set => age = value > 0 && value < 150 ? value : -1;
        }


        public String Details()
        {
           return($"{Name} - {Age}");
            
        }

    }
}
