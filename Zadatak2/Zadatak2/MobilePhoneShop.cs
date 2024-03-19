using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zadatak2.Entity;
using Zadatak2.repository.implementations;

namespace Zadatak2
{
    public static class MobilePhoneShop
    {
        public static UpgradedSoldPhonesDB SPDB;
        public static UpgradedOwnersDB ODB;

        static MobilePhoneShop() {
            InitializeData();
        }

        private static void InitializeData()
        {
            SPDB = new UpgradedSoldPhonesDB();
            SPDB.SoldPhones = LoadSoldPhonesFromXML();
            ODB = new UpgradedOwnersDB();
            ODB.Owners = LoadOwnersFromXML();
        }

        private static List<Owner> LoadOwnersFromXML()
        {
            var ownersXml = XElement.Load("data.xml").Descendants("Database").First(x => x.Attribute("name").Value == "Owners");

            if (ownersXml == null) return [];

            return ownersXml.Elements("Owner").Select(owner => new Owner
            {
                Id = int.Parse(owner.Attribute("Id")?.Value ?? "-1"),
                Age = int.Parse(owner.Attribute("Age")?.Value ?? "-1"),
                Name = owner.Value
            }).ToList();
        }

        private static List<MobilePhone> LoadSoldPhonesFromXML()
        {
            var soldPhonesXml = XElement.Load("data.xml").Descendants("Database").First(x => x.Attribute("name").Value == "Sold Phones");

            if (soldPhonesXml == null) return [];

            return soldPhonesXml.Elements("Phone").Select(phone => new MobilePhone
            {
                OwnerId = int.Parse(phone.Attribute("OwnerId")?.Value ?? "-1"),
                Manufacturer = phone.Attribute("Manufacturer")?.Value ?? "Unknown",
                Model = phone.Value,
                Network = phone.Attribute("Network")?.Value ?? "Unknown",
                OS = phone.Attribute("OS")?.Value ?? "Unknown"
                }).ToList();
        }

        public static Dictionary<Owner,List<MobilePhone>> GetReport1()
        {
            return SPDB.Get4GHuaweiPhones()
                .Join(ODB.Owners, phone => phone.OwnerId, owner => owner.Id, (phone, owner) => new { Owner = owner, Phone = phone })
                .Where(pair => !ODB.GetPrimeAgedOwners().Contains(pair.Owner))
                .GroupBy(pair => pair.Owner)
                .ToDictionary(g => g.Key, g => g.Select(pair => pair.Phone).ToList());
        }

        public static List<string> GetReport2()
        {
            var ownersWithAndoridPhones = SPDB.SoldPhones
                .Where(phone => phone.OS.Equals("Android", StringComparison.OrdinalIgnoreCase))
                .GroupBy(phone => phone.OwnerId)
                .ToDictionary(g => g.Key, g => g.Count());

            var minAndroidCount = ownersWithAndoridPhones.Values.Min();

            return ownersWithAndoridPhones
                .Where(pair => pair.Value == minAndroidCount)
                .Select(pair => ODB.Owners.First(o => o.Id == pair.Key).Name)
                .ToList();
        }

        public static List<Owner> GetReport3()
        {
            return ODB.GetPrimeAgedOwners()
                .Where(owner => owner.Name.Length < 8 && SPDB.Get4GHuaweiPhones().Count(phone => phone.OwnerId == owner.Id) < 2)
                .ToList();
        }
    }
}
