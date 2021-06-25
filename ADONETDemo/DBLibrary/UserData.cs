using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class UserData
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format($"UserName: {UserName} Password: {Password} ");
        }
    }
}
