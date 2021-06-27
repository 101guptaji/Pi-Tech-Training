using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

//SOAP is a protocol based on XML, designed specifically to transport procedure calls using XML.

namespace DataBaseApp
{
    class SerialDeserial_SOAP
    {
        static void Main(string[] args)
        {
            //Serialization of object to bytes SOAP  formatter
            FileStream fs = new FileStream("EmpDetail_SOAPSerial.txt", FileMode.OpenOrCreate);
            SoapFormatter format = new SoapFormatter();

            Employee e1 = new Employee() { Empno = 102, Name = "GuptaJi" };
            format.Serialize(fs, e1);

            fs.Close();

            //Deserialization of object to bytes using Binary formatter

            fs = new FileStream("EmpDetail_SOAPSerial.txt", FileMode.Open);
            format = new SoapFormatter();

            Employee e2 = (Employee)format.Deserialize(fs);
            Console.WriteLine($"Employee No: {e2.Empno}\t Name: {e2.Name}");

            Console.ReadLine();
            fs.Close();
        }
    }
}
