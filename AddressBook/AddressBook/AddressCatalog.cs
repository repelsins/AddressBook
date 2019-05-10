using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class AddressCatalog
    {
        private readonly List<Contact> _contacts;






        public AddressCatalog()
        {
            _contacts = new List<Contact>();
        }






        public bool AddContact(string firstName, string lastName)
        {
            Contact contact = new Contact(firstName, lastName);
            Contact result = FindContact(firstName);

            if (result == null)
            {
                _contacts.Add(contact);
                return true;
            }
            else
            {
                return false;
            }
        }






        public Contact FindContact(string firstName)
        {
            Contact contact = _contacts.Find(
                delegate(Contact a) { return a.FirstName == firstName; });
            return contact;
        }




        public bool IsEmpty()
        {
            return (_contacts.Count == 0);
        }






        public void ContactList(Action<Contact> action)
        {
            _contacts.ForEach(action);
        }

  






        public bool RemoveContact(string firstName)
        {
            Contact contact = FindContact(firstName);
            if (contact != null)
            {
                _contacts.Remove(contact);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}