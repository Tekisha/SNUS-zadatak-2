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
        public int Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Network { get; set; }
        public string? OS { get; set; }

    }
}
