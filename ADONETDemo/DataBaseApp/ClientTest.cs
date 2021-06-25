using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;

namespace DataBaseApp
{
    class ClientTest
    {
        UserDataStore uDataStore;

        public ClientTest()
        {
            uDataStore = new UserDataStore(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
        }

        static void Main(string[] args)
        {
            ClientTest udt = new ClientTest();
            Console.WriteLine("\nUser Validation using Connected Architure");
            udt.UserValidConn();

            Console.WriteLine("\nUser Validation using Disconnected Architure");
            udt.UserValidDisconn();

            Console.ReadLine();
        }

        private void UserValidDisconn()
        {
            UserData ud = null;
            try
            {
                ud = new UserData();
                Console.WriteLine("Enter User Name");
                ud.UserName = Console.ReadLine();

                Console.WriteLine("Enter Password");
                ud.Password = Console.ReadLine();

                if (uDataStore.ValidateUserDisconn(ud))
                    Console.WriteLine("Valid User");
                else
                    Console.WriteLine("Username or password is not Valid");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void UserValidConn()
        {
            UserData ud = null;
            try
            {
                ud = new UserData();
                Console.WriteLine("Enter User Name");
                ud.UserName = Console.ReadLine();

                Console.WriteLine("Enter Password");
                ud.Password = Console.ReadLine();

                if (uDataStore.ValidateUserConnect(ud))
                    Console.WriteLine("Valid User");
                else
                    Console.WriteLine("Username or password is not Valid");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}
