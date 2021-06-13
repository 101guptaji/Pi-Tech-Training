using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerLib;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerCollection csC = new CustomerCollection();
            char choice = 'y';
            while (choice == 'y' || choice == 'Y')
            {
                Console.WriteLine("1. Display all Customer Records\n2.Display Customer Records by particular Name\n3.Display Customer Records by particular City and Country\n");
                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Displaying All Customer Records: ");
                        List<Customer> csRecords = csC.Display();
                        for (int i = 0; i < csRecords.Count; i++)
                        {
                            Console.WriteLine(csRecords[i]);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter Customer Name");
                        string name = Console.ReadLine();
                        csRecords = csC.CS_Name(name);
                        if (csRecords.Count == 0)
                            Console.WriteLine("\nNo Record found!\n");
                        else
                        {
                            for (int i = 0; i < csRecords.Count; i++)
                            {
                                Console.WriteLine(csRecords[i]);
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter City");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter Customer Country");
                        string country = Console.ReadLine();
                        csRecords = csC.CS_City_country(city, country);
                        if (csRecords.Count == 0)
                            Console.WriteLine("\nNo Record found!\n ");
                        else
                        {
                            for (int i = 0; i < csRecords.Count; i++)
                            {
                                Console.WriteLine(csRecords[i]);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Please enter valid option no.");
                        break;
                }

                Console.WriteLine("Do you want to continue y/n");

                choice = Convert.ToChar(Console.ReadLine());

            }

            
        }
    }
}
