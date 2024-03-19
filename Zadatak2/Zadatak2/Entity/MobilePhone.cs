using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2.Entity
{
    public class MobilePhone
    {
        public int OwnerId { get; set; }
        public required string Manufacturer { get; set; }
        public required string Model { get; set; }
        public required string Network { get; set; }
        public required string OS { get; set; }

    }
}
