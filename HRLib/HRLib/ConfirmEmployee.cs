using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class ConfirmEmployee: Employee
    {
        #region FIELDS and Properties
        private double basic;

        public double Basic
        {
            get { return basic; }
            set
            {
                if (value >= 5000)
                {
                    basic = value;
                }
                else
                {
                    throw new Exception("Basic is less than 5000");
                }
            }

            }

        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        #endregion

        #region Constructor
        public ConfirmEmployee()
        {

        }

        public ConfirmEmployee(string name, string address, double basic, string designation) : base(name, address)
        {
            Basic = basic;
            Designation = designation;
        }

        #endregion
        #region Methods

        #endregion

        #region Methods
        public sealed override double CalculateSalary()
        {
            double netSalary;
            double hra, conv, pf;
            

                if (basic >= 30000)
                {

                    hra = 0.3 * basic;
                    conv = 0.3 * basic;
                    pf = 0.1 * basic;
                }
                else if (basic >= 20000)
                {
                    hra = 0.2 * basic;
                    conv = 0.2 * basic;
                    pf = 0.1 * basic;
                }
                else
                {
                    hra = 0.1 * basic;
                    conv = 0.1 * basic;
                    pf = 0.1 * basic;
                }
                netSalary = basic + hra + conv - pf;
           
            return netSalary;
        }

        public override string ToString()
        {
            return string.Format($"Employee No: {EmpNo}, Name: {Name}, Address: {Address}, Basic: {Basic}, Designation: {Designation}");
        }

        #endregion
    }
}
