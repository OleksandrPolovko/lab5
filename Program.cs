using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.ReadTovary("..\\..\\Tovary.txt");
            shop.ReadUsers("..\\..\\Users.txt");
            shop.ReadOrders("..\\..\\Orders.txt");


            Console.WriteLine("Tovary category = himia");
            shop.ShowTovary("himia");
            Console.WriteLine("\n\nTovary 15<price<100");
            shop.ShowTovary(15,100);
            Console.WriteLine("\n\nUsers");
            shop.ShowUsers();
            Console.WriteLine("\n\nOrders of User=1");
            shop.ShowUsersOrders(1);
            Console.WriteLine("\n\nTovary from Order=5");
            shop.ShowTovaryFromOrder(5);
            Console.WriteLine("\n\nTovar id=4");
            shop.ShowTovar(4);
        }
    }
}
