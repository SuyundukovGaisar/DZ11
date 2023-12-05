using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab14
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DeveloperInfoAttribute : Attribute
    {
        public string Name { get; }
        public DateTime DateTime { get; }
        public DeveloperInfoAttribute(string developerName, string developmentDate)
        {
            Name = developerName;
            if (DateTime.TryParse(developmentDate, out DateTime Date))
            {
                DateTime = Date;
            }
            else
            {
                Console.WriteLine("Некорректный формат даты");
            }
        }
    }
}
