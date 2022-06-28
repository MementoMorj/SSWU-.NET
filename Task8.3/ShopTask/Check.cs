using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    public class Check
    {
        public static void PrintInfo(Buy buy)
        {         
            foreach(var item in buy.AllProducts)
            {
                Console.WriteLine($"name={item.Name}, price={item.Price}, weigth={item.Weight}");              
            }   
            Console.WriteLine($"Total weigth={buy.TotalWeight}");
            Console.WriteLine($"Total amount={buy.ProductsAmount}");
            Console.WriteLine($"Total price={buy.TotalPrice}");

        }


    }
}
