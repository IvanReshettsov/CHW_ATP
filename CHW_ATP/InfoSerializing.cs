using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
   public class InfoSerializing
    {
        private List<Players> _players;

        public List<Players> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        private List<Tournaments> _tournaments;

        public List<Tournaments> Tournaments
        {
            get { return _tournaments; }
            set { _tournaments = value; }
        }
    }
}
