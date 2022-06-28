using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    public class Meat:Product
    {
        public enum Category
        {
            TopGrade,
            Grade1,
            Grade2

        }

        public enum Species
        {
            Lamb,
            Veal,
            Pork,
            Chicken
        }
        public Category MeatCategory { get; set; }
        public Species MeatSpecies { get; set; }
        
        public Meat()
        {

        }
        public Meat(string name, int price, int weigth, Category category, Species species):base(name, price, weigth)
        {
            MeatCategory = category;
            MeatSpecies = species;         
        }
        public override void percentСhange(int percent)
        {
            const int topGradePercent = 50;
            const int grade1Percent = 30;
            const int grade2Percent = 10;
            if (MeatCategory == Category.TopGrade)
            {
                Price=(int)(Price + Price * (percent+topGradePercent) / 100d);
            }
            else if (MeatCategory == Category.Grade1)
            {
                Price = (int)(Price + Price * (percent + grade1Percent) / 100d);
            }
            else if(MeatCategory == Category.Grade2)
            {
                Price = (int)(Price + Price * (percent + grade2Percent) / 100d);
            }
        }
    }
}
