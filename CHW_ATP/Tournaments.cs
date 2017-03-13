using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
    class Tournaments
    {
        private string _tname;

        public string TName
        {
            get { return _tname; }
            set { _tname = value; }

        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private int _category;

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private string _surface;

        public string Surface
        {
            get { return _surface; }
            set { _surface = value; }
        }


        private double _prize;

        public double Prize
        {
            get { return _prize; }
            set { _prize = value; }
        }

        public Tournaments(string tname, string location, int category, string surface, double prize)
        {
            _tname = tname;
            _location = location;
            _category = category;
            _surface = surface;
            _prize = prize;
        }

        public string InfoTournaments
        {
            get
            {
                return $"{_tname} , {_location}, ATP {_category}, {_surface}, {_prize}$";
            }
        }
    }
}
