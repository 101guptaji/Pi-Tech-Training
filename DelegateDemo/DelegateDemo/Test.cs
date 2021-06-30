using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Test
    {
        static void Main(string[] args)
        {
            string messsage = "Here is example of Extension Method";

            Console.WriteLine("Total no of words in a message: " + ExtensionMethodDemo.WordCount(messsage));

            Console.WriteLine("Total no of words in a message: "+messsage.WordCount());

            Console.ReadLine();
        }
        
    }
}
