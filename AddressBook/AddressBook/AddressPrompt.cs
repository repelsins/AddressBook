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
        private readonly AddressCatalog _addressCatalog;






        private AddressPrompt()
        {
            _addressCatalog = new AddressCatalog();
        }






        private static void Main(string[] args)
        {
            var userInput = "";
            AddressPrompt addressPrompt = new AddressPrompt();
            DisplayMenu();

            while (userInput.ToLower() != "quit")
            {
                Console.WriteLine("What do you want to do?");
                userInput = Console.ReadLine();
                addressPrompt.Action(userInput);
            }

        }






        private void Action(string userInput)
        {
            var firstName = "";
            var lastName = "";

            switch (userInput.ToLower())
            {
                case "add":
                    Console.WriteLine("Enter the contacts first name you want to add:");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter the contacts last name you want to add:");
                    lastName = Console.ReadLine();
                    if (_addressCatalog.AddContact(firstName, lastName))
                    {
                        Console.WriteLine("Contact successfully added");
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} already exists", firstName);
                    }
                    break;
                case "find":
                    Console.WriteLine("Enter the contacts first name you want to find");
                    firstName = Console.ReadLine();
                    if (_addressCatalog.IsEmpty())
                    {
                        Console.WriteLine("The Address Catalog is empty");
                    }
                    else
                    {
                        
                    }

                    break;

                case "remove":
                    Console.WriteLine("Enter the contacts first name you want to remove:");
                    firstName = Console.ReadLine();
                    if (_addressCatalog.RemoveContact(firstName))
                    {
                        Console.WriteLine("Contact successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Contact for {0} could not be found.", firstName);
                    }
                    break;
                case "list":
                    if (_addressCatalog.IsEmpty())
                    {
                        Console.WriteLine("The Address Catalog is empty");
                    }
                    else
                    {
                        Console.WriteLine("Contacts:");
                        _addressCatalog.ContactList(
                            delegate(Contact a)
                            {
                                Console.WriteLine("{0} - {1}", a.FirstName, a.LastName);

                            }
                            );
                    }
                    break;
            }
        }






        private static void DisplayMenu()
        { 
            Console.WriteLine("Welcome to the Address Book Application!");
            Console.WriteLine("Type:");
            Console.WriteLine("'add' to add new contact.");
            Console.WriteLine("'remove' to delete contact.");
            Console.WriteLine("'quit' to exit the application.");
        }
    }
}
