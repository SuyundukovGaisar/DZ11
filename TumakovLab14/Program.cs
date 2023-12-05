using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(BuildingsCollection);
            object[] developerInfoAttributes = type.GetCustomAttributes(typeof(DeveloperOrganizationInfoAttribute), false);
            if (developerInfoAttributes.Length > 0 && developerInfoAttributes[0] is DeveloperOrganizationInfoAttribute)
            {
                DeveloperOrganizationInfoAttribute developerInfo = (DeveloperOrganizationInfoAttribute)developerInfoAttributes[0];
                Console.WriteLine($"Разработчик: {developerInfo.Name}");
                Console.WriteLine($"Организация: {developerInfo.Organization}");
            }
        }
    }
}
