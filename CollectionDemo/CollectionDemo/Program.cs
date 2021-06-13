using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionDemo
{
    enum Months 
    { 
        jan,fab, mar, apr, may, jun, july, aug, sep, oct, nov, dec
    }

    struct Employee
    {
        public int EmpNo;
        public string EmpName;
        public double Salary;

        public string Print()
        {
            return string.Format($"{EmpNo}, {EmpName}, {Salary}");
        }

        //only supports parameterized constructor
        public Employee(int empNo, string emp, double s)
        {
            EmpNo = empNo;
            EmpName = emp;
            Salary = s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Array
            //Array Declaration
            //datatype[] arrayname=new datatype[size];

            int[] numArray = new int[3]; //declare array of 3 integer

            //initiazing array
            numArray[0] = 85;
            numArray[1] = 6100;
            numArray[2] = 85611;

            for (int i = 0; i < numArray.Length; i++)
            {
                Console.WriteLine(numArray[i]);
            }

            //declare and initialize array on sm line
            int[] num2 = { 1, 4, 5, 2, 10 };
            for (int i = 0; i < num2.Length; i++)
            {
                Console.WriteLine(num2[i]);
            }

            int[] sortedNum = Bubble(num2);

            Console.WriteLine("Sorted Array: ");
            for (int i = 0; i < sortedNum.Length; i++)
            {
                Console.WriteLine(sortedNum[i]);
            }

            string[] any = { "as", "rea" };

            #endregion

            #region Collection-> ArrayList
            ArrayList arrList = new ArrayList();

            arrList.Add("Himanshu");
            arrList.Add(100);
            arrList.Add(true);
            arrList.Add(15.55);

            Person p1 = new Person()
            { FirstName = "Hanni", LastName = "jangir" }; //Initializer block

            arrList.Add(p1);

            arrList.Add(new Person() { FirstName = "Himanshu", LastName = "gupta" });
            Console.WriteLine(((Person)arrList[4]).FirstName); //Type casting

            for (int i = 0; i < arrList.Count; i++)
            {
                Console.WriteLine(arrList[i]);
            }

            #endregion

            #region Generic Collections
            List<string> name = new List<string>();
            name.Add("Himkams");
            name.Add("ramjf");
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine(name[i]);
            }
           

            List<Person> pList = new List<Person>();
            pList.Add(new Person() { FirstName = "Himanshu", LastName = "gupta" });
            Console.WriteLine(pList[0].FirstName);

            #endregion

            #region Nullable Type

            string s = null;

            //value type can not handle null
            //value type always requires value
            //they have default value
            //for all number type default value is 0
            // and for bool, default value is false
            //int i=null;  //will give error

            //Nullable type work with value type
            //Nullable type help us to assign null  value to value type

            Nullable<int> x = null;
            x = 100;
            x = null;

            int? y = 20;   //? implies Nullable type i.e. y can be int or null.
            y = null;
            //y = 100;
            Console.WriteLine("Value of y= " + y);

            if(y.HasValue)
            {
                Console.WriteLine("Value of y=" + y);
            }
            else
            {
                Console.WriteLine("y is null");
            }
            #endregion

            #region Structure
            Employee emp1 = new Employee(1, "Himansd", 15062);
            Console.WriteLine(emp1.Print());

            #endregion

            #region Enum
            Console.WriteLine(DayOfWeek.Friday + ": " + (int)DayOfWeek.Friday);

            Console.WriteLine(Months.fab + ": " + (int)Months.fab);

            #endregion
            Console.ReadLine();
        }

        public static int[] Bubble(int[] num)
        {
            
            int tmp = 0;
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = 1; j < (num.Length-i); j++)
                {
                    if (num[j - 1] > num[j])
                    {
                        tmp = num[j - 1];
                        num[j - 1] = num[j];
                        num[j] = tmp;
                    }
                }

            }
            return num;
        }

    }
}
