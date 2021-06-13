using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public abstract class Bank
    {
        #region Fields and 
        private string accHolderName;

        public string AccholderName
        {
            get { return accHolderName; }
            set { accHolderName = value; }
        }

        private double balance;

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        private static int count=0;

        public static int Count
        {
            get { return count; }
            set { count = value; }
        }

        #endregion

        #region Constructor
        public Bank()
        {
            Balance = 1000;
            count++;
        }

        public Bank(string name, double amount): this()
        {
            AccholderName = name;
            Balance = amount;
        }
        
        #endregion

        #region METHODS
        public void Deposit (double amount)
        {
            Balance += amount;
        }

        /*public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }
        */
        public abstract void Withdraw(double amount);
        public override string ToString()
        {
            return String.Format($"AccHolderName={AccholderName}, Balance={Balance}");
        }
        #endregion

    }
}
