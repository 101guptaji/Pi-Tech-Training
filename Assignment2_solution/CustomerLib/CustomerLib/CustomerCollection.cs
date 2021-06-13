using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLib
{
    public class CustomerCollection
    {
        private List<Customer> csList = new List<Customer>();

        public CustomerCollection()
        {
            csList.Add(new Customer("Himanshu", "Jaipur", "India"));
            csList.Add(new Customer("Sam", "Jammu & Kasmir", "India"));
            csList.Add(new Customer("Jones", "Los Angels", "Singapor"));
            csList.Add(new Customer("Shi-Ching", "Vuhan", "China"));
            csList.Add(new Customer("Orbhi", "Michigan", "USA"));
            csList.Add(new Customer("Shannu", "Hdrabad", "India"));
            csList.Add(new Customer("Hanni", "Alwar", "India"));
            csList.Add(new Customer("Jugnu", "Bahror", "India"));
            csList.Add(new Customer("Tiger", "Forest", "India"));
            csList.Add(new Customer("Rabit", "Zoo", "India"));

        }

        public List<Customer> Display()
        {
            return csList;
        }

        public List<Customer> CS_Name(string name)
        {
            List<Customer> cs_ByName = new List<Customer>();
            for (int i = 0; i < csList.Count; i++)
            {
                if(csList[i].Name.ToLower().Equals(name.ToLower()))
                {
                    cs_ByName.Add(csList[i]);
                }
            }
            return cs_ByName;
        }

        public List<Customer> CS_City_country(string city, string country)
        {
            List<Customer> cs_ByCity = new List<Customer>();
            for (int i = 0; i < csList.Count; i++)
            {
                if (csList[i].City.ToLower().Equals(city.ToLower()) && csList[i].Country.ToLower().Equals(country.ToLower()))
                {
                    cs_ByCity.Add(csList[i]);
                }
            }
            return cs_ByCity;
        }
    }
}
