using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
    public class User
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public string Info
        {
            get
            {
                return $"{_name} {_password}";
            }
        }

    }
}
