using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab14
{
    [DeveloperOrganizationInfo("Alexandr", "Yandex")]
    internal class BuildingsCollection
    {
        private Building[] buildings = new Building[10];
        public Building this[int index]
        {
            get
            {
                if (index >= 0 && index < buildings.Length)
                {
                    return buildings[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона");
                }
            }
            set
            {
                buildings[index] = value;
            }
        }
    }
}
