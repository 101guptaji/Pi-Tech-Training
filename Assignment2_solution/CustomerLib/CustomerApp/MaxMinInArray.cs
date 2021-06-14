using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class MaxMinInArray
    {
        static void Main(string[] args)
        {
            int[] num1 = { 5, 4, 10, 8, 2, 4, 88 };
            int[] maxMin = Max_Min1(num1);  //using Array type
            Console.WriteLine("Using Array as return type: \nMaximum of array: " + maxMin[0] + "\nMinimum of array: " + maxMin[1]);

            MaxMin maxMin2= Max_Min2(num1);   //using Struct type
            Console.WriteLine("Using Struct as return type: \nMaximum of array: " + maxMin2.max + "\nMinimum of array: " + maxMin2.min);

            int max3;
            int min3 = Max_Min3(num1,out max3); //using Output Parameters
            Console.WriteLine("Using Output Parameters: \nMaximum of array: " + max3 + "\nMinimum of array: " + min3);

            int max4 = int.MinValue;
            int min4 = Max_Min4(num1,ref max4);    //using Reference parameters
            Console.WriteLine("Using Reference parameters: \nMaximum of array: " + max4 + "\nMinimum of array: " + min4);

            Console.ReadLine();
        }

        private static int Max_Min4(int[] num1, ref int max1)
        {
             //max1 = int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }
            return min1;
        }

        private static int Max_Min3(int[] num1,out int max1 )
        {
            
            max1= int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }
           
            return min1;
        }


        public struct MaxMin
        {
            public int min;
            public int max;
        }
        private static MaxMin Max_Min2(int[] num1)
        {
            MaxMin values = new MaxMin();
            int max1 = int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }
            values.max = max1;
            values.min = min1;
            return values;
        }
        private static int[] Max_Min1(int[] num1)
        {
            int[] arr = new int[2];
            
            int max1 = int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }
            arr[0] = max1;
            arr[1] = min1;

            return arr;
        }
    }
}
