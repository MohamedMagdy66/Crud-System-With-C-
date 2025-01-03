using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace Person_Management
{
    internal class Manager
    {
        public List<Person> people; 
        public Manager() 
        {
            people = new List<Person>()
           {
                new Person("mohamed",26),
            };
            PrintMenu();
        }
        public void PrintMenu()
        {
            string[] menuOptions = new string[]
            {
                "Print all users",
                "Add User",
                "Edit User",
                "Search User",
                "Remove User",
                "Exit",
            };
            Console.WriteLine("Welcom to my Management System"+Environment.NewLine);
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }
            Console.Write("Enter Option: ");
            bool tryparse= int.TryParse(Console.ReadLine(),out int MenuOption);
            if (tryparse){
                if (MenuOption == 1) { PrintAll(); }
                else if (MenuOption == 2) { AddUser(); }
                else if (MenuOption == 3) { EditUser(); }
                else if (MenuOption == 4) { SearchUser(); }
                else if (MenuOption == 5) { RemoveUser(); }
                if (MenuOption >= 1 && MenuOption <= menuOptions.Length-1)
                {
                    PrintMenu();
                }
                else
                {
                    outputMessage("incorrect option number !");
                    PrintMenu();
                }

            }
            else 
            {
                outputMessage("choose option");
                PrintMenu();
            }
            
        }
        public void PrintAll() 
        {
            StartOption("ALL USERS");
            if (!isSystemEmpty())
            {
                
                printAllUsers();
                FinishOption();
                /*using foreach n lambda expressiob
                 * int i = 0;
                people.ForEach(person=>
                {
                    i++;
                    Console.WriteLine($"{i}. {person.Details()}");
                });*/
            }
        }
        public void AddUser()
        {
            StartOption("ADD USER");
            try
            {
                Person person = returnPerson();
                if (person != null)
                {
                    people.Add(person);
                    Console.WriteLine("succesfully added a new person");
                    FinishOption();
                }
                else
                {
                    outputMessage("enter valid data");
                    AddUser();
                }
            }
            catch (Exception)
            {
                outputMessage("something went wrong");
                AddUser();
            }
        }
        public void EditUser()
        {
            StartOption("EDIT USER");
            if(!isSystemEmpty())
            {
                printAllUsers();
                try
                {
                    Console.Write("Enter User's Number: ");
                    int indexSelection = Convert.ToInt32(Console.ReadLine());
                    indexSelection--;
                    if(indexSelection >= 0 && indexSelection<=people.Count-1)
                    {
                        try
                        {
                            Person person = returnPerson();
                            if (person != null)
                            {
                                people[indexSelection] = person;
                                Console.WriteLine("succesfully edited a person");
                                FinishOption();
                            }
                            else
                            {
                                outputMessage("enter valid data");
                                EditUser();
                            }
                        }
                        catch (Exception)
                        {
                            outputMessage("something went wrong");
                            EditUser();
                        }
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong !");
                    EditUser();
                }

            }
            
        }
        public void SearchUser()
        {
            StartOption("SEARCH USER");
            //check if list isn't empty
            if (people.Count == 0)
            {
                Console.WriteLine("there;s no users in the system");
            }
            else
            {
                Console.WriteLine("enter the name to search it: ");
                string nameInput = Console.ReadLine();
                bool pFound = false;
                if (!string.IsNullOrEmpty(nameInput))
                {
                    for (int i = 0;i< people.Count; i++)
                    {
                        if (people[i].Name.ToLower().Contains(nameInput.ToLower()))
                        {
                            Console.WriteLine($"{i + 1}. {people[i].Details()}");
                            pFound = true;
                        }

                    }
                    if (!pFound)
                    {
                        Console.WriteLine("No users found");
                    }
                    FinishOption();
                        
                }
                else
                {
                    outputMessage("enter a name !");
                    SearchUser();

                }


            }
            //get name
            //validate the name
            //loop n check for the name
            //return user by name
            //back to menu

            FinishOption();
        }
        public void RemoveUser()
        {
            StartOption("REMOVE USER");
            if (!isSystemEmpty())
            {
                printAllUsers();
                Console.Write("Enter the user id: ");
                int IdInput = Convert.ToInt32(Console.ReadLine());
                IdInput--;
                if (IdInput >= 0 && IdInput <= people.Count - 1)
                {
                    people.RemoveAt(IdInput);
                    Console.WriteLine("succesfully removed a person\n");
                    FinishOption();
                }
                else
                {
                    outputMessage("enter a vaild id exist in the system");
                    RemoveUser();
                    
                }

            }
             }
        public void FinishOption()
        {
            Console.WriteLine("\nPress Enter to back to menu");
            Console.ReadLine();
            Console.Clear();
        }
        public void StartOption(String option)
        {
            
            Console.WriteLine($"----{option}----" + Environment.NewLine);
        }
        public void outputMessage(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadLine();
            Console.Clear();
        }
        public void printAllUsers()
        {
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {people[i].Details()}");
            }
        }
        public Person returnPerson()
        {
                //add name
                Console.Write("please enter the name: ");
                string nameInput = Console.ReadLine();
                //add age
                Console.Write("please enter the age: ");
                int ageInput = Convert.ToInt32(Console.ReadLine());
                //validate the inputs
                if (!string.IsNullOrEmpty(nameInput))
                {
                    if (ageInput > 0 && ageInput < 150)
                    {
                        //create person
                        return new Person(nameInput, ageInput);
                    }
                    else
                    {
                        outputMessage("Enter a sensible age\n");
                       
                    }
                }
                else
                {
                    outputMessage("enter a valid name like: Mohamed");
                   
                }
                return null;

        }
        public bool isSystemEmpty()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("no users in the system");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
