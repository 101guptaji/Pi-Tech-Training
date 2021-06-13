using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Saving: Bank,IInterest
    {
        public Saving()
        {

        }
        public Saving(string AccHolderName, double amt): base(AccHolderName,amt)
        {

        }

        public double CalculateInterest()
        {
            double interest = 10;
            return interest * Balance * 1 / 100;
        }

        public override void Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                // base.Withdraw(amount);
                Balance -= amount;
            }
            else
                throw new Exception("Balance is not enough");
        }
    }
}
