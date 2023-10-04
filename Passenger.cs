using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_1
{
    public class Passenger
    {
        private string name;
        private string phoneNo;

        // Default Constructor for Passenger Class
        public Passenger()
        {
            name = " ";
            phoneNo = " ";
        }

        // Constructor with parameters
        public Passenger(string name, string phoneNo)
        {
            this.name = name;
            this.phoneNo = phoneNo;
        }

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set
            {
                // Validation: Only digits allowed for phone number
                foreach (char digit in value)
                {
                    if (!char.IsDigit(digit))
                    {
                        Console.WriteLine("Invalid phone number. Only digits are allowed.");
                        return;
                    }
                }
                phoneNo = value;
            }
        }

        // Method to book a ride
        public Ride BookRide()
        {
            Console.Write("Enter starting location (latitude, longitude): ");
            string[] startLocation = Console.ReadLine().Split(',');
            float startLatitude = float.Parse(startLocation[0]);
            float startLongitude = float.Parse(startLocation[1]);

            Console.Write("Enter ending location (latitude, longitude): ");
            string[] endLocation = Console.ReadLine().Split(',');
            float endLatitude = float.Parse(endLocation[0]);
            float endLongitude = float.Parse(endLocation[1]);

            Ride ride = new Ride
            {
                StartLocation = new Location { Latitude = startLatitude, Longitude = startLongitude },
                EndLocation = new Location { Latitude = endLatitude, Longitude = endLongitude },
                Passenger = this
            };

            return ride;
        }

        // Method for passenger to give rating
        public int GiveRating()
        {
            Console.Write("Rate your ride from 1 to 5: ");
            int rating;
            if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
            {
                return rating;
            }
            else
            {
                Console.WriteLine("Invalid rating. Please provide a rating from 1 to 5.");
                // Return a default rating (for example, 3) in case of invalid input
                return 3;
            }
        }
    }


}
