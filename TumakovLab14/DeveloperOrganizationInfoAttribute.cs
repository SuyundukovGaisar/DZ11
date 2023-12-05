using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab14
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DeveloperOrganizationInfoAttribute : Attribute
    {
        public string Name { get; }
        public string Organization { get; }
        public DeveloperOrganizationInfoAttribute(string developerName, string developmentOrganization)
        {
            Name = developerName;
            Organization = developmentOrganization;
        }
    }
}
