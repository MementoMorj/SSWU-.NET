using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity
{
    internal class Flat
    {
        private uint flatId;
        private string flatOwnerSurname;
        private double inputDisplayElectricMeter;
        private double outputDisplayElectricMeter;
        private const double price = 1.68;
        public readonly DateOnly[] dateTake = new DateOnly[3];

        #region properties
        public uint FlatId
        {
            get { return flatId; }
            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentException("Номер квартири не відповідає дісності");
                }
                flatId = value;
            }
        }
        public string FlatOwnerSurname
        {
            get { return flatOwnerSurname; }
            set { flatOwnerSurname = value; }
        }
        public double InputDisplayElectricMeter
        {
            get { return inputDisplayElectricMeter; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Вхідні показники лічильника меньші від нуля");
                }
                inputDisplayElectricMeter = value;
            }
        }
        public double OutputDisplayElectricMeter
        {
            get { return outputDisplayElectricMeter; }
            set
            {
                if (value < 0 || value < inputDisplayElectricMeter)
                {
                    throw new ArgumentException("Вихідні дані меньші від нуля або вхідних даних");
                }
                outputDisplayElectricMeter = value;
            }
        }
        #endregion
        public Flat() : this(default, "", default, default, default, default, default)
        {

        }
        public Flat(uint _flatId, string _flatOwnerSurname, double _inputDisplayElectricMeter, double _outputDisplayElectricMeter, params DateOnly[] _dateTake)
        {
            FlatId = _flatId;
            FlatOwnerSurname = _flatOwnerSurname;
            InputDisplayElectricMeter = _inputDisplayElectricMeter;
            OutputDisplayElectricMeter = _outputDisplayElectricMeter;
            for (int i = 0; i < dateTake.Length; i++)
            {
                dateTake[i] = _dateTake[i];
            }

        }
        public void InitInfo(string line)
        {
            var flatInfo = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (!uint.TryParse(flatInfo[0], out uint flatId)) {
                throw new ArgumentException("Номер квартири введений не коректно");
            }
            FlatId = flatId;

            FlatOwnerSurname = flatInfo[1];
            if (!double.TryParse(flatInfo[2], out double inputDisplayElectricMeter))
            {
                throw new ArgumentException("Вхідні показники введені не коректно");
            }
            InputDisplayElectricMeter = inputDisplayElectricMeter;

            if (!double.TryParse(flatInfo[3], out double outputDisplayElectricMeter))
            {
                throw new ArgumentException("Вихідні показники введені не коректно");
            }
            OutputDisplayElectricMeter = outputDisplayElectricMeter;
            for (int i = 4; i < 7; i++)
            {
                if (!DateOnly.TryParse(flatInfo[i], out DateOnly date))
                {
                    throw new InvalidDataException($"Неправильний формат дати {i - 3}");
                }
                dateTake[i - 4] = date;
            }
        }
        public int DaysFromLastCheck
        {
            get
            {
                return (int)(DateTime.Today - dateTake[2].ToDateTime(TimeOnly.Parse("10:00 PM"))).TotalDays;
            }
        }
        public double ToPay
        {
            get
            {
                return Math.Round((outputDisplayElectricMeter - inputDisplayElectricMeter) * price,2);
            }
        }
        
        public void FormatToPrint(Table table)
        {
 
            table.AddRow($"{flatId}", FlatOwnerSurname, $"{inputDisplayElectricMeter}", $"{outputDisplayElectricMeter}", $"{dateTake[0]:M}", $"{dateTake[1]:M}", $"{dateTake[2]:M}", $"{ToPay}", $"{DaysFromLastCheck}");     
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Номер квартири: {flatId},");
            stringBuilder.Append($"Прізвище власника: {FlatOwnerSurname},");
            stringBuilder.Append($"Вхідні значення: {InputDisplayElectricMeter}, ");
            stringBuilder.Append($"Вихідні значення: {OutputDisplayElectricMeter}, ");
            stringBuilder.Append($"Перша дата зняття: {dateTake[0]:M}, ");
            stringBuilder.Append($"Друга дата зняття: {dateTake[1]:M}, ");
            stringBuilder.Append($"Третя дата зняття: {dateTake[2]:M}, ");
            stringBuilder.Append($"До сплати: {ToPay}, ");
            stringBuilder.Append($"Днів від останнього зняття показників: {DaysFromLastCheck} ;");
            return stringBuilder.ToString();

        }
        

    }
}
