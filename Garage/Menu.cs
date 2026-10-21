using System;
using System.Collections.Generic;
using System.Text;
using Garage.Model;

namespace Garage
{
    public class Menu
    {
        bool runMenu = true;
        private Garage? _garage;

        public bool MainMenu()
        {
            /* Console.Write("Enter number of parking spots: ");
            string parkingSpotsString = Console.ReadLine(); // TODO: Should not be 0
            int parkingSpots = int.Parse(parkingSpotsString); // TODO: Check why TryParse doesn't work here 
            */

            while (runMenu)
            {
                Console.WriteLine("What would you like to do: ");
                Console.WriteLine("1) Create a new garage-system");
                Console.WriteLine("2) Add a vehicle");
                Console.WriteLine("3) Remove a vehicle");
                Console.WriteLine("4) List all parked vehicles");
                Console.WriteLine("5) Search vehicle registration number");
                Console.WriteLine("6) Search vehicle based on features");
                Console.WriteLine("7) Exit");
                string result = Console.ReadLine();

                switch (result)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter garage capacity for the new garage: ");
                        string capacityString = Console.ReadLine();
                        int capacity = int.Parse(capacityString);
                        _garage = new Garage(capacity);   // New Garage object is created with the number of parking spots = capacity

                        /*Console.WriteLine("Do you want to reserve any parking spots for  a specific vehicle? (Y/N): ");
                        string yesNo = Console.ReadLine();
                        if(yesNo == "Y") 
                        {
                            Console.WriteLine("Number of vehicles to add to the garage: ");
                            string vehiclesToAdd = Console.ReadLine();
                            int numVehiclesToAdd = int.Parse(vehiclesToAdd);

                            for (int i = 0; i < vehiclesToAdd.Length; i++)
                            {
                                Console.WriteLine($"Please enter the registration number of vehicle {i+1}: ");
                                string regNumString = Console.ReadLine();
                                Vehicle regNum = regNumString;
                                _garage.AddVehicle(regNum);
              
                            }
                            
                        }*/
                        break;

                    case "2":
                        Console.Clear();

                        Console.WriteLine("What type of vehicle whould you like to add? ");
                        Console.WriteLine("1. Airplane");
                        Console.WriteLine("2. Boat");
                        Console.WriteLine("3. Bus");
                        Console.WriteLine("4. Car");
                        Console.WriteLine("5. Motorcycle");
                        Console.Write("Please enter the number corresponding to the vehicle of your choice: ");
                        string choice = Console.ReadLine();


                        Console.Write("Enter the vehicle's registration number to add: ");
                        string parkRegNum = Console.ReadLine();
                        Console.Write("Vehicle color: ");
                        string color = Console.ReadLine();
                        Console.Write("Number of wheels: ");
                        string numWheelsString = Console.ReadLine();
                        int numWheels = int.Parse(numWheelsString);
                        Console.Write("Horse Power: ");
                        string horsePwrString = Console.ReadLine();
                        int horsePwr = int.Parse(horsePwrString);

                        if(choice == "1")
                        {
                            Console.Write("Number of engines: ");
                            string numEnginesString = Console.ReadLine();
                            int numEngines = int.Parse(numEnginesString);
                            Airplane airplane = new Airplane(parkRegNum, color, numWheels, horsePwr, numEngines); // Creating an airplane object
                            _garage.AddVehicle(airplane);
                        }
                        else if(choice == "2")
                        {
                            Console.Write("Length of boat (feet): ");
                            string feetString = Console.ReadLine();
                            int feet = int.Parse(feetString);
                            Console.WriteLine("Knots: ");
                            string knotsString = Console.ReadLine();
                            int knots = int.Parse(knotsString);

                            Boat boat = new Boat(parkRegNum, color, numWheels, horsePwr, feet, knots);
                            _garage.AddVehicle(boat);
                        }
                        else if(choice == "3")
                        {
                            Console.Write("Number of seats: ");
                            string seatsString = Console.ReadLine();
                            int seats = int.Parse(seatsString);
                            Console.Write("Length of bus: ");
                            string lengthString = Console.ReadLine();
                            int length = int.Parse(lengthString);

                            Bus bus = new Bus(parkRegNum, color, numWheels, horsePwr, seats, length);
                            _garage.AddVehicle(bus);

                        }
                        else if (choice == "4")
                        {
                            Console.Write("Enter Fuel type, Gas/Diesel: ");
                            string fuel = Console.ReadLine();

                            Car car = new Car(parkRegNum, color, numWheels, horsePwr, fuel);
                            _garage.AddVehicle(car);
                        }
                        else if (choice == "5")
                        {
                            Console.Write("Enter cylinder volume: ");
                            string volumeString = Console.ReadLine();
                            decimal volume = decimal.Parse(volumeString);

                            Motorcycle motorcycle = new Motorcycle(parkRegNum, color, numWheels, horsePwr, volume);
                            _garage.AddVehicle(motorcycle);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number between 1-5");
                        }
                        break;

                    case "3":                        
                        Console.Clear();
                        if (_garage == null)
                        {
                            Console.WriteLine("Cannot remove as the garage is empty. Please create a garage and add vehicles first");
                            Console.ReadLine();
                            break;
                        }
                        
                        
                        Console.Write("Enter the vehicle's registration number to remove: ");
                        string removeRegNum = Console.ReadLine();
                        bool remove = _garage.RemoveVehicle(removeRegNum);
                        if (remove)
                        {
                            Console.WriteLine($"Vehicle {removeRegNum} was removed successfully!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Vehicle {removeRegNum} could not be removed.");
                            Console.ReadLine();
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("*** LISTING ALL VEHICLES IN THE GARAGE ***");
                        Vehicle[] test = _garage.ListVehicles();                        
                        for (int i = 0; i < test.Length; i++)
                        {
                            Console.Write($"    |  {test[i]}  "); // TODO: There's a bug here. says that test[i] is null
                        }
                        Console.Write("    |");
                        Console.ReadLine();

                        break;

                    // TODO: Would be much cooler if the lookup returned the index of where the vehicle is parked. Work on adding that functionality
                    case "5":
                        Console.Clear();
                        if (_garage == null)
                        {
                            Console.WriteLine("Cannot find as the garage is empty. Please create a garage and add vehicles first");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Enter the vehicle's registration number to search: ");
                        string searchRegNum = Console.ReadLine();
                        Vehicle lookup = _garage.SearchRegNum(searchRegNum);
                        if (lookup == null)
                        {
                            Console.WriteLine("No matching registration number found");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"Vehicle found! Registration number: {lookup.RegNum} - Horse power: {lookup.HorsePower} - Number of Wheels: {lookup.NumWheels}");
                            Console.ReadKey();
                        }
                        
                        break;

                    case "6":
                        Console.Clear();
                        int lookupNumWheels;
                        int lookupVehicleHorsePower;
                        if (_garage == null)
                        {
                            Console.WriteLine("Cannot search for vehicle features as the garage is empty. Please create a garage and add vehicles first");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Enter the vehicle's color: "); 
                        string lookupVehicleColor = Console.ReadLine();
                        Console.Write("Enter the vehicle's number of wheels: ");
                        string lookupVehicleNumWheelsString = Console.ReadLine();
                        if(lookupVehicleNumWheelsString == "")
                        {
                            lookupNumWheels = -1;
                        }
                        else
                        {
                            lookupNumWheels = int.Parse(lookupVehicleNumWheelsString);
                        }                        
                        Console.Write("Enter the vehicle's horse power: ");
                        string lookupVehicleHorsePowerString = Console.ReadLine();
                        if(lookupVehicleHorsePowerString == "")
                        {
                            lookupVehicleHorsePower = -1;
                        }
                        else
                        {
                            lookupVehicleHorsePower = int.Parse(lookupVehicleHorsePowerString);
                        }
                        

                        Vehicle[] parkedVehicles = _garage.ListVehicles();
                        for (int i = 0; i < parkedVehicles.Length; i++)
                        {
                            if(parkedVehicles[i] != null)
                            {
                                if (lookupVehicleColor != "" && lookupVehicleColor != parkedVehicles[i].Color)
                                {
                                    continue;
                                }
                                else if (lookupNumWheels != -1 && lookupNumWheels != parkedVehicles[i].NumWheels){
                                    continue;
                                }
                                else if (lookupVehicleHorsePower != -1 && lookupVehicleHorsePower != parkedVehicles[i].HorsePower)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.Write($"** {parkedVehicles[i]}");
                                }
                            }
                        }

                        break;

                    case "7":
                        return false; // End the while-loop --> Exit program
                } 
                
            }
            return runMenu;
        }

    }
}
