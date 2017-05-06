using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
   public class Coaches
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

       
        public Coaches()
        {

        }

        public Coaches(string name)
        {
            _name = name;
            
        }

        public string InfoCoaches
        {
            get
            {
                return $"{_name}\n ";
            }
        }

        
    }
}
