using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
    class Players
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        private string _nationality;

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        private int _rating;

        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private string _strongHand;

        public string StrongHand
        {
            get { return _strongHand; }
            set { _strongHand = value; }
        }

        private int _titles;

        public int Titles
        {
            get { return _titles; }
            set { _titles = value; }
        }

        private double _prizeMoney;

        public double PrizeMoney
        {
            get { return _prizeMoney; }
            set { _prizeMoney = value; }
        }

        public Players(string name, string nationality, string strongHand, int rating, int height, int weight, int titles, double prizeMoney)
        {
            _name = name;
            _nationality = nationality;
            _strongHand = strongHand;
            _rating = rating;
            _height = height;
            _weight = weight;
            _titles = titles;
            _prizeMoney = prizeMoney;
        }

        public string Info
        {
            get
            {
                return $"{_name} ; {_nationality}; {_strongHand}; №{_rating}; {_height} cm; {_weight} kg; {_titles} titles; {_prizeMoney}$";
            }
        }
    }
}
