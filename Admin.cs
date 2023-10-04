using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_1
{


    public class Admin
    {
        public static List<Driver> drivers;

        // Constructor
        public Admin()
        {
            drivers = new List<Driver>();
        }

        // Function to add a new driver to the company's list
        public void addDriver()
        {
            Driver newDriver = new Driver();

            Console.WriteLine("Enter Driver Details:");
            Console.Write("Enter id of driver :");
            string id = Console.ReadLine();
            newDriver.Id = int.Parse(id);

            Console.Write("Name: ");
            newDriver.Name = Console.ReadLine();
            Console.Write("Age: ");
            int age;
            if (int.TryParse(Console.ReadLine(), out age) && age > 17)
            {
                newDriver.Age = age;
            }
            else
            {
                Console.WriteLine("Invalid age input.");
                return;
            }
            Console.Write("Gender: ");
            newDriver.Gender = Console.ReadLine();
            Console.Write("Address: ");
            newDriver.Address = Console.ReadLine();
            Console.Write("Phone Number: ");
            newDriver.PhoneNo = Console.ReadLine();
            Console.Write("Vehicle Type (bike, rikshaw, car): ");
            string vehicleType = Console.ReadLine().ToLower();
            if (vehicleType == "bike" || vehicleType == "rikshaw" || vehicleType == "car")
            {
                newDriver.Vehicle.Type = vehicleType;
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
                return;
            }
            Console.Write("Vehicle Model: ");
            newDriver.Vehicle.Model = Console.ReadLine();
            Console.Write("License Plate Number: ");
            newDriver.Vehicle.LicensePlate = Console.ReadLine();

            Console.Write("Current Latitude: ");
            float latitude;
            if (float.TryParse(Console.ReadLine(), out latitude))
            {
                newDriver.CurrentLocation.Latitude = latitude;
            }
            else
            {
                Console.WriteLine("Invalid latitude input.....");
                return;
            }

            Console.Write("Current Longitude: ");
            float longitude;
            if (float.TryParse(Console.ReadLine(), out longitude))
            {
                newDriver.CurrentLocation.Longitude = longitude;
            }
            else
            {
                Console.WriteLine("Invalid longitude input.....");
                return;
            }

            drivers.Add(newDriver);
            Console.WriteLine("Driver added successfully.....");
        }

        // Function to update an existing driver in the list
        public void updateDriver(int driverId)
        {
            // Find the driver by ID
            Driver driverToUpdate = drivers.Find(driver => driver.Id == driverId);

            if (driverToUpdate != null)
            {
                Console.WriteLine("Select field to update:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Age");
                Console.WriteLine("3. Gender");
                Console.WriteLine("4. Address");
                Console.WriteLine("5. Phone Number");
                Console.WriteLine("6. Vehicle Type");
                Console.WriteLine("7. Vehicle Model");
                Console.WriteLine("8. License Plate Number");
                Console.WriteLine("9. Current Latitude");
                Console.WriteLine("10. Current Longitude");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("New Name: ");
                            string name = Console.ReadLine();
                            driverToUpdate.Name = name.ToLower();

                            break;
                        case 2:
                            Console.Write("New Age: ");
                            int age;
                            if (int.TryParse(Console.ReadLine(), out age))
                            {
                                driverToUpdate.Age = age;
                            }
                            else
                            {
                                Console.WriteLine("Invalid age input.");
                            }
                            break;
                        case 3:
                            Console.Write("New Gender: ");
                            driverToUpdate.Gender = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("New Address: ");
                            driverToUpdate.Address = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("New Phone Number: ");
                            driverToUpdate.PhoneNo = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("New Vehicle Type: ");
                            string vehicleType = Console.ReadLine().ToLower();
                            if (vehicleType == "bike" || vehicleType == "rikshaw" || vehicleType == "car")
                            {
                                driverToUpdate.Vehicle.Type = vehicleType;
                            }
                            else
                            {
                                Console.WriteLine("Invalid vehicle type.");
                            }
                            break;
                        case 7:
                            Console.Write("New Vehicle Model: ");
                            driverToUpdate.Vehicle.Model = Console.ReadLine();
                            break;
                        case 8:
                            Console.Write("New License Plate Number: ");
                            driverToUpdate.Vehicle.LicensePlate = Console.ReadLine();
                            break;
                        case 9:
                            Console.Write("New Current Latitude: ");
                            float latitude;
                            if (float.TryParse(Console.ReadLine(), out latitude))
                            {
                                driverToUpdate.CurrentLocation.Latitude = latitude;
                            }
                            else
                            {
                                Console.WriteLine("Invalid latitude input.");
                            }
                            break;
                        case 10:
                            Console.Write("New Current Longitude: ");
                            float longitude;
                            if (float.TryParse(Console.ReadLine(), out longitude))
                            {
                                driverToUpdate.CurrentLocation.Longitude = longitude;
                            }
                            else
                            {
                                Console.WriteLine("Invalid longitude input.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice input.");
                }
            }
            else
            {
                Console.WriteLine("Driver not found with ID: " + driverId);
            }
        }

        // Function to remove a driver from the list
        public void removeDriver(int driverId)
        {
            // Find the index of the driver by ID
            int index = -1;
            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].Id == driverId)
                {
                    index = i;
                    break;
                }
            }
            //Console.WriteLine(index);

            if (index != -1)
            {
                drivers.RemoveAt(index);
                Console.WriteLine("Driver with ID " + driverId + " removed successfully.");
            }
            else
            {
                Console.WriteLine("Driver not found with ID: " + driverId);
            }
        }

        // Function to search for drivers based on search parameters
        public void searchDrivers(string searchParameter, string searchValue)
        {
            List<Driver> searchResults = new List<Driver>();

            switch (searchParameter.ToLower())
            {
                case "name":
                    searchResults = drivers.FindAll(driver => driver.Name.ToLower().Contains(searchValue.ToLower()));
                    break;
                case "age":
                    if (int.TryParse(searchValue, out int age))
                    {
                        searchResults = drivers.FindAll(driver => driver.Age == age);
                    }
                    else
                    {
                        Console.WriteLine("Invalid age input.");
                        return;
                    }
                    break;
                case "gender":
                    searchResults = drivers.FindAll(driver => driver.Gender.ToLower().Contains(searchValue.ToLower()));
                    break;
                case "address":
                    searchResults = drivers.FindAll(driver => driver.Address.ToLower().Contains(searchValue.ToLower()));
                    break;
                case "phonenumber":
                    searchResults = drivers.FindAll(driver => driver.PhoneNo.Contains(searchValue));
                    break;
                default:
                    Console.WriteLine("Invalid search parameter.");
                    return;
            }

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search Results:");
                Console.WriteLine("ID\tName\tAge\tGender\tAddress\tPhone Number\tVehicle Type\tVehicle Model\tLicense Plate");
                foreach (var driver in searchResults)
                {
                    Console.WriteLine(driver.Id + "\t" + driver.Name + "\t" + driver.Age + "\t" + driver.Gender + "\t" +
                        driver.Address + "\t" + driver.PhoneNo + "\t" + driver.Vehicle.Type + "\t" + driver.Vehicle.Model + "\t" +
                        driver.Vehicle.LicensePlate);
                }
            }
            else
            {
                Console.WriteLine("No drivers found based on the search criteria.");
            }
        }
    }

}
