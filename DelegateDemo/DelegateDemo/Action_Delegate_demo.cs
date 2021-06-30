/*
 * Action delegate takes zero, one or more input parameters, but does not return anything.
 * public delegate void Action<int T>(T arg);  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Action_Delegate_demo
    {
        static int result;
        static void Main(string[] args)
        {
            Action<int, int> Add = Addnum;
            Add(50, 25);
            Console.WriteLine($"Addition = {result}");

            //----------------Action with an Anonymous Method---------
            Action<int, int> Substract = delegate (int num1, int num2)
            {
                result= num1 - num2;
            };
            Substract(50, 25);
            Console.WriteLine($"Substraction = {result}");

            //---------------Action with Lambda-------------------
            Action<int, int> Multiply = (num1, num2) =>result= num1 * num2;
            Multiply(50, 25);
            Console.WriteLine($"Multiplication = {result}");

            Console.ReadLine();
        }

        private static void Addnum(int n1, int n2)
        {
            result = n1 + n2;
        }
    }
}
