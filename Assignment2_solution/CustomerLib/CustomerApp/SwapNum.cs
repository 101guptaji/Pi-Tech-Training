using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class SwapNum
    {
        static void Main(string[] args)
        {
            SwapNumGeneric<int> num1 = new SwapNumGeneric<int>(12, 55);
            Console.WriteLine("Before Swap: "+num1.toString());
            num1.swap();

            Console.WriteLine("After Swap: " + num1.toString());

            Console.ReadLine();
        }
    }
}
