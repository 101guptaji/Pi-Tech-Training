using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataBaseApp
{
    class FileIO
    {
        static void Main(string[] args)
        {
            FileStream f1 = null;
            StreamWriter sw = null;
            try
            {
                //Creation or overwrite of a file. 
                f1 = new FileStream("sample.txt", FileMode.Create);
                //StreamWriter
                sw = new StreamWriter(f1);

                Console.WriteLine("File Created successfully");

                //Writing to the file
                Console.WriteLine("Enter your Name:");
                string name = Console.ReadLine();
                sw.WriteLine($"This is {name}");
                sw.WriteLine($"{name} is a very intelligent boy.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Closing the StreamWriter and file
                sw.Close();

                f1.Close();
            }

            /*
             * StreamReader class is used to read string from the stream. It inherits TextReader class. 
             * It provides Read() and ReadLine() methods to read data from the stream.
             */
            StreamReader sr = null;
            try
            {
                //Opening of a existing file. 
                f1 = new FileStream("sample.txt", FileMode.Open);
                //StreamReader
                sr = new StreamReader(f1);

                Console.WriteLine("Reading From file:");
                //Reading line by line
                string line = "";
                int row = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    row++;
                    Console.WriteLine(Convert.ToString(row)+": "+line);
                }

                //reading full file at once
               //line = sr.ReadToEnd();

                Console.WriteLine(line);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Closing the StreamReader and file
                sr.Close();

                f1.Close();
            }

            Console.ReadLine();


        }
     

    }
}
