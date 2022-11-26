using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Autopark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Car car1 = new Car();
            Car car2 = new Car("merz");
            Car car3 = new Car(12d);
            Car car4 = new Car(2004);
            Car car5 = new Car("KIA", 15d, 2007);
            //
            // Console.WriteLine(car1);
            // Console.WriteLine(car2);
            // Console.WriteLine(car3);
            // Console.WriteLine(car4);
            // Console.WriteLine(car5);
            
            PassengerCar pc = new PassengerCar();
            Dictionary<string, int> dic = new Dictionary<string, int>()
                    { { "gaika", 2005 }, { "lampa", 2006 }, { "pharah", 2007 } };
            PassengerCar pac = new PassengerCar("zver",8d,2001,6, dic);
            // Console.WriteLine(pac.GetReplacementYear("gaika"));
            // pac.AddServiceBookNote("zerkalo", 2008);
            pc.AddServiceBookNote("gaika", 2004);
            // Console.WriteLine(pc.ToString());
            // Console.WriteLine(pac.ToString());

            Truck truck1 = new Truck();
            Dictionary<string, int> dict = new Dictionary<string, int>()
                    { { "ozon box", 10 }, { "yandex", 1 }, { "makaroni", 1 } };
            Truck truck2 = new Truck("mitsubishi", 9.3, 1997, 2000, "Kol9", dict);
            truck1.AddLoad("chicken", 200);
            // truck2.RemoveLoad("ahaha");
            // truck2.RemoveLoad("yandex");
            truck1.SetDriverName("Den Bozhiy Ivan");
            // truck1.PrintCurrentLoad();
            // truck2.PrintCurrentLoad();
            // Console.WriteLine(truck1.ToString());
            // Console.WriteLine(truck2.ToString());

            Autopark autopark1 = new Autopark();
            List<Car> cars = new List<Car>(){car1, car2, car3, car4, car5};
            Autopark autopark2 = new Autopark("haha", cars);
            Console.WriteLine(autopark1.ToString());
            Console.WriteLine(autopark2.ToString());

            // Dictionary<int, int> dic = new Dictionary<int, int>();
            // dic.Remove(1);
            // dic.Remove(2);
            // dic.Remove(1);
            // Console.WriteLine(dic.ContainsKey(1));
        }
    }
}