using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    //Declare Delegate
    delegate int CalulateDelegate(int first, int second);

    class Program
    {
        //delegate method
        static int Addnum(int num1, int num2)
        {
            return num1 + num2;
        }
        int Multiply(int num1,int num2)
        {
            return num1 * num2;
        }
        static void Main(string[] args)
        {
            //3. create delegate instance which point to a method
            //CalulateDelegate calulate = new CalulateDelegate(Addnum);
            CalulateDelegate calulate = Addnum;

            //4. invoke delegate
            int result = calulate(34, 54);
            Console.WriteLine("34+54="+result);

            calulate = new Program().Multiply;
            Console.WriteLine("3*4=" + calulate(3, 4));

            //--------------------Anonymous Method-----
            CalulateDelegate calulate1 = delegate (int x, int y)
            {
                return x - y;
            };

            Console.WriteLine("Substraction: "+calulate1(10,5));
            Console.WriteLine("Substraction: " + calulate1(15, 5));

            //---------------------Lambda----------
            //(input parameter) => expression
            CalulateDelegate calulate2 = (x, y) => x / y;

            Console.WriteLine("Division: "+calulate2(10,4));

            Console.ReadLine();
        }
    }
}

/*Delegate is a function pointer
 * delegate signature and method signature should match.
 * it used in Event, Thread, and async.
 * Steps in delegate:
 * 1. Create a delegate (delegate is a class internally)
 * 2. Define a method
 * 3. create delegate instance which point to a method
 * 4. invoke delegate (internally it will invoke  a method
 * 
 * 
 */
