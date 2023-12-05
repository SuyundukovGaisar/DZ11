using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab14
{
    internal class Building
    {
        public static int nextBuildingNumber { get; set; }
        public int BuildingNumber { get; set; }
        public int Height { get; set; }
        public int Floors { get; set; }
        public int Floats { get; set; }
        public int entrances { get; set; }
        public int HeightFloor { get; set; }
        public int FloatsEntrance { get; set; }
        public int FloatsFloor { get; set; }

        internal Building()
        {
            BuildingNumber = NextBuildingNumber();
        }
        internal Building(int height, int floors)
        {
            BuildingNumber = NextBuildingNumber();
            Height = height;
            Floors = floors;
        }
        internal Building(int height, int floors, int floats, int entrances)
        {
            BuildingNumber = NextBuildingNumber();
            Height = height;
            Floors = floors;
            Floats = floats;
            this.entrances = entrances;
        }
        internal Building(int height, int floors, int floats, int entrances, int heightFloor, int floatsEntrance, int floatsFloor)
        {
            BuildingNumber = NextBuildingNumber();
            Height = height;
            Floors = floors;
            Floats = floats;
            this.entrances = entrances;
            HeightFloor = heightFloor;
            FloatsEntrance = floatsEntrance;
            FloatsFloor = floatsFloor;
        }
        public static int NextBuildingNumber()
        {
            return ++nextBuildingNumber;
        }
        public void Print()
        {
            Console.WriteLine($"Номер здания: {BuildingNumber}");
            Console.WriteLine($"Высота: {Height}");
            Console.WriteLine($"Кол-во этажей: {Floors}");
            Console.WriteLine($"Кол-во квартир: {Floats}");
            Console.WriteLine($"Кол-во подъездов: {entrances}");
            Console.WriteLine($"Следующий номер здания: {nextBuildingNumber = NextBuildingNumber()}");
        }
        public void CalculateHeightFloor()
        {
            HeightFloor = Height / Floors;
        }

        public void CalculateFloatsEntrance()
        {
            FloatsEntrance = Floats / entrances;
        }

        public void CalculateFloatsFloor()
        {
            FloatsFloor = Floats / Floors;
        }
        public void PrintCalculaions()
        {
            Console.WriteLine($"Высота этажа: {HeightFloor}");
            Console.WriteLine($"Кол-во квартир в подъезде: {FloatsEntrance}");
            Console.WriteLine($"Кол-во квартир на этаже: {FloatsFloor}");
        }
    }
}
