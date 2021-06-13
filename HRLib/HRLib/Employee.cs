using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public abstract class Employee
    {

        #region FIELDS and PROPERTIES

        private static int count=0;

        public static int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int empNo;

        public int EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        #endregion

        #region Constructor
        public Employee()
        {
            Count++;
            EmpNo = Count;
        }

        public Employee(string name, string address): this()
        {
            Name = name;
            Address = address;
            
        }

        #endregion
        #region METHODS

        #endregion

        #region METHODS
        public abstract double CalculateSalary();

        public override string ToString()
        {
            return string.Format($"Employee No: {EmpNo}, Name: {Name}, Address: {Address}");
        }


        #endregion
    }
}
