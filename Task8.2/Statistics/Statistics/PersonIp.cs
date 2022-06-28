using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System;
namespace Statistics
{
    internal class PersonIp
    {
        private string ip;
        private DateTime time;
        DayOfTheWeek dayOfTheWeek;
        public DayOfTheWeek _DayOfTheWeek
        {
            get { return dayOfTheWeek; }
            set { dayOfTheWeek = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
            
        }
        public PersonIp() : this(string.Empty, default, default) { }
        public PersonIp(string _ip, DateTime _time, DayOfTheWeek _dayOfTheWeek)
        {
            this.ip = _ip;
            this.time = _time;
            this.dayOfTheWeek = _dayOfTheWeek;
        }
        public void InitInfo(string line)
        {
            var ipInfo = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] splitedIp = ipInfo[0].Split('.');
            if (splitedIp.Length != 4)
            {
                throw new ArgumentException("Айпі введено не коректно");
            }
            Ip = ipInfo[0];

            if (!DateTime.TryParse(ipInfo[1], out DateTime time))
            {
                throw new ArgumentException("Час введений не коректно");
            }
            Time = time;
            _DayOfTheWeek = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), ipInfo[2]);
        }
            
       
       
    }
}
