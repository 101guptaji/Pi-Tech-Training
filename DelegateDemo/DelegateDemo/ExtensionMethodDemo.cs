using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    static class ExtensionMethodDemo
    {
        public static int WordCount(this string msg) //this keyword makes it 
        {
            string[] arr = msg.Split(' ');
            return arr.Length;
        }
    }
}
