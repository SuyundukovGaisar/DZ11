using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Building building1 = new Building { Height = 10, Floors = 5 };
            Building building2 = new Building { Height = 20, Floors = 10 };

            Console.WriteLine($"Building 1 - Number: {building1.BuildingNumber}, Height: {building1.Height}, Floors: {building1.Floors}");
            Console.WriteLine($"Building 2 - Number: {building2.BuildingNumber}, Height: {building2.Height}, Floors: {building2.Floors}");
        }
    }
}
