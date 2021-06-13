using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class Trainee : Employee
    {
        #region Fields and Properties
        private int noOfDays;

        public int NoOfDays
        {
            get { return noOfDays; }
            set { noOfDays = value; }
        }

        
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        #endregion

        #region Constructor
        public Trainee()
        {

        }
        public Trainee(string name, string address, int noOfDays, double rate):base(name, address)
        {
            NoOfDays = noOfDays;
            Rate = rate;
        }

        #endregion
        #region Methods

        #endregion

        #region Methods
        public sealed override double CalculateSalary()
        {
            return noOfDays * rate;
        }

        public override string ToString()
        {
            return string.Format($"Employee No: {EmpNo}, Name: {Name}, Address: {Address}, No of days: {NoOfDays}, Rate per Day: {Rate}");
        }
        #endregion

    }
}
