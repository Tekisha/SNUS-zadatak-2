using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak2.repository.implementations;

namespace Zadatak2
{
    public static class MobilePhoneShop
    {
        public static UpgradedSoldPhonesDB SPDB;
        public static UpgradedOwnersDB ODB;

        static MobilePhoneShop() {
            SPDB = new UpgradedSoldPhonesDB();
            ODB = new UpgradedOwnersDB();
        }

        //Izvestaji
    }
}
