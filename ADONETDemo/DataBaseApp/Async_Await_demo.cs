/*
 *  using Asynchronous programming, the Application can continue with the other work that does not depend on the completion of the entire task.
 *  Async and await in C# are the code markers, which marks code positions from where the control should resume after a task completes.
 *  Example:
 *      Read all the characters from a large text file asynchronously and get the total length of all the characters without waiting other task.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApp
{
    class Async_Await_demo
    {
       
        static void Main()
        {
            Task task = new Task(CallMethod);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        static async void CallMethod()
        {
            string filePath = "Async_await.txt";
            Task<int> task = ReadFile(filePath);

            Console.WriteLine(" Other Task 1");
            Console.WriteLine(" Other Task 2");
            Console.WriteLine(" Other Task 3");

            int length = await task;
            Console.WriteLine(" Total length: " + length);

            Console.WriteLine(" After Task 1");
            Console.WriteLine(" After Task 2");
        }

        static async Task<int> ReadFile(string file)
        {
            int length = 0;

            Console.WriteLine(" File reading started");
            using (StreamReader reader = new StreamReader(file))
            {
                // Reads all characters from the current position to the end of the stream asynchronously
                // and returns them as one string.
                string s = await reader.ReadToEndAsync();

                length = s.Length;
            }
            Console.WriteLine(" File reading is completed");
            return length;
        }
        
    }
}
