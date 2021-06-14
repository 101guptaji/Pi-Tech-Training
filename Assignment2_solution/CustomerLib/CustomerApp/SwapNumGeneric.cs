using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomerApp
{
    
    public class SwapNumGeneric<@int>
    {
         

        private @int first;

        public @int First
        {
            get { return first; }
            set { first = value; }
        }

        private @int second;

        public @int Second
        {
            get { return second; }
            set { second = value; }
        }


        public SwapNumGeneric(@int firstElement, @int secondElement)
            {
                First = firstElement;
                Second = secondElement;
            }


 
            public void swap()
            {

                @int temp = First;
                First = Second;
                Second = temp;
            }
        //public SwapNumGeneric<T, T> swap()
        //    {
        //        return new SwapNumGeneric(second, first);
        //    }

            public string toString() { return string.Format($"{first}, {second}"); }
        }
}

