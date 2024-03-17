using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak2.Entity;

namespace Zadatak2.repository
{
    public interface ISoldPhonesDBUpgrade
    {
        List<MobilePhone> Get4GHuaweiPhones();
    }
}
