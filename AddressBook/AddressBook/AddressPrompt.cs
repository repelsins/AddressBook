using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressPrompt
    {
        private AddressCatalog catalog;






        public AddressPrompt()
        {
            catalog = new AddressCatalog();
        }






        static void Main(string[] args)
        {
            string userInput = "";
            AddressPrompt prompt = new AddressPrompt();
            prompt.DisplayMenu();

            while (userInput.ToLower() != "quit")
            {
                Console.WriteLine("What do you want to do?");
                userInput = Console.ReadLine();
                prompt.Action(userInput);
            }

        }






        private void Action(string userInput)
        {
            string firstName = "";
            string lastName = "";

            switch (userInput.ToLower())
            {
                case "add":
                    Console.WriteLine("Enter the contacts first name you want to add:");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter the contacts last name you want to add:");
                    lastName = Console.ReadLine();
                    if (catalog.add(firstName,lastName))
                    {
                        Console.WriteLine("Contact successfully added");
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} already exists", firstName);
                    }
                    break;
                case "remove":
                    Console.WriteLine("Enter the contacts first name you want to remove:");
                    firstName = Console.ReadLine();
                    if (catalog.remove(firstName))
                    {
                        Console.WriteLine("Contact successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Contact for {0} could not be found.", firstName);
                    }
                    break;
            }
        }






        void DisplayMenu()
        { 
            Console.WriteLine("Welcome to the Address Book Application!");
            Console.WriteLine("Type:");
            Console.WriteLine("'add' to add new contact.");
            Console.WriteLine("'remove' to delete contact.");
            Console.WriteLine("'quit' to exit the application.");
        }
    }
}
