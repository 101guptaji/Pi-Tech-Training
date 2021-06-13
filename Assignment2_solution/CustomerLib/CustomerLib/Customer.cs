using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLib
{
    public class Customer
    {
        #region Fields and Properties

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }


        #endregion

        #region Constructor
        public Customer()
        {

        }
        public Customer(string name, string city, string country)
        {
            Name = name;
            City = city;
            Country = country;
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format($"Name: {Name}, City: {City}, Country: {Country}");
        }
        #endregion



    }
}
