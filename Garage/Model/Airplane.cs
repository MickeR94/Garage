using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Model
{
    internal class Airplane : Vehicle
    {

        private int _numEngines;

        public int NumEngines
        {
            get
            {
                return _numEngines;
            }
            set
            {
                _numEngines = value;
            }
        }

        // I don't like horsePower for a plane. Airplane has a jet engine --> kN
        public Airplane (string regNum, string color, int numWheels, int horsePower, int numEngines) : base(regNum, color, numWheels, horsePower)
        {
            _numEngines = numEngines;
        }
    }
}
