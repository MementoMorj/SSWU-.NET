using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    internal class Stats
    {
        public List<PersonIp> ips;
        public Stats()
        {
        }
        public Stats(StreamReader reader)
        {
            ips = new List<PersonIp>();
           
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var Ip = new PersonIp();
                Ip.InitInfo(line);
                ips.Add(Ip);
            }
        }
        public string StatisticInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var result = ips.GroupBy(x => x.Ip);
            foreach (var ip in result)
            {
                stringBuilder.AppendLine($"Ip: {ip.Key} кількість відвідувань за тиждень: {ip.Count()}");
                stringBuilder.AppendLine($"Найбільш популярний день тижня: {MostPopularDayOfTheWeek(ip.ToList())}");
                stringBuilder.AppendLine($"Найбільш популярний час: {GetMostPopularTime(ip.ToList())}");
            }
            stringBuilder.AppendLine($"Найбільш популярний час за весь час: {GetMostPopularTime(ips)}");
            return stringBuilder.ToString();
        }
        public string MostPopularDayOfTheWeek(List<PersonIp> ips)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var dayCount = ips.GroupBy(v => v._DayOfTheWeek);
            int maxCount = 0;           
            foreach (var day in dayCount)
            {
                if (day.Count() > maxCount)
                {
                    maxCount = day.Count();
                    stringBuilder.Clear();
                    stringBuilder.Append(day.Key.ToString());
                }
              
            }
            return stringBuilder.ToString();
        }
        string GetMostPopularTime(List<PersonIp> ips)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int maxCount = 0;
            for (int i = 0; i < 24; i++)
            {
                int count = ips.Where(v => v.Time.Hour == i).Count();
                if (count > maxCount)
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendLine($"від {i} до {i + 1}");
                    maxCount = count;
                }
              
            }
            return stringBuilder.ToString();
        }
    }
}
