using System;

namespace Entities
{
    public class Sale
    {
        private int _month;
        private int _year;
        private string _seller;
        private int _items;
        private double _total;

        public Sale(int month, int year, string seller, int items, double total)
        {
            _month = month;
            _year = year;
            _seller = seller;
            _items = items;
            _total = total;
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Seller
        {
            get { return _seller; }
            set { _seller = value; }
        }

        public int Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public double Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public double AveragePrice()
        {
            return _total / _items;
        }

        public override string ToString()
        {
            return $"{_month}/{_year}, {_seller}, {_items}, {_total}, pm = {AveragePrice():F2}";
        }
    }
}