using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLib;

namespace HRAPP
{
    class Program
    {
        static List<Employee> emp1 = new List<Employee>();
        static void Main(string[] args)
        {

            ConfirmEmployee e1 = new ConfirmEmployee();

            e1.Name = "Ravi Sinha";
            e1.Address = "Alwar, Rajasthan";
            try
            {
                e1.Basic = 20000;
            }
            catch (MinimumBasic ex)
            {
                Console.WriteLine(ex.Message);
            }

            e1.Designation = "Intern";
           // Console.WriteLine(e1);
            //Console.WriteLine("Salary: " + e1.CalculateSalary());

           

            Trainee t1 = new Trainee("Bill", "Gates, USA", 20, 5);
            //Console.WriteLine(t1);

           // Console.WriteLine("Salary: " + t1.CalculateSalary());

            //Trainee t2 = new Trainee();
            //Console.WriteLine("enter name, address, no of days and rate ");
            //t2.Name = Console.ReadLine();
            //t2.Address = Console.ReadLine();
            //t2.NoOfDays = Int32.Parse(Console.ReadLine(), NumberStyles.AllowLeadingWhite, new CultureInfo("en-au"));
            //t2.Rate = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine(t2);

            #region Single GenericCollections
            
            emp1.Add(e1);
            emp1.Add(t1);
            emp1.Add(new ConfirmEmployee("Himanshu", "Jaipur, Raj", 50000, "Junior Developer"));
            emp1.Add(new ConfirmEmployee("Raaghu", "Alwar, Raj", 20000, "Trainee"));
            emp1.Add(new Trainee("Shunder", "Ranchi, India", 20, 5));

            char choice = 'y';
            while (choice == 'y' || choice=='Y')
            {
                Console.WriteLine("1. Display All Employees\n2.Insert Confirm Employee\n3.Insert Trainee\n4.Delete Employee\n5.Display Employee by No");
                int option = Int32.Parse(Console.ReadLine(), NumberStyles.AllowLeadingWhite);

                switch (option)
                {
                    case 1:
                        Display();
                        break;

                    case 2:
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter Designation");
                        string desg = Console.ReadLine();
                        Console.WriteLine("Enter Basic sal>5000");
                        double basic = Convert.ToDouble(Console.ReadLine());
                        Insert_CEmp(name, address, desg, basic);
                        break;

                    case 3:
                        Console.WriteLine("Enter Name");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        address = Console.ReadLine();
                        Console.WriteLine("Enter No of Days");
                        int days = Int32.Parse(Console.ReadLine(), NumberStyles.AllowLeadingWhite);
                        Console.WriteLine("Enter Rate per day");
                        double rate = Convert.ToDouble(Console.ReadLine());
                        Insert_TEmp(name, address, days, rate);
                        break;

                    case 4:
                        Console.WriteLine("Enter Employee No.");
                        int empNo= Int32.Parse(Console.ReadLine());
                        Delete(empNo);
                       
                        break;

                    case 5:
                        Console.WriteLine("Enter Employee No.");
                        empNo = Int32.Parse(Console.ReadLine());
                        Display(empNo);
                        break;

                    default:
                        Console.WriteLine("Please enter valid option no.");
                        break;
                }

                Console.WriteLine("Do you want to continue y/n");

                choice = Convert.ToChar(Console.ReadLine());

            }

            #endregion

            //Console.ReadLine();
        }

        private static void Display(int empNo)
        {
            int i = 0;
            for (; i < emp1.Count; i++)
            {
                if (emp1[i].EmpNo == empNo)
                {
                    Console.WriteLine(emp1[i]);
                    break;
                }
            }
           if(i==emp1.Count)
                Console.WriteLine("Given Employee No is not available");
        }

        private static void Delete(int empNo)
        {
            int i = 0;
            for (; i < emp1.Count; i++)
            {
                if (emp1[i].EmpNo == empNo)
                {
                    emp1.RemoveAt(i);
                    break;
                }
               
            }
            if (i == emp1.Count)
                Console.WriteLine("Given Employee No is not available");
        }

        private static void Insert_TEmp(string name, string address, int days, double rate)
        {
            Trainee tE = new Trainee(name, address, days, rate);
            emp1.Add(tE);
        }

        private static void Insert_CEmp(string name, string address, string desg, double basic)
        {
            ConfirmEmployee cE = new ConfirmEmployee();
            cE.Name = name;
            cE.Address = address;
            cE.Designation = desg;
            try
            {
                cE.Basic = basic;
            }
            catch(MinimumBasic ex)
            {
                Console.WriteLine(ex.Message);
            }
            emp1.Add(cE);
        }

        private static void Display()
        {
            Console.WriteLine("Displaying All employees details: ");
            for (int i = 0; i < emp1.Count; i++)
            {
                Console.WriteLine(emp1[i]);
            }
        }
    }
}
