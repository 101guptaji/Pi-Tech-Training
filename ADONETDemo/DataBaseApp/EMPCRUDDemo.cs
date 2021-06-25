using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;

namespace DataBaseApp
{
    class EMPCRUDDemo
    {
        EmpDataStore empData;

        public EMPCRUDDemo()
        {
            empData = new EmpDataStore(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
        }

        static void Main(string[] args)
        {
            EMPCRUDDemo emps = new EMPCRUDDemo();
            char choice = 'y';
            while (choice == 'y' || choice == 'Y')
            {
                Console.WriteLine("1. Display all empolyee Records\n2.Display Employee Records by Employee No.\n3.Insert new Employee Record\n4.Update an Employee Record\n5.Delete an Employee Record\n");
                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n\n----------All Employees Details----------\n");
                        emps.DisplayAllEmps();
                        break;

                    case 2:
                        emps.DisplayEmp();
                        Console.WriteLine("\n----------An Employee Details----------");
                        break;

                    case 3:
                        Console.WriteLine("\n----------------Insert new Employee Record----------------");
                        emps.Insertemp();
                        break;
                    case 4:
                        Console.WriteLine("\n----------Update Employees Details----------");
                        emps.UpdateEmp();
                        break;
                    case 5:
                        Console.WriteLine("\n----------Delete Employees Details----------");
                        emps.DeleteEmp();
                        break;

                    default:
                        Console.WriteLine("Please Choose valid option no.");
                        break;
                }

                Console.WriteLine("Do you want to continue y/n");

                choice = Convert.ToChar(Console.ReadLine());

            }

        }

        private void DeleteEmp()
        {
            try
            {
                Console.WriteLine("Enter Emp no");
                int empno = int.Parse(Console.ReadLine());

                int status = empData.DeleteEmpSql(empno);
                if (status>0)
                    Console.WriteLine("Record deleted successfully");
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void UpdateEmp()
        {
            Emp emp = null;
            try
            {
                emp = new Emp();
                Console.WriteLine("Enter Emp no");
                emp.Empno = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Emp name");
                emp.EmpName = Console.ReadLine();

                Console.WriteLine("Enter Emp hire date");
                DateTime dt;
                Boolean st = DateTime.TryParse(Console.ReadLine(), out dt);
                if (st == false)
                    emp.HireDate = null;
                else
                    emp.HireDate = dt;

                Console.WriteLine("Enter Emp salary");
                decimal ds;
                st = decimal.TryParse(Console.ReadLine(), out ds);
                if (st == false)
                    emp.Salary = null;
                else
                    emp.Salary = ds;
                //emp.Salary = Convert.ToDecimal(Console.ReadLine());

                int status = empData.UpdateEmpSql(emp);
                if (status > 0)
                {
                    Console.WriteLine("Emp record updated successfully");
                    Console.WriteLine("Row affected: " + status);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
        void DisplayAllEmps()
        {
            try
            {
                List<Emp> empList = empData.GetEmps();

                foreach (Emp item in empList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        void DisplayEmp()
        {
            try
            {
                Console.WriteLine("Enter Emp no");
                int empno = int.Parse(Console.ReadLine());

                Emp emp1 = empData.GetEmps(empno);
                if (emp1 == null)
                    Console.WriteLine($"Emp with No {empno} not found");
                else
                    Console.WriteLine(emp1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void Insertemp()
        {
            Emp emp = null;
            try
            {
                emp = new Emp();
                Console.WriteLine("Enter Emp no");
                emp.Empno = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Emp name");
                emp.EmpName =Console.ReadLine();

                Console.WriteLine("Enter Emp hire date");
                DateTime dt;
                Boolean st = DateTime.TryParse(Console.ReadLine(), out dt);
                if (st == false)
                    emp.HireDate = null;
                else
                    emp.HireDate = dt;

                Console.WriteLine("Enter Emp salary");
                decimal ds;
                st = Decimal.TryParse(Console.ReadLine(), out ds);
                if (st == false)
                    emp.Salary = null;
                else
                    emp.Salary = ds;
                //emp.Salary = Convert.ToDecimal(Console.ReadLine());

                int status = empData.InsertEmp(emp);
                if(status>0)
                {
                    Console.WriteLine("Emp record inserted successfully");
                    Console.WriteLine("Row affected: "+status);
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


    }
}
