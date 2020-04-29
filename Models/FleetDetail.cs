using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAssignment.Models
{
    public class FleetDetail
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public int DistanceTravelled { get; set; }
        public bool SufficientFuel { get; set; }
    }
}
