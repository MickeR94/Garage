using Garage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    internal class Garage
    {

        // Private fields/attributes
        private Vehicle[] _vehicles;
        
        // Garage Constructor --> ask Michael if it needs a second parameter for "populating the garage with a specific number of vehicles from start
        public Garage(int capacity){
            _vehicles = new Vehicle[capacity];
        }

        // Property
        public int NumParkingSpots
        {
            get
            {
                return _vehicles.Length; // The length of the vehicles-array is how many total spots there are in the garage --> capacity
            }
        }

        // Add a vehicle to the array. TODO: Make restrictions so that the same vehicle can't be added twice. Nested if-statement? Perhaps that'd mean poor performance. O(n^2)?
        public bool AddVehicle(Vehicle vehicle)
        {
            
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == vehicle)
                {
                    Console.WriteLine("Vehicle already exists");
                    return false;
                }
                else if (_vehicles[i] == null) // Found an empty parking spot
                {
                    _vehicles[i] = vehicle;
                    Console.WriteLine("Vehicle was successfully parked!");
                    return true; // true, as in the vehicle has been sucessfully parked
                }
            }
            Console.WriteLine("Sorry! There's no empty parking spots");
            return false;
        }


        public bool RemoveVehicle(string regNum)
        {
            for(int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] != null)
                {    
                    if (_vehicles[i].RegNum == regNum.ToUpper()) // The RegNum from the constructor in the Vehicle-class is already in .ToUpper(), hence only in-parameter is .ToUpper() here
                    {
                        _vehicles[i] = null;
                        Console.WriteLine($"Successfylly removed vehicle {regNum}");
                        return true;
                    }
                }
            }
            Console.WriteLine("No matching registration number found...");
            return false;
        }

        public Vehicle? SearchRegNum(string regNum) // '?' is there because the return could be null, i.e no registration number was found
        {
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] != null)
                {
                    if (_vehicles[i].RegNum == regNum.ToUpper())
                    {
                        return _vehicles[i];
                    }
                }
            }
            return null; // registration number was not found
        }

        // TODO: Method to search for a vehicle based on attributes such as "Black vehicles with four wheels" --> LINQ? Kind of looks like it could be a SQL query. 

        public Vehicle[] ListVehicles()
        {
            return _vehicles;
        }
    }
}
