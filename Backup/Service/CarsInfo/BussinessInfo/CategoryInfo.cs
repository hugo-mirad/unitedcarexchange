using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class CategoryInfo
    {
        private int _Category_id;

        public int Category_id
        {
            get { return _Category_id; }
            set { _Category_id = value; }
        }
        private string _Category_Name;

        public string Category_Name
        {
            get { return _Category_Name; }
            set { _Category_Name = value; }
        }

        private string _VehicleTypeID;

        public string VehicleTypeID
        {
            get { return _VehicleTypeID; }
            set { _VehicleTypeID = value; }
        }

        
    }
}
