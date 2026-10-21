using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Model
{
    internal class Car : Vehicle // Car now inherit Vehicle --> an "is a" relationship
    {
        // Extra properties, unique to the Car-class
        private string _fuelType; 

        public string FuelType
        {
            get
            {
                return _fuelType;
            }
            set
            {
                _fuelType = value;
            }
        }

        // Constructor
        public Car(string regNum, string color, int numWheels, int horsePower, string fuelType) : base(regNum, color, numWheels, horsePower)
        {
            _fuelType = fuelType;
        }
    }
}
