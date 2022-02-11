using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_4_3_1
{
    public class Contact
    {
        public string contactName;
        public List<string> contactNumbers = new List<string>();

        public Contact()
        {
            this.contactName = "Name";
            this.contactNumbers.Add("1234567890");
        }
        public Contact(string name, string number)
        {
            this.contactName = name;
            this.contactNumbers.Add(number);
        }
        public void DisplayContact()
        {
            Console.WriteLine("Name: {0}", contactName);
            foreach (string numbers in contactNumbers)
            {
                Console.Write("Number:{0} ", numbers);
            }
            Console.WriteLine("");
        }
    }
}