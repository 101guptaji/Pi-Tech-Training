using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace SBIApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Bank bank1 = new Bank("Himanshu", 10000);
           
            Console.WriteLine("Bank object  Data "+ bank1);

            bank1.Deposit(20000);
            Console.WriteLine("Bank object Data after deposit "+ bank1);

            bank1.Withdraw(10000);
            Console.WriteLine("Bank object Data after withdraw "+bank1);

            Bank bank2 = new Bank();

            Console.WriteLine("Count: "+Bank.Count);*/

            Saving s1 = new Saving("HIm",2000);
            try {
                s1.Withdraw(1000);
            }
            catch(BalanceException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Saving Account:\n  " + s1);
            Console.WriteLine("Interest : " + s1.CalculateInterest());
            Console.ReadLine();
        }
    }
}
