/*
 * Predicate is a special kind of Func. It represents a method that contains a set of criteria mostly defined inside an if condition and checks whether the passed parameter meets those criteria or not.
 * It takes one input parameter and returns a boolean - true or false.
 * public delegate Boolean Predicate<int T>(T arg);  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Predicate_delegate_Demo
    {
        static void Main(string[] args)
        {
            //check for odd num
            Predicate<int> ChkOdd = Odd;
            bool result = ChkOdd(150);
            if (result)
                Console.WriteLine("It is an odd number");
            else
                Console.WriteLine("It is an even number");


            //----------------Predicate with an Anonymous Method---------
            //check for valid user
            Predicate<string> ChkUser = delegate (string Name) {
                if (Name == "admin") return true;
                return false;
            };
            bool result2 = ChkUser("admin");
            if (result) Console.WriteLine("Valid User");
            else Console.WriteLine("Invalid User");

            //---------------Predicate with Lambda-------------------
            //check for Rich man 
            Predicate<double> ChkRich = salary => {
                if (salary > 10000) return true;
                return false;
            };
            bool result3 = ChkRich(8000);
            if (result) Console.WriteLine("Rich Man");
            else Console.WriteLine("Poor Man");

            Console.ReadLine();
        }

        private static bool Odd(int num)
        {
            if (num%2!=0)
                return true;
            else
                return false;
        }
    }
}
