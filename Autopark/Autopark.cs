using System;
using System.Collections.Generic;

namespace Autopark
{
    public class Autopark
    {
        private string
                _nameAutopark;

        private List<Car>
                _cars;

        public string NameAutopark
        {
            get => _nameAutopark;
            set => _nameAutopark = value;
        }
        public List<Car> Cars { get => _cars; set => _cars = value; }

        public Autopark()
        {
            NameAutopark = "Classic Autopark";
            Cars = new List<Car>();
        }

        public Autopark(string nameAutopark, List<Car> cars)
        {
            NameAutopark = nameAutopark;
            Cars = cars;
        }

        public string FormatCars()
        {
            string resultString = "Cars: ";
            if (Cars.Count > 0)
            {
                foreach (Car car in Cars)
                {
                    resultString += "\n" + car.ToString();
                }
            }
            else
            {
                resultString += "where cars?";
            }

            return resultString;
        }

        public override string ToString()
        {
            return $"Autopark name - {NameAutopark}\n" + FormatCars();
        }
    }
}