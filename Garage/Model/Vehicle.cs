using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Model
{
    internal class Vehicle
    {
        // Private fields/attributes
        private string _regNum; // Must be unique --> condition statement to check that string doesn't already exist
        private string _color;
        private int _numWheels;
        private int _horsePower;
        // private enum _layout; // layout --> front-wheel drive (FWD), rear-wheel drive (RWD), or four-wheel drive (4WD)

        /* private int numEngines;
        private decimal cylinderVolume;
        private enum fuelType; // enum or just regular string? private string fuelType;
        private int numSeats;
        private decimal length; // The length of the vehicle. Maybe a parking spot should not be able to accomodate any vehicle
        */


        // Constructor for the vehicle class
        public Vehicle(string regNum, string color, int numWheels, int horsePower){
            _regNum = regNum.ToUpper(); // Make the registration number upper case to satisfy the condition that the inputs ABC123, abc123, AbC123 will all find the same vehicle
            _color = color;
            _numWheels = numWheels;
            _horsePower = horsePower;
        }

        // Getter Setters (Properties) --> starts with Capitals: public string RegNum
        public string RegNum //Property associated with the field regNum
        {
            get // returns the value of the variable
            {
                return _regNum;
            }
            set // assigns a value to the variable.
            {
                _regNum = value;
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public int NumWheels
        {
            get
            {
                return _numWheels;
            }
            set
            {
                _numWheels = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return _horsePower;
            }
            set
            {
                _horsePower = value;
            }
        }
    }
}
