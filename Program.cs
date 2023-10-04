using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ASS_1
{
    class Program
    {
        static List<Driver> driv = Admin.drivers;
        static List<Ride> rides = new List<Ride>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("WELCOME TO MYRIDE");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");
                Console.WriteLine("4. Exit");
                Console.Write("Press 1 to 3 to select an option:");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            BookRide();
                            break;
                        case 2:
                            EnterAsDriver();
                            break;
                        case 3:
                            EnterAsAdmin();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void BookRide()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone no: ");
            string phoneNo = Console.ReadLine();
            Console.Write("Enter Start Location: ");
            string[] startLocation = Console.ReadLine().Split(',');
            float startLatitude = float.Parse(startLocation[0]);
            float startLongitude = float.Parse(startLocation[1]);
            Console.Write("Enter End Location (latitude, longitude): ");
            string[] endLocation = Console.ReadLine().Split(',');
            float endLatitude = float.Parse(endLocation[0]);
            float endLongitude = float.Parse(endLocation[1]);
            Console.Write("Enter Ride Type: ");
            string rideType = Console.ReadLine();
            
            Vehicle vehicle = new Vehicle { Type = rideType };  
            Driver driver = new Driver { Vehicle = vehicle }; 
            Passenger passenger = new Passenger { Name = name, PhoneNo = phoneNo };
            Ride ride = new Ride
            {
                StartLocation = new Location { Latitude = startLatitude, Longitude = startLongitude },
                EndLocation = new Location { Latitude = endLatitude, Longitude = endLongitude },
                Passenger = passenger,
                Driver  = driver

            };
            
            ride.Price = ride.calculatePrice();

            Console.WriteLine("-------------------- THANK YOU ------------------");
            Console.WriteLine($"Price for this ride is: {ride.Price}");
            Console.Write("Enter 'Y' if you want to Book the ride, enter 'N' if you want to cancel operation:");
            string decision = Console.ReadLine();
            if (decision.ToUpper() == "Y")
            {
                rides.Add(ride);
                Console.WriteLine("Happy Travel…!");
                passenger.GiveRating();
            }
            else
            {
                Console.WriteLine("Ride booking canceled.");
            }
        }

        static void EnterAsDriver()
        {
            Console.Write("Enter ID: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (driv == null)
                {
                    driv = Admin.drivers;
                }
                Console.Write("Enter Name: ");
                string name=Console.ReadLine();
                name = name.ToLower();
                Driver driver = driv.Find(d => d.Id == id && d.Name == name);
                Console.WriteLine(driver);

                if (driver != null)
                {
                    Console.WriteLine($"Hello {driver.Name}!");
                    Console.Write("Enter your current Location (latitude, longitude): ");
                    string[] currentLocation = Console.ReadLine().Split(',');
                    float currentLatitude = float.Parse(currentLocation[0]);
                    float currentLongitude = float.Parse(currentLocation[1]);
                    driver.updateLocation(currentLatitude, currentLongitude);

                    bool isDriverMenuOpen = true;
                    while (isDriverMenuOpen)
                    {
                        Console.WriteLine("1. Change availability");
                        Console.WriteLine("2. Change Location");
                        Console.WriteLine("3. Exit as Driver");
                        Console.Write("Select an option: ");
                        int driverChoice;
                        if (int.TryParse(Console.ReadLine(), out driverChoice))
                        {
                            switch (driverChoice)
                            {
                                case 1:
                                    Console.Write("Enter 'Available' or 'Unavailable': ");
                                    string availabilityChoice = Console.ReadLine().ToUpper();
                                    driver.Availability = availabilityChoice == "AVAILABLE";
                                    break;
                                case 2:
                                    Console.Write("Enter new Location (latitude, longitude): ");
                                    string[] newLocation = Console.ReadLine().Split(',');
                                    float newLatitude = float.Parse(newLocation[0]);
                                    float newLongitude = float.Parse(newLocation[1]);
                                    driver.updateLocation(newLatitude, newLongitude);
                                    break;
                                case 3:
                                    isDriverMenuOpen = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Driver not found. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for ID. Please enter a number.");
            }
        }

        static void EnterAsAdmin()
        {
            Admin admin = new Admin();
            bool isAdminLoggedIn = true;
            while (isAdminLoggedIn)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter as Admin:");
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Update Driver");
                Console.WriteLine("4. Search Driver");
                Console.WriteLine("5. Exit as Admin");
                Console.Write("Select an option: ");
                int adminChoice;
                string input;
                if (int.TryParse(Console.ReadLine(), out adminChoice))
                {

                    switch (adminChoice)
                    {
                        case 1:
                            admin.addDriver();
                            break;
                        case 2:
                            Console.Write("Enter an integer ID:");
                            input = Console.ReadLine();
                            try
                            {
                                int id = int.Parse(input);
                                admin.removeDriver(id);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }

                            break;
                        case 3:
                            Console.Write("Enter an integer ID:");
                            input = Console.ReadLine();
                            try
                            {
                                int id = int.Parse(input);
                                admin.updateDriver(id);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }

                            break;
                        case 4:
                            Console.Write("Enter parameter on basis of which you want to search ( name , age , gender , address ,  phonenumber ) : ");
                            string input1 = Console.ReadLine();
                            Console.Write($"Enter specific value of {input1} for which you want to search : ");
                            string input2 = Console.ReadLine();
                            admin.searchDrivers(input1,input2);
                            

                            break;
                        case 5:
                            isAdminLoggedIn = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

    }
}

