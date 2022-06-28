using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
     public class Dairy_products:Product
    {
        private DateTime _date;
        public DateTime Date { get { return _date; } set { _date = value; } }
        public Dairy_products(string name, int price, int weigth, DateTime dataTime) :base(name, price, weigth)
        {
            _date = dataTime;
        }
        public override void percentСhange(int percent)
        {
            DateTime dateNow=DateTime.Now;
            if (_date>dateNow )
            {
                if(_date.Day - dateNow.Day < 10 && _date.Month - dateNow.Month < 1 && _date.Year - dateNow.Year < 1)
                {
                    Price = (int)(Price + Price * (percent +10) / 100d);
                }
                else if(_date.Day - dateNow.Day < 5 && _date.Month - dateNow.Month < 1 && _date.Year - dateNow.Year < 0)
                {
                    Price = (int)(Price + Price * (percent - 10) / 100d);
                }
                else if(_date.Day - dateNow.Day < 2 && _date.Month - dateNow.Month < 0 && _date.Year - dateNow.Year < 0)
                {
                    Price = (int)(Price + Price * (percent - 50) / 100d);
                }
            }
            else
            {
                Price = 0;
            }
        }
    }
}
