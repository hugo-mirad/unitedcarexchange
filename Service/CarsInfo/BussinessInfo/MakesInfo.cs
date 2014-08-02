using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]

    [Serializable] 


    public class MakesInfo
    {
        private int _makeID;

        public int MakeID
        {
            get { return _makeID; }
            set { _makeID = value; }
        }
        private string _make;

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        private string _RvtypeID;

        public string RvtypeID
        {
            get { return _RvtypeID; }
            set { _RvtypeID = value; }
        }

        
        private string _Priority;

        public string Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        private string _VehicleType;

        public string VehicleType
        {
            get { return _VehicleType; }
            set { _VehicleType = value; }
        }


    }
}
