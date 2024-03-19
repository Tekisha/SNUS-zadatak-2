using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak2.Entity;
using Zadatak2.repository.interfaces;

namespace Zadatak2.repository.implementations
{
    public class UpgradedSoldPhonesDB : SoldPhonesDB, ISoldPhonesDBUpgrade
    {
        public List<MobilePhone> Get4GHuaweiPhones()
        {
            return SoldPhones.Where(phone => phone.Manufacturer.Equals("Huawei", StringComparison.OrdinalIgnoreCase) && phone.Network.Equals("4G", StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
