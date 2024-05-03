using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLab7
{
    class Ratings
    {
        private Dictionary<int, string> _Rating;

        public Ratings()
        {
            _Rating = new Dictionary<int, string>();
        }

        public Ratings(Dictionary<int, string> dict)
        {
            _Rating = dict;
        }

        public Dictionary<int,string> GetRatings()
        { return this._Rating; }

        public void AddNewEntry(int place,string entry)
        {
            _Rating.Add(place, entry);
        }

        public void RemoveEntry(int place)
        {
            _Rating.Remove(place);
        }

        public void RemoveEntry(string name)
        {
            int place = this.SearchPlace(name);
            _Rating.Remove(place);
        }

        public void ShiftEmptySlots()
        {
            System.Collections.Generic.Dictionary<int, string>.KeyCollection keys = _Rating.Keys;
            for(int i=0;i<keys.Count;i++)
            {
                if(!keys.Contains(i) && keys.Contains(i+1))
                {
                    string buff = "";
                    _Rating.TryGetValue(i + 1, out buff);
                    _Rating.Add(i, buff);
                    _Rating.Remove(i+1);
                }
            }
        }

        public string SearchEntry(int space)
        {
            string Name="";
            if (_Rating.TryGetValue(space, out Name))
            { return Name; }
            else { return "Error: NoEntry"; }
        }

        public int SearchPlace(string name)
        {
            int place=-1;
            if (_Rating.ContainsValue(name))
            {
                foreach(KeyValuePair<int,string> pair in _Rating)
                {
                    if(EqualityComparer<string>.Default.Equals(pair.Value, name))
                    {
                        place = pair.Key;
                    }

                }
                //place = _Rating.
                //_Rating.
                return place;
            }
            else
            { return -1; }
        }

        public bool EditEntry(int place, string newVar)
        {
            try
            {
                this.RemoveEntry(place);
                this.AddNewEntry(place, newVar);
                return true;
            }
            catch { return false; }
        }

         public string RatingstoString()
        {
            string toRating = "";

            foreach(KeyValuePair<int, string> pair in _Rating.OrderBy(x => x.Key))
            {
                toRating = toRating + (pair.Key+1) + " - " + pair.Value + Environment.NewLine;
            }

            return toRating;
        }

    }
}
