using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak2.Entity;
using Zadatak2.repository.interfaces;

namespace Zadatak2.repository.implementations
{
    public class UpgradedOwnersDB : OwnersDB, IOwnersDBUpgrade
    {
        public List<Owner> GetPrimeAgedOwners()
        {
            throw new NotImplementedException();
        }
    }
}
