using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemo
{
    class Person
    {
        //normal implemented property
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        //Auto implemented property 
        public string LastName { get; set; }

        /*public override string ToString()
        {
            return string.Format($"First Name: {FirstName}, Last Name: {LastName}");
        }
        */
    }
}
