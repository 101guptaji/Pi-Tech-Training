using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for LINQDemo.xaml
    /// </summary>
    public partial class LINQDemo : Window
    {
        List<Employee> empList;
        public LINQDemo()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            empList = new List<Employee>();

            empList.Add(new Employee() { EmpNo = 101, EmpName = "bhavana", Address = "mumbai", Dept = "hr", Salary = 15000 });
            empList.Add(new Employee() { EmpNo = 102, EmpName = "amit", Address = "mumbai", Dept = "sales", Salary = 25000 });
            empList.Add(new Employee() { EmpNo = 103, EmpName = "vishal", Address = "pune", Dept = "sales", Salary = 20000 });
            empList.Add(new Employee() { EmpNo = 104, EmpName = "priya", Address = "mumbai", Dept = "hr", Salary = 30000 });
            empList.Add(new Employee() { EmpNo = 105, EmpName = "asha", Address = "mumbai", Dept = "sales", Salary = 30000 });
            empList.Add(new Employee() { EmpNo = 106, EmpName = "pankaj", Address = "pune", Dept = "hr", Salary = 35000 });
            empList.Add(new Employee() { EmpNo = 107, EmpName = "anil", Address = "mumbai", Dept = "sales", Salary = 18000 });
            empList.Add(new Employee() { EmpNo = 108, EmpName = "preeti", Address = "pune", Dept = "hr", Salary = 25000 });

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
            //defered Execution
            //Using Declarative Syntax
            //IEnumerable<Employee> query1 = from emp in empList select emp;
            //IEnumerable<Employee> query1 = from emp in empList where emp.Address=="mumbai" select emp;
            // IEnumerable<Employee> query1 = from emp in empList orderby emp.EmpName select emp;
            //IEnumerable<Employee> query1 = from emp in empList orderby emp.Dept,emp.Address select emp;


            //Method Syntax
            //IEnumerable<Employee> query1 = empList.Where(FilterByAddress);
            //IEnumerable<Employee> query1 = empList.Where(emp => emp.Address == "mumbai");
            //IEnumerable<Employee> query1 = empList.OrderBy(emp => emp.EmpName);
            //IEnumerable<Employee> query1 = empList.OrderBy(emp => emp.Dept).ThenBy(emp=>emp.Address);

            //immediate execution
            //query1=query1.ToList();
            //IEnumerable<Employee> query1 = (from emp in empList select emp).ToList();

            //query1=query1.Where(emp => emp.EmpName == "amit");
            //foreach (Employee item in query1)
            //{
            //    richTextBox1.AppendText(item + "\n");
            //}
            //richTextBox1.AppendText("\n-------------------------------\n");
            //empList.Add(new Employee() { EmpNo = 201, EmpName = "Don", Address = "Tokyo", Dept = "hr", Salary = 25000 });

            //foreach (Employee item in query1)
            //{
            //    richTextBox1.AppendText(item + "\n");
            //}

            //single Record
            //list record of amit
            //if we use only First, but there are no records then it throws execption
            //So use FirstOrDefault

            //Employee query2 = (from emp in empList where emp.EmpName=="amit" select emp).FirstOrDefault();

            //richTextBox1.AppendText("\n---" + query2 + "\n");

            //Single says tgere should be only one record if more than one throw exception
            //Employee query2 = (from emp in empList where emp.EmpName == "amit" select emp).SingleOrDefault();

            //Employee query2 = empList.SingleOrDefault(emp=>emp.EmpName=="amit");

            //richTextBox1.AppendText("\n---" + query2 + "\n");

            //list all emp whose name ends with 'a'
            //IEnumerable<Employee> query5 = from emp in empList where emp.EmpName.EndsWith("a") select emp;
            //foreach (Employee item in query5)
            //{
            //    richTextBox1.AppendText("\n"+item);
            //}

            //richTextBox1.AppendText("\n-------------------------------\n");
            ////list all emp whose name contain 'i'
            //IEnumerable<Employee> query6 = from emp in empList where emp.EmpName.Contains("i") select emp;
            //foreach (Employee item in query6)
            //{
            //    richTextBox1.AppendText("\n" + item );
            //}


            //list empname, dept,and salary

            //use anonumous type

            //Employee emp1=new Employee();

            //var is implicitly types local variable

            //var data = new { empList[0].EmpName, empList[0].Dept, empList[0].Salary };


            //var query8 = from emp in empList select new { emp.EmpName, emp.Dept, emp.Salary };

            //var query8 = empList.Select(emp=> new{ emp.EmpName, emp.Dept, emp.Salary });

            //foreach (var item in query8)
            //{
            //    //richTextBox1.AppendText("\n" + item);
            //    richTextBox1.AppendText("\n" + item.EmpName+" "+item.Dept+" "+item.Salary);
            //}

            //var query9= from emp in empList group emp by emp.Dept ;

            //foreach (var item in query9)
            //{
            //    //richTextBox1.AppendText("\n" + item);
            //    richTextBox1.AppendText("\n" + item.Key);
            //    foreach (var row in item)
            //    {
            //        richTextBox1.AppendText("\t" + row+"\n");
            //    }
            //}

            //Method Syntax
            //var query9 = empList.GroupBy(emp => emp.Dept);

            //foreach (var item in query9)
            //{
            //    //richTextBox1.AppendText("\n" + item);
            //    richTextBox1.AppendText("\n" + item.Key);
            //    foreach (var row in item)
            //    {
            //        richTextBox1.AppendText("\t" + row + "\n");
            //    }
            //}

            //IEnumerable<Employee> query10 = (from emp in empList orderby emp.Salary descending select emp).Take(2);

            //foreach (Employee item in query10)
            //{
            //    richTextBox1.AppendText("\n" + item);
            //    //richTextBox1.AppendText("\n" + item.EmpName + " " + item.Dept + " " + item.Salary);
            //}

            //let keyword
            var query10 = from emp in empList
                          let Bonus = emp.Salary * 0.1
                          select new { emp.EmpName, emp.Salary,Bonus,NetSalary=emp.Salary+Bonus };

            foreach (var item in query10)
            {
                richTextBox1.AppendText("\n" + item);
                //richTextBox1.AppendText("\n" + item.EmpName + " " + item.Dept + " " + item.Salary);
            }


            //Aggregate function

            //Total Employee
            var empCount = (from emp in empList select emp).Count();
            richTextBox1.AppendText("\nCount= " + empCount);

            //Total salary
            var TotalSal = (from emp in empList select emp).Sum(e1 => e1.Salary);
            richTextBox1.AppendText("\nSum of Salary= " + TotalSal);

            //Min salary
            richTextBox1.AppendText("\nMin salary= " + empList.Min(e1 => e1.Salary));

            //Average Salary
            var AvgSal = (from emp in empList select emp).Average(e1 => e1.Salary);
            richTextBox1.AppendText("\nAverage Salary= " + AvgSal);

            //Dept wise total salary
            var DeptSalSum = from emp in empList
                             group emp by emp.Dept into empgrp
                             select new { grpName = empgrp.Key, SalSum = empgrp.Sum(e1 => e1.Salary), AvgSal = empgrp.Average(e1 => e1.Salary) };

            foreach (var item in DeptSalSum)
            {
                richTextBox1.AppendText("\n" + item);
            }
        
        }

        private bool FilterByAddress(Employee arg)
        {
            if(arg.Address=="mumbai")
            {
                return true;
            }
            return false;
        }
    }
}
