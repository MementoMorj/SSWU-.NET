using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity
{
    internal class AccountFlats
    {
        private int flatAmount;
        Quarter quarter;
    
        public int FlatAmount
        {
            get { return flatAmount; }
            set { 
                if(value < 0)
                {
                    throw new ArgumentException("Кількість квартир введена не коректно");

                }
                flatAmount = value; 
            }

        }
        public AccountFlats()
        {
     
        }
        public Flat[] flats;
        public AccountFlats(StreamReader reader)
        {
            var flatInfo = reader.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            flatAmount = flatInfo[0];
            flats = new Flat[flatInfo[0]];     
            quarter=(Quarter)flatInfo[1];
            for(int i = 0; i < flats.Length; i++)
            {
                flats[i] = new Flat();
                string line = reader.ReadLine();
                if(line != null)
                {
                    flats[i].InitInfo(line);
                }
            }
        }
       
        public string CreateTable()
        {       
            var table = new Table();
            table.SetHeaders("Номер квартири", "Прізвище власника", "Вхідні значення", "Вихідні значення", "Перша дата зняття", "Друга дата зняття", "Третя дата зняття", "До Сплати", "Днів з останнього зняття");
            foreach (var flat in flats)
            {
                flat.FormatToPrint(table);
            }
            table.AddRow($"Кількість квартир: {(flatAmount)}", $"Квартал: {(int)quarter}");
            return table.ToString();          
        }
        public string ReportForOneFlat(uint id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                foreach (var flat in flats)
                {
                    if (flat.FlatId == id)
                    {
                        stringBuilder.AppendLine(flat.ToString());
                    }
                }
            }
            catch
            {
                throw new ArgumentException("Дана квартира не стоїть на обліку");
            }
            return stringBuilder.ToString();
        }
        public uint IdOfTheBiggestDebt()
        {
            double maxDebt=0, debt;
            uint id=0;
            foreach(var flat in flats)
            {
                debt = flat.OutputDisplayElectricMeter - flat.InputDisplayElectricMeter;
                if(debt > maxDebt)
                {
                    maxDebt = debt;
                    id = flat.FlatId;
                }
            }
            return id;
        }
        public string FlatIdWithoutEnergy()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var flat in flats)
            {
                if (flat.OutputDisplayElectricMeter - flat.InputDisplayElectricMeter == 0) 
                {
                    stringBuilder.AppendLine($"Номер квартири що не використовувала енергію: {flat.FlatId}");
                }
              
            }
            return stringBuilder.ToString();
        }

    }
}
