using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class VehicleTypeInfo
    {
        private int _TypeID;

        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        private string _TypeName;

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
    }
}
