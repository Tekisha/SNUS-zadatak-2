using System;
using Zadatak2;

class Program
{
    static void Main()
    {
        var report1 = MobilePhoneShop.GetReport1();
        Console.WriteLine("Report 1:");
        foreach (var owner in report1)
        {
            Console.WriteLine($"Owner: {owner.Key.Name}");
            foreach (var phone in owner.Value)
            {
                Console.WriteLine($"Phone: {phone.Manufacturer} {phone.Model}");
            }
        }

        var report2 = MobilePhoneShop.GetReport2();
        Console.WriteLine("\nReport 2:");
        foreach (var name in report2)
        {
            Console.WriteLine($"Owner name: {name}");
        }

        var report3 = MobilePhoneShop.GetReport3();
        Console.WriteLine("\nReport 3:");
        foreach (var owner in report3)
        {
            Console.WriteLine($"Owner ID: {owner.Id}, Name: {owner.Name}");
        }
    }
}
