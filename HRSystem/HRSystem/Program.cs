using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LINQAssignmentEntities db = new LINQAssignmentEntities();

            //SQL query running in background
            //db.Database.Log = Console.WriteLine;

            //IEnumerable<DEPT> query = from d in Linq.DEPTs select d;

            //foreach (DEPT item in query)
            //{
            //    Console.WriteLine(item.DEPTNO+"\t"+item.DNAME);
            //}

            //1.	LIST ALL THE DATA FROM THE EMPLOYEE TABLE
            //IEnumerable<EMP> q1 = from e in db.EMPs select e;
            //foreach (EMP item in q1)
            //{
            //    Console.WriteLine(item.ENAME);
            //}

            //2.	LIST ALL THE DATA FROM THE EMPLOYEE TABLE ORDER BY JOB
            //IEnumerable<EMP> q2 = from e in db.EMPs orderby e.JOB select e;
            //foreach (EMP item in q2)
            //{
            //    Console.WriteLine(item.ENAME+"\t"+item.JOB);
            //}

            //3.	LIST ALL THE DATA FROM THE EMPLOYEE TABLE WHOSE NAME START WITH S 
            //IEnumerable<EMP> q3 = from e in db.EMPs where e.ENAME.StartsWith("S") select e;
            //foreach (EMP item in q3)
            //{
            //    Console.WriteLine(item.ENAME);
            //}

            //5.	FIND THE DETAILS OF ALL MANAGER (IN ANY DEPT) AND ALL CLERKS IN DEPT 10 
            //IEnumerable<EMP> q4 = from e in db.EMPs where (e.JOB == "MANAGER") || (e.JOB == "CLERK" && e.DEPTNO == 20) select e;
            //foreach (EMP item in q4)
            //{
            //    Console.WriteLine(item.ENAME + "\t" + item.JOB + "\t" + item.DEPTNO);
            //}

            // 6.	FIND THE EMPLOYEES WHO DO NOT RECEIVE A COMMISSION 
            //IEnumerable<EMP> q5 = from e in db.EMPs where e.COMM==null select e;
            //foreach (EMP item in q5)
            //{
            //    Console.WriteLine(item.ENAME);
            //}

            // 7.	FIND ALL EMPLOYEES WHOSE NET EARNINGS (SAL + COMM) IS GREATER THAN RS. 2000  
            //var q6 = from e in db.EMPs
            //                      let NetEarning = (e.SAL ?? 0) + (e.COMM ?? 0)
            //                      where NetEarning>2000 select new { e.ENAME, e.SAL, e.COMM, NetEarning };
            //foreach (var item in q6)
            //{
            //    Console.WriteLine(item.ENAME+"\t"+item.SAL+"\t"+item.COMM+"\t"+item.NetEarning);
            //}

            // 8.	FIND ALL EMPLOYEE HIRED IN MONTH OF FEBUARY (OF ANY YEAR) 
            //var q7 = from e in db.EMPs where e.HIREDATE.Value.Month == 12 select e;
            //var q8 = db.EMPs.Where(e => e.HIREDATE.Value.Month == 2);
            //foreach (var item in q8)
            //{
            //    Console.WriteLine(item.ENAME + "\t" + item.HIREDATE );
            //}

            // 9.	LIST TOTAL SALARY FOR THE ORGANIZATION 
            //var q9 = db.EMPs.Sum(e => e.SAL);
            //Console.WriteLine("Sum of Salary ="+q9);

            // 10.	LIST TOTAL EMPLOYEES WORKS IN EACH DEPARTMENT 
            //var q10 = from e in db.EMPs
            //          group e by e.DEPTNO into Deptgrp
            //          select new
            //          {
            //              grpName = Deptgrp,
            //              empCount = Deptgrp.Count()};
            //foreach (var item in q10)
            //{
            //    Console.WriteLine(item.grpName.Key+"\t"+item.empCount);
            //}


            //11.	LIST FIRST THREE HIGHEST PAID EMPLOYEES
            //var q11= (from e in db.EMPs orderby e.SAL descending select e).Take(3);
            //foreach (var item in q11)
            //{
            //    Console.WriteLine(item.ENAME + "\t" + item.SAL);
            //}


            //12.	DISPLAY THE NAMES, JOB AND SALARY OF ALL EMPLOYEES, SORTED ON  DESCENDING ORDER OF JOB AND WITHIN JOB, SORTED ON THE DESCENDING ORDER   OF SALARY 
            //IEnumerable<EMP> q12 = db.EMPs.OrderByDescending(e => e.JOB).ThenByDescending(e => e.SAL);
            //foreach (EMP item in q12)
            //{
            //    Console.WriteLine(item.ENAME+"\t"+item.JOB + "\t" + item.SAL);
            //}


            //13.LIST DEPARTMENT NAME, EMPLOYEE NAME AND JOB
            //var q13 = from e in db.EMPs join d in db.DEPTs
            //          on e.DEPTNO equals d.DEPTNO
            //          select new { d.DNAME, e.ENAME, e.JOB };
            //foreach (var item in q13)
            //{
            //    Console.WriteLine(item.DNAME + "\t" + item.ENAME + "\t" + item.JOB);
            //}

            //14.	LIST DEPARTMENT NAME AND MAX SALARY FOR EACH DEPARTMENT
            //var q14 = from e in db.EMPs join d in db.DEPTs
            //          on e.DEPTNO equals d.DEPTNO 
            //          group e by d.DNAME into empgrp
            //          select new { empgrp.Key, maxSal=empgrp.Max(e=>e.SAL) };

            //foreach (var item in q14)
            //{
            //    Console.WriteLine(item.Key + "\t" + item.maxSal );
            //}

            //15.	LIST DEPARTMENT NAME AND TOTAL EMPLOYEE WORKING IN EACH DEPARTMENT ALSO INCLUDE DEPARTMENT WHERE NO EMPLOYEES ARE WORKING
            //var q15 = from d in db.DEPTs
            //          join e in db.EMPs
            //        on d.DEPTNO equals e.DEPTNO into EmpData
            //          from data in EmpData.DefaultIfEmpty()
            //          group data by d.DNAME;

            //foreach (var item in q15)
            //{
            //    foreach (var da in item)
            //    {
            //        Console.Write(item.Key + "\t");
            //        if(da!=null)
            //            Console.Write(da.ENAME+"\t"+da.JOB+"\t"+da.SAL);
            //        Console.WriteLine();
            //    }
            //}

            //16.	SELECT Dept Name FROM Department TABLE WHILE DISPLAYING DATA ALSO DISPLAY Emp Name BASED ON Department
            //var q16 = from d in db.DEPTs select d;
            //foreach (var item in q16)
            //{
            //    Console.WriteLine(item.DNAME);
            //    foreach (var e in item.EMPs)
            //    {
            //        Console.WriteLine("\t"+e.ENAME);
            //    }
            //}

            //17.	INSERT NEW DEPARTMENT AND EMPLOYEE FOR THAT DEPARTMENT 
            /*DEPTNO=50, DEPTNAME=IT
            EMPNO=1001, EMPNAME=RAHUL
            */
            //DEPT d = new DEPT()
            //{
            //    DEPTNO=50,
            //    DNAME="IT"
            //};
            //db.DEPTs.Add(d);
            //EMP e1 = new EMP()
            //{
            //    EMPNO=1001,
            //    ENAME="RAHUL"
            //};
            //db.EMPs.Add(e1);
            //db.SaveChanges();

            //18.UPDATE Rahul RECORD WITH SAL = 20000
            //EMP emp = db.EMPs.SingleOrDefault(e => e.ENAME == "RAHUL");
            //if(emp!=null)
            //{
            //    emp.SAL = 20000;
            //    db.SaveChanges();
            //}

            //19.	Delete Record of Rahul
            //EMP delEmp = db.EMPs.SingleOrDefault(e => e.ENAME == "RAHUL");
            //if (delEmp != null)
            //{
            //    db.EMPs.Remove(delEmp);

            //    db.SaveChanges();
            //}

            //20.	Write a stored procedure in SQL Server name it as JobWiseDetails which takes Job as in parameter and return Total Employee, Max Salary and Min Salary for the Job
            //ObjectParameter totalEmp = new ObjectParameter("totalEmp", typeof(int));
            //ObjectParameter maxSal = new ObjectParameter("maxSal", typeof(decimal));
            //ObjectParameter minSal = new ObjectParameter("minSal", typeof(decimal));
            //db.JobWiseDetails("MANAGER", totalEmp, maxSal, minSal);
            //Console.WriteLine($"Total Emp={totalEmp.Value}\nMax Salary={maxSal.Value}\nMinimum Salary={minSal.Value} ");

            Console.ReadLine();
        }
    }
}
