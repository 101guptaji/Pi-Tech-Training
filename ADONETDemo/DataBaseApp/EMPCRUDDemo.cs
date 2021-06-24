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

        static void Main(string[] args)
        {
            EMPCRUDDemo emps = new EMPCRUDDemo();
            //Console.WriteLine("----------All Employees Details----------");
            //emps.DisplayAllEmps();

            //Console.WriteLine("\n----------Employee Details----------");

            //emps.DisplayEmp();

            Console.WriteLine("Insert Emp");
            emps.Insertemp();

            Console.WriteLine("----------All Employees Details----------");
            emps.DisplayAllEmps();
            Console.ReadLine();
        }

        public EMPCRUDDemo()
        {
            empData = new EmpDataStore(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
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

                int status = empData.InsertEmp_SP(emp);
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
