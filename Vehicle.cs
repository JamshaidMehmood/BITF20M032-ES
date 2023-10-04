using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_1
{


    public class Vehicle
    {
        private string type;
        private string model;
        private string licensePlate;

        // Default Constructor for Vehicle Class
        public Vehicle()
        {
            type = "";
            model = "";
            licensePlate = "";
        }

        // Property for Vehicle Type
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // Property for Vehicle Model
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        // Property for License Plate
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }
    }


}
