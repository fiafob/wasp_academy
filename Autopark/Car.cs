using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Autopark
{
    public class Car
    {
        private string
                _mark;

        private double
                _capacity;
        private int
                _yearOfManufacture;

        public string Mark { get => _mark; set => _mark = value; }
        public double Capacity { get => _capacity; set => _capacity = value; }
        public int YearOfManufacture
        {
            get => _yearOfManufacture;
            set => _yearOfManufacture = value;
        }
        
        public Car()
        {
            Mark = "Default";
            Capacity = 10d;
            YearOfManufacture = 1999;
        }

        public Car(string mark) : this()
        {
            Mark = mark;
        }
        public Car(double capacity) : this()
        {
            Capacity = capacity;
        }
        public Car(int yearOfManufacture) : this()
        {
            YearOfManufacture = yearOfManufacture;
        }

        public Car(string mark, double capacity, int yearOfManufacture)
        {
            Mark = mark;
            Capacity = capacity;
            YearOfManufacture = yearOfManufacture;
        }

        public override string ToString()
        {
            return $"Car: \n\tmark - {Mark}\n\tcapacity - {Capacity}\n\tyear of manufacture - {YearOfManufacture}";
        }
    }

    public class PassengerCar : Car
    {
        private int
                _passengersNumber;

        private Dictionary<string, int>
                _serviceBook;
        
        public int PassengersNumber
        {
            get => _passengersNumber;
            set => _passengersNumber = value;
        }

        public Dictionary<string, int> ServiceBook
        {
            get => _serviceBook;
            set => _serviceBook = value;
        }

        public PassengerCar() : base()
        {
            PassengersNumber = 5;
            ServiceBook = new Dictionary<string, int>();
        }

        public PassengerCar(string mark, double capacity,
                int yearOfManufacture, int passengersNumber,
                Dictionary<string, int> serviceBook) 
                : base(mark, capacity, yearOfManufacture)
        {
            PassengersNumber = passengersNumber;
            ServiceBook = serviceBook;
        }

        public int GetReplacementYear(string piece)
        {
            if (ServiceBook.ContainsKey(piece))
                return ServiceBook[piece];
            return 0;
        }
        public void AddServiceBookNote(string piece, int year)
        {
            ServiceBook[piece] = year;
        }
        public string FormatServiceBook()
        {
            string resultString = "Service book:";
            if (ServiceBook.Count > 0)
            {
                foreach (KeyValuePair<string, int> bookNote in ServiceBook)
                {
                    resultString += $"\n\t{bookNote.Key} - {bookNote.Value}";
                }
            }
            else
            {
                resultString += "\n\tNothing was written";
            }

            return resultString;
        }

        public void PrintServiceBook()
        {
            Console.WriteLine(FormatServiceBook());
        }

        public override string ToString()
        {
            string resultString = "Passenger " + base.ToString() +
                                  $"\n\tPassengers number - {PassengersNumber}";
            return resultString;
            
            
        }
    }

    public class Truck : Car
    {
        private double 
                _loadCapacity;

        private string
                _driverName;

        private Dictionary<string, int>
                _currentLoad;

        public double LoadCapacity { get => _loadCapacity; set => _loadCapacity = value; }
        public string DriverName { get => _driverName; set => _driverName = value; }

        public Dictionary<string, int> CurrentLoad
        {
            get => _currentLoad;
            set => _currentLoad = value;
        }

        public Truck() : base()
        {
            LoadCapacity = 1000;
            DriverName = "Ivanov Ivan";
            CurrentLoad = new Dictionary<string, int>();
        }

        public Truck(string mark, double capacity, int yearOfManufactury,
                double loadCapacity, string driverName,
                Dictionary<string, int> currentLoad)
            : base(mark, capacity, yearOfManufactury)
        {
            LoadCapacity = loadCapacity;
            DriverName = driverName;
            CurrentLoad = currentLoad;
        }

        public void SetDriverName(string newDriverName)
        {
            DriverName = newDriverName;
        }

        public void AddLoad(string nameOfLoad, int capacityOfLoad)
        {
            CurrentLoad.Add(nameOfLoad, capacityOfLoad);
        }

        public void RemoveLoad(string nameOfLoad)
        {
            CurrentLoad.Remove(nameOfLoad);
        }

        public string FormatCurrentLoad()
        {
            string resultString = "Current load: ";
            if (CurrentLoad.Count > 0)
            {
                foreach (KeyValuePair<string, int> load in CurrentLoad)
                {
                    resultString += $"\n\t{load.Key} - {load.Value}";
                }
            }
            else
            {
                resultString += "zero";
            }

            return resultString;
        }

        public void PrintCurrentLoad()
        {
            Console.WriteLine(FormatCurrentLoad());
        }

        public override string ToString()
        {
            return "Truck " + base.ToString() +
                   $"\n\tLoad capacity: {LoadCapacity}\n\tDriver\'s name: {DriverName}";
        }
    }
}