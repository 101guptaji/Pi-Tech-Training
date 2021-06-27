using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;

//Serialization of object to bytes Binary formatter
namespace DataBaseApp
{
    [Serializable]
    public class Employee
    {
        public int Empno { get; set; }
        public string Name { get; set; }

    }

    class SerialDeserialisation
    {
        static void Main(string[] args)
        {
            //Serialization of object to bytes Binary formatter
            /*
             * serialization is the process of converting object into byte stream so that it can be saved to memory, file or database.
             */
            FileStream fs = new FileStream("EmpDetail_BinarySerial.txt", FileMode.OpenOrCreate);
            BinaryFormatter format = new BinaryFormatter();

            Employee e1 = new Employee() { Empno = 101, Name = "HmanshuJi" };
            format.Serialize(fs, e1);

            fs.Close();

            //Deserialization of object to bytes using Binary formatter
            /*
             * Deserialization is the reverse process of serialization. It means you can read the object from byte stream
            */

            fs = new FileStream("EmpDetail.txt", FileMode.OpenOrCreate);
            format = new BinaryFormatter();

            Employee e2 = (Employee)format.Deserialize(fs);
            Console.WriteLine($"Employee No: {e2.Empno}\t Name: {e2.Name}");

            Console.ReadLine();
            fs.Close();
        }
    }
}
