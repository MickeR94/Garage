using System;
namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** WELCOME TO GARAGE & CO *************");
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
