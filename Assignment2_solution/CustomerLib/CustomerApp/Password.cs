using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class Password
    {
        static void Main(string[] args)
        {
            char choice = 'y';
            while (choice == 'y' || choice == 'Y')
            {
                Console.WriteLine("Enter Your password");
                string pass = Console.ReadLine();

                PasswordCheck p1 = new PasswordCheck();
                int strength = p1.VerifyPassword(pass);
                //Console.WriteLine("Stregth: "+strength);

            
                switch (strength)
                {
                    case 1:
                        Console.WriteLine("Password Strength: Weak");
                        break;
                    case 2:
                        Console.WriteLine("Password Strength: Moderate");
                        break;
                    case 3:
                        Console.WriteLine("Password Strength: Strong");
                        break;
                    default:
                        Console.WriteLine("Sorry! Your password not acceptable, Try a new one.\nYour password should contain atleast one upper case and lower case letter and have minimum length 6.");
                        break;
                }

                Console.WriteLine("Do you want to try new one y/n");

                choice = Convert.ToChar(Console.ReadLine());

            }

            //Console.ReadLine();
        }
    }
}
