using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    public class Buy
    {
        public int ProductsAmount { get; set; }
        public int TotalPrice { get; set; }
        public double TotalWeight { get; set; }
        public List<Product> AllProducts { get; set; }
        public Buy(params Product[] products)
        {
            ProductsAmount = products.Length;
            AllProducts = new List<Product>();
            foreach (var item in products)
            {
                TotalPrice += item.Price;
                TotalWeight += item.Weight;
                AllProducts.Add(item);
            }
        }
        public Buy() 
        {
            ProductsAmount = 0;
            TotalPrice = 0;
            TotalWeight = 0;
            AllProducts = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                AllProducts.Add(product);
                TotalPrice += product.Price;
                TotalWeight += product.Weight;
                ProductsAmount += 1;
            }
        }
        public Product GetProduct(int index)
        {
            if (index < AllProducts.Count && index >= 0)
            {
                return AllProducts[index];
            }
            throw new ArgumentException();
        }

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < AllProducts.Count)
                    return AllProducts[index];
                throw new ArgumentException();
            }
        }
    }
}
