using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
   public class Supervisors
    {
        private string  _name;

        public string  Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private string _nation;

        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        public Supervisors()
        {

        }

        public Supervisors(string name, int age, string nation)
        {
            _name = name;
            _age = age;
            _nation = nation;
        }
    }
}
