using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    public class Storage
    {
        protected List<Product> products { get; set; } = new List<Product>();
        public Storage()
        {

        }
        public Storage(params Product[] products)
        {
            foreach (var item in products)
            {
                this.products.Add(item);
            }
        }
        public Product this[int index]
        {
            get => index >= 0 && index < products.Count ? products[index] : throw new ArgumentOutOfRangeException();
            set
            {
                if (index >= 0 && index < products.Count)
                {
                    products[index] = value;
                }
            }
        }

        public void fillingByDialog()
        {
            Product tmpProduct = new Product();
            Console.WriteLine("Введіть назву продуку");
            tmpProduct.Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введіть ціну продуку");
            tmpProduct.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ведіть вагу продукту");
            tmpProduct.Weight = Convert.ToInt32(Console.ReadLine());
            products.Add(tmpProduct);
        }

        public void changePriceOfAllProducts(int percentage)
        {
            foreach (var item in products)
            {
                item.percentСhange(percentage);
            }
        }
        public void FindMeat()
        {
            foreach (var item in products)
            {
                if (item is Meat)
                {
                    Console.WriteLine($"Meat was found {item.Name}");
                }
            }
        }
        public void PrintInfo()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"name={products[i].Name}, price={products[i].Price}, weigth={products[i].Weight}");
            }


        }
        public void ProductFromFile(StreamReader reader)
        {
            ErrorsWorker errorsWorker = new ErrorsWorker(@"errors_list.txt");
               
                int currLine = 0;
                products = new List<Product>();
                while (!reader.EndOfStream)
                {
                    var tmp = reader.ReadLine();
                    currLine++;
                    try
                    {
                        string[] info = tmp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        switch (info[0])
                        {
                            case "Product":
                                {
                                    string name = char.ToUpper(info[1][0]) + info[1][1..];
                                    int price = Convert.ToInt32(info[2]);
                                    int weight = Convert.ToInt32(info[3]);
                                    products.Add(new Product(name, price, weight));
                                    break;
                                }
                            case "Meat":
                                {
                                    string name = char.ToUpper(info[1][0]) + info[1][1..];
                                    int price = Convert.ToInt32(info[2]);
                                    int weight = Convert.ToInt32(info[3]);
                                    Meat.Category category = (Meat.Category)Enum.Parse(typeof(Meat.Category), info[2]);
                                    Meat.Species species = (Meat.Species)Enum.Parse(typeof(Meat.Species), info[3]);
                                    products.Add(new Meat(name, price, weight, category, species));
                                    break;
                                }
                            case "DairyProduct":
                                {
                                    string name = char.ToUpper(info[1][0]) + info[1][1..];
                                    int price = Convert.ToInt32(info[2]);
                                    int weight = Convert.ToInt32(info[3]);                                 
                                    if (!DateTime.TryParse(info[4], out DateTime date))
                                    {
                                        throw new InvalidDataException("Неправильний формат дати");
                                    }                                 
                                    products.Add(new Dairy_products(name, price,weight, date));
                                    break;
                                }     
                            default:
                                {
                                    throw new ArgumentException("Тип продукту введений не коректно");
                                }

                        }
                     

                    }
                    catch (Exception ex)
                    {
                    errorsWorker.AddError(ex, currLine);
                    }
                }
            
        }
        public void ProductFromFile(string fileName)
        {
            for (int i = 0; i < 5 && !File.Exists(fileName); i++)
            {
                Console.WriteLine($"Імя файлу введено не вірно введіть будь ласка знову, у вас залижилося 5-{i} спроб ");
                fileName = Console.ReadLine();
            }
            using var sourceReader = new StreamReader(File.Exists(fileName) ? fileName : @"list.txt");
            ProductFromFile(sourceReader);
        }
        public static IEnumerable<Product> StorageExcept(Storage storage1, Storage storage2)
        {
            if (storage1 == null || storage2 == null)
            {
                throw new ArgumentNullException("Один зі складів пустий");
            }
            return storage1.products.Except(storage2.products);
        }
        public static IEnumerable<Product> StorageIntersect(Storage storage1, Storage storage2)
        {
            if (storage1 == null || storage2 == null)
            {
                throw new ArgumentNullException("Один зі складів пустий");
            }
            return storage1.products.Intersect(storage2.products);
        }
        public static IEnumerable<Product> StorageUnion(Storage storage1, Storage storage2)
        {
            if (storage1 == null || storage2 == null)
            {
                throw new ArgumentNullException("Один зі складів пустий");
            }
            return storage1.products.Union(storage2.products);
        }
    }

}

