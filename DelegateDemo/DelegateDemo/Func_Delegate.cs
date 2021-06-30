/*
 * Whenever we use delegates, we have to declare a delegate then initialize it, then we call a method with a reference variable.
 * In order to get rid of all the first steps, we can directly use Func, Action, or Predicate delegates.
 * 
 * The Func delegate takes zero, one or more input parameters, and returns a value (with its out parameter).
 * Syntax:
 *      public delegate TResult Func<int T, out TResult>(T arg);  
 * The last parameter in the angle brackets <> is considered as the return type and remaining parameters are considered as input parameter types.
 * It can have 0 - 16 input parameters.
 * If Func has 0 parameters, then It still has one parameter, it is a return type because func always return something.
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Func_Delegate
    {
        static void Main(string[] args)
        {
            //func delegate with 2 input para of type int and one out para of type int and referencing to method Addnum
            Func<int, int, int> Add = Addnum;
            int result = Add(50, 25);
            Console.WriteLine($"Addition = {result}");

            //----------------Func with an Anonymous Method---------
            Func<int, int, int> Substract = delegate (int num1, int num2)
            {
                return num1 - num2;
            };
            int result2 = Substract(50, 25);
            Console.WriteLine($"Substraction = {result2}");

            //---------------Func with Lambda-------------------
            Func<int, int, int> Multiply = (num1, num2) => num1 *  num2;
            int result3 = Multiply(50, 25);
            Console.WriteLine($"Multiplication = {result3}");

            Console.ReadLine();
        }

        private static int Addnum(int num1, int num2)
        {
            return num1 + num2;
        }


    }
}
