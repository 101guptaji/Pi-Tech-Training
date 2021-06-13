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
            int[] maxMin = Max_Min1(num1);  //using array signature
            Console.WriteLine("Using Array as return type: \nMaximum of array: " + maxMin[0] + "\nMinimum of array: " + maxMin[1]);

            HashSet<int> maxMin2= Max_Min2(num1);   //using Set signature
            Console.WriteLine("Using Set as return type: \nMaximum of array: " + maxMin2.ElementAt(0) + "\nMinimum of array: " + maxMin2.ElementAt(1));

            List<int> maxMin3 = Max_Min3(num1); //using List signature
            Console.WriteLine("Using List as return type: \nMaximum of array: " + maxMin3.ElementAt(0) + "\nMinimum of array: " + maxMin3.ElementAt(1));

            Stack<int> maxMin4 = Max_Min4(num1);    //using Stack signature
            Console.WriteLine("Using Stack as return type: \nMaximum of array: " + maxMin4.ElementAt(0) + "\nMinimum of array: " + maxMin4.ElementAt(1));

            Console.ReadLine();
        }

        private static Stack<int> Max_Min4(int[] num1)
        {
            Stack<int> maxMin4 = new Stack<int>();
            int max1 = int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }

            maxMin4.Push(min1);
            maxMin4.Push(max1);
            return maxMin4;
        }

        private static List<int> Max_Min3(int[] num1)
        {
            List<int> maxMin3 = new List<int>();
            int max1 = int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }
            maxMin3.Add(max1);
            maxMin3.Add(min1);
            return maxMin3;
        }

        private static HashSet<int> Max_Min2(int[] num1)
        {
            HashSet<int> maxMin2 = new HashSet<int>();
            int max1 = int.MinValue;
            int min1 = int.MaxValue;
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] > max1)
                    max1 = num1[i];
                if (num1[i] < min1)
                    min1 = num1[i];
            }
            maxMin2.Add(max1);
            maxMin2.Add(min1);

            return maxMin2;
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
