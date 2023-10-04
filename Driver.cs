using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_1
{
    public class Driver
    {
        private int id;
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phoneNo;
        private Location currentLocation;
        private Vehicle vehicle;
        private bool availability;
        private List<int> rating;

        //Default Constructor for Driver Class 
        public Driver()
        {
            id = 0;
            name = " ";
            age = 0;
            gender = " ";
            address = " ";
            phoneNo = " ";
            currentLocation = new Location();
            vehicle = new Vehicle();
            availability = false;
            rating = new List<int>();
        }
        // property defining for Vehicle
        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
            }
        }
        //Property defining
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        //property defining for id
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        //property defining for Curent Location
        public Location CurrentLocation
        {
            get
            {
                return currentLocation;
            }
            set
            {
                currentLocation = value;
            }
        }
        // property defining for Gender
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        // property defining for age
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 18)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("The Driver is under age ....i.e.., the age must be greater than 17");
                    return;
                }

            }
        }
        //Property defining for address
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        //property Defining for Phone Number
        public string PhoneNo
        {
            get
            {
                return phoneNo;
            }

            set
            {
                //for a specific p# checking      
                foreach (char i in value)
                {

                    if (i < '0' || i > '9')
                    {
                        Console.WriteLine("This is an Invalid Number it should be of format XXXXXXXXXXX with no space snd - symbol");
                        return;
                    }
                }
                phoneNo = value;
            }
        }

        //property property  vehicle availability
        public bool Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
            }
        }
        //property property  vehicle Rating
        public List<int> Rating
        {
            get
            {
                return rating;
            }
            set
            {

                rating = value;
            }
        }


        //Methods ( member functions)

        public void updateAvailability()
        {
            if (availability == false)
            {
                availability = true;
            }
            else
            {
                availability = false;
            }
        }

        public double getRating()
        {
            if (rating.Count == 0)
            {
                return 0; // No ratings yet given by the passengers
            }

            double totalRating = 0;
            foreach (int rating in this.rating)
            {
                totalRating += rating;
            }
            return (totalRating / rating.Count);

        }
        //update location
        public void updateLocation(float lang, float longt)
        {
            currentLocation.setLocation(lang, longt);
        }


    }

}
