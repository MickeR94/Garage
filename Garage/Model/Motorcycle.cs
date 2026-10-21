using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Model
{
    internal class Motorcycle : Vehicle
    {
        private decimal _cylinderVolume;

        public decimal CylinderVolume{
            get
            {
                return _cylinderVolume;
            }
            set
            {
                _cylinderVolume = value;
            }
        }

        public Motorcycle (string regNum, string color, int numWheels, int horsePower, decimal cylinderVolume) : base(regNum, color, numWheels, horsePower)
        {
            _cylinderVolume = cylinderVolume;
        }
    }
}
