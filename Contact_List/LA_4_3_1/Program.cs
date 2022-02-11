using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
* *
Write a program that stores your phone’s contact list. A contact has a name and a phone number (10 digits). 
The user should be able to type “add <Name> <Number>” to add a new contact with a given phone number, or to update an existing contact by adding a phone number
“update <Old Number> <Updated Name> <New Number>”. If a user has more than one phone number, they will use the add command multiple times. 
A user can delete a contact by using the command “delete <Number>”. Finally, the user should also be able to type “find <Name>” to get a 
list of that contact’s phone numbers. The program should keep running until the user types the command: exit.

Hint: You will need to create a Contact object for this
*/
namespace LA_4_3_1
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<Contact> Contacts = new List<Contact>();
            Console.WriteLine("Enter some information into your Contacts List");
            Console.WriteLine("To add a name, enter 'add <Name> <Number>'");
            Console.WriteLine("To find a name, enter 'find <Name>'");
            Console.WriteLine("To delete a contact, enter 'delete <Number>'");
            Console.WriteLine("To change a number in a contact, enter 'update <Old Number> <Updated Name> <New Number>'");
            Console.WriteLine("To show the contact list, enter 'display'");
            Console.WriteLine("To exit, enter 'exit'");
            //Contact Matt = new Contact("Matt", "5554443333");
            //Matt.DisplayContact();
            do
            {
                
                string name = Console.ReadLine();
                //name = name.ToLower();
                string[] values = name.Split(' ');
                if (values[0] == "exit")
                {
                    break;
                }
                else if (values[0] == "add")
                {
                    bool found = false;
                     
                    for (int i = 0; i < Contacts.Count; i++)
                    {
                        var temp = Contacts[i].contactNumbers;
                        if (Contacts[i].contactName.Equals(values[1]) && values[2].Length == 10 && ((Contacts[i].contactNumbers.Contains(values[2]) == false)))  
                        { 
                                found = true;
                                Contacts[i].contactNumbers.Add(values[2]);
                                Console.WriteLine("New Phone Number added to {0}.", values[1]);
                        }
                        else if (Contacts[i].contactName.Equals(values[1]) && values[2].Length != 10)
                        {
                            found = true;
                            Console.WriteLine("Contact Name {0} found, but phone number is incorrect number of digits. ", values[1]);
                        }
                        else if (Contacts[i].contactName.Equals(values[1]) && values[2].Length == 10 && Contacts[i].contactNumbers.Contains(values[2])) 
                        {
                            found = true;
                            Console.WriteLine("Contact Name {0} found, but phone number already exists. ", values[1]);
                         }
                    }
                    if (!found && values[2].Length == 10)
                    {
                        Contacts.Add(new Contact(values[1], values[2]));
                        Console.WriteLine("New Contact {0} created with phone number {1}.", values[1], values[2]);
                    }
                    else if (!found && values[2].Length != 10)
                    {
                        Console.WriteLine("The phone number has the incorrect number of digits. Please try again.");
                    }
                }

                else if (values[0] == "find")
                {
                    bool found = false;
                    for (int i = 0; i < Contacts.Count; i++)
                    {
                        if (Contacts[i].contactName.Equals(values[1]))
                        {
                            Console.WriteLine("Contact Name: {0}",values[1]);
                            found = true;
                            foreach (string number in Contacts[i].contactNumbers)
                            {
                                Console.WriteLine("Phone Number: {0}",number);
                            }

                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("No contact with that name found.");
                    }
                }
                else if (values[0] == "display")
                {
                    int index = 1;
                    Console.WriteLine("Contact List:");
                    foreach (Contact item in Contacts)
                    {
                        Console.WriteLine(index);
                        item.DisplayContact();
                        index ++;
                    }
                }
                else if (values[0] == "delete")
                {
                    bool found = false;
                    for (int i = 0; i < Contacts.Count; i++)
                    {
                        string number = values[1];
                        if (Contacts[i].contactNumbers.Contains(number) && values[1].Length == 10)
                        {
                            found = true;
                            string temp = Contacts[i].contactName;
                            Contacts.Remove(Contacts[i]);
                            Console.WriteLine("Contact {0} has been removed.", temp);
                        }

                    }
                    if (!found && values[1].Length == 10)
                    {
                        Console.WriteLine("No contact with that number found.");
                    }
                    if (!found && values[1].Length != 10)
                    {
                        Console.WriteLine("Incorrect number format. Please try again.");
                    }
                }
                else if (values[0] == "update")
                {
                    bool found = false;
                    for (int i = 0; i < Contacts.Count; i++)
                    {
                        if (Contacts[i].contactName.Equals(values[2]) && Contacts[i].contactNumbers.Contains(values[1]) && values[1].Length == 10 && values[3].Length == 10)
                        {
                            found = true;
                            Contacts[i].contactNumbers.Remove(values[1]);
                            Contacts[i].contactNumbers.Add(values[3]);
                            Console.WriteLine("{0} has been updated to {1} for {2}.", values[1], values[3], values[2]);
                        }
                    }
                    if (values[1].Length != 10 || values[3].Length != 10)
                    {
                        found = true;
                        Console.WriteLine("One of the numbers entered is invalid.");
                    }
                    else if (!found)
                    {
                        Console.WriteLine("No contact with that number found.");
                    }
                }
                } while (true);
        }
    }
    
}
