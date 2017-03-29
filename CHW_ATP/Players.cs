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

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
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

       

        public Players(string name, int age, string nationality, string strongHand, int rating, int height, int weight, int titles)
        {
            _name = name;
            _age = age;
            _nationality = nationality;
            _strongHand = strongHand;
            _rating = rating;
            _height = height;
            _weight = weight;
            _titles = titles;
          
        }

        public string Info
        {
            get
            {
                return $"{_name} ; {Age}; {_nationality}; {_strongHand}; №{_rating}; {_height} cm; {_weight} kg; {_titles} titles $";
            }
        }
    }
}
