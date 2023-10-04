using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_1
{

    public class Ride
    {
        private Location startLocation;
        private Location endLocation;
        private int price;
        private Driver driver;
        private Passenger passenger;

        // Default Constructor for Ride Class
        public Ride()
        {
            startLocation = new Location();
            endLocation = new Location();
            driver = new Driver();
            passenger = new Passenger();
            price = 0;
        }

        // Property for Start Location
        public Location StartLocation
        {
            get { return startLocation; }
            set { startLocation = value; }
        }

        // Property for End Location
        public Location EndLocation
        {
            get { return endLocation; }
            set { endLocation = value; }
        }

        // Property for Price
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        // Property for Driver
        public Driver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        // Property for Passenger
        public Passenger Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }

        // Function to Assign Passenger to the Ride
        public void AssignPassenger(Passenger passenger)
        {
            this.passenger = passenger;
        }

        // Function to Assign Driver to the Ride
        public void AssignDriver(Driver[] drivers)
        {
            double shortestDistance = double.MaxValue;
            Driver closestDriver = null;

            foreach (var driver in drivers)
            {
                if (driver.Availability)
                {
                    double distance = CalculateDistance(StartLocation, driver.CurrentLocation);
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        closestDriver = driver;
                    }
                }
            }

            if (closestDriver != null)
            {
                driver = closestDriver;
                closestDriver.Availability = false;
            }
            else
            {
                Console.WriteLine("No available drivers for this ride.");
            }
        }

        // Function to Calculate Euclidean Distance between two locations
        private double CalculateDistance(Location location1, Location location2)
        {
            double deltaX = location1.Latitude - location2.Latitude;
            double deltaY = location1.Longitude - location2.Longitude;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        // Function to Get Start and End Locations from User
        public void GetLocations()
        {
            Console.Write("Enter start location (latitude, longitude): ");
            string[] startCoords = Console.ReadLine().Split(',');
            float startLatitude = float.Parse(startCoords[0]);
            float startLongitude = float.Parse(startCoords[1]);
            StartLocation = new Location { Latitude = startLatitude, Longitude = startLongitude };

            Console.Write("Enter end location (latitude, longitude): ");
            string[] endCoords = Console.ReadLine().Split(',');
            float endLatitude = float.Parse(endCoords[0]);
            float endLongitude = float.Parse(endCoords[1]);
            EndLocation = new Location { Latitude = endLatitude, Longitude = endLongitude };
        }

        // Function to Calculate Ride Price
        public int calculatePrice()
        {
            double distance = CalculateDistance(StartLocation, EndLocation);
            double fuelPrice = 318; 
            double commission = 0;

            string type = driver.Vehicle.Type.ToLower();

           //            Console.WriteLine("-----------------------" + type);

            if (type == "bike")
            {
                //Console.WriteLine("1");
                price = (int)((distance * fuelPrice * 50) / 1000);
                commission = 0.05 * price;
            }
            else if (type == "rickshaw")
            {
                price = (int)((distance * fuelPrice * 35) / 1000);
                commission = 0.1 * price;
            }
            else if (type == "car")
            {
                price = (int)((distance * fuelPrice * 15) / 1000);
                commission = 0.2 * price;
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
                return 0;
            }

            price = (int)(price + commission);
            int ridePrice = price;
            return ridePrice;
        }
    }
}
