using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    public class Product
    {
        private string name;
        public string Name { get => name; set => name = value; }

        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");                
                }
                else
                {
                    price = value;
                }
            }
            
        }
        private  int weight;
        public int Weight
        {
            get { return weight; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    weight = value;
                }
            }
        }
        public Product() : this(null, default, default)
        {

        }

        public Product(string name, int price, int weigt)
        {
            this.name = name;
            this.price = price;
            this.weight = weigt;
        }
        public virtual void percentСhange(int percent)
        {
            Price = (int)(Price + Price * percent / 100d);
            
        }
        public override string ToString()
        {
            return string.Format("name: {0}, price: {1}, weight: {2}", name, price, Weight);
        }
    }
}
