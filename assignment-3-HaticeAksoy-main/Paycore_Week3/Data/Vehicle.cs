using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycore_Week3
{
    public class Vehicle
    {
        public virtual long Id { get; set; }
        public virtual string VehicleName { get; set; }
        public virtual string VehiclePlate { get; set; }
    }
}
