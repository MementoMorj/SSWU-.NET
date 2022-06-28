using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    internal class ErrorsWorker
    {
        private Dictionary<DateTime, string> errors;
       
        private string _filename;

        public ErrorsWorker(string fileName)
        {
            errors = new Dictionary<DateTime, string>();
            _filename = fileName;
        }
        public void AddError( Exception message, int currLine)
        {
            StreamWriter sw = new StreamWriter( _filename );
            DateTime date = DateTime.Now;
            sw.WriteLine($"{date}: {message.GetType().Name}: {message.Message}" + $" В лінії:{currLine} ");
            errors[date] = message.ToString();
            sw.Close();
            
        }
       
        public void ErrorsOfDate(DateTime date)
        {
           
            foreach (var error in errors)
            {
                var _date = error.Key;

                if (DateTime.Compare(date, _date) <= 0)
                {
                    Console.WriteLine($"{_date.Day}.{_date.Month}.{_date.Year} {_date.Hour}:{_date.Minute}:{_date.Second} - {error.Value}");
                }
            }

          
        }

    }
}
