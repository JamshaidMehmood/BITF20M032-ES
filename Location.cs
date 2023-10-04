using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_1
{
    public class Location
    {
        private float latitude;
        private float longitude;

        // Property for Latitude
        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        // Property for Longitude
        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        // Function to Set Location
        public void setLocation(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }


}
