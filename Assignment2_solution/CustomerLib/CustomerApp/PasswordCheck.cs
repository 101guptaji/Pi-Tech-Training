using System;
using System.Collections.Generic;

namespace CustomerApp
{
    internal class PasswordCheck
    {
        HashSet<char> symbol=new HashSet<char>(){'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+'};

        internal int VerifyPassword(string pass)
        {
            if (LenCheck(pass) && OneCap(pass) && hasLower(pass))
            {
                if (IsDigit(pass))
                {
                    if (IsSymbol(pass))
                        return 3;
                    else
                        return 2;
                }
                else if (IsSymbol(pass))
                {
                     return 2;
                }
                else
                    return 1;
            }
            else
                return 0;
        }

        private bool hasLower(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if (Char.IsLower(pass[i]))
                    return true;
                
            }
            return false;
        }

        private bool IsSymbol(string pass)
        {

            for (int i = 0; i < pass.Length; i++)
            {
                if (symbol.Contains(pass[i]))
                    return true;

            }
            return false;
        }

        private bool IsDigit(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if (Char.IsDigit(pass[i]))
                    return true;

            }
            return false;
        }

        private bool OneCap(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if (Char.IsUpper(pass[i]))
                    return true;

            }
            return false;
        }

        private bool LenCheck(string pass)
        {
            if (pass.Length > 5 )
                return true; 
            return false;
        }
    }
}