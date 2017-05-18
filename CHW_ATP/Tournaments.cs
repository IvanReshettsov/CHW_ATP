using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
   public class Tournaments
    {
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _tname;

        public string TName
        {
            get { return _tname; }
            set { _tname = value; }

        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _surface;

        public string Surface
        {
            get { return _surface; }
            set { _surface = value; }
        }

        private int _category;

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private string _prizeMoney;

        public string Prize_Money
        {
            get { return _prizeMoney; }
            set { _prizeMoney = value; }
        }

        private string _supervisor;

        public string Supervisor
        {
            get { return _supervisor; }
            set { _supervisor = value; }
        }

        public Tournaments()
        {

        }
        
        public Tournaments(string date, string tname, string city, string country, string surface, int category,string prizeMoney)
        {
            _date = date;
            _tname = tname;
            _city = city;
            _category = category;
            _surface = surface;
            _country = country;
            _prizeMoney = prizeMoney;
            
        }

        public string InfoTournaments
        {
            get
            {
                return $"{_tname} , {_country}, ATP {_category}, {_surface}, {_city}, {_prizeMoney}, Supervisor:{_supervisor}\n";
            }
        }
    }
}
