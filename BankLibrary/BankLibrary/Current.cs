using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    class Current: Bank
    {
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
