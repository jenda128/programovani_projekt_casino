using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using Baccarat;
using oko-bere;
using Ruleta;
using Shop;
using Achievementy;
namespace Kasino
{
    class Program
    {
        static double Vyber(double balance, string input) 
        {
            
            while(true){

                switch (input)
                {
                    case "1":
                        if (items["Baccarat"].vlastni == true)
                        {                            
                        BaccaratKasino baccarat = new BaccaratKasino();
                        balance = baccarat.Baccarat(balance);
                        break;
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Baccarat");
                            Console.WriteLine("Pokud Chcete hrát musíte si ho zakoupit v shopu");
                            break;
                        }
                    case "2":
                        if(items["Ruleta"].vlastni == true){
                        Ruleta ruleta = new Ruleta();
                        balance = ruleta.RuletaHra(balance);
                        break;
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Ruletu");
                            Console.WriteLine("Pokud Chcete hrát musíte si ji zakoupit v shopu");
                            break;
                        }
                    case "3":
                        Okobere okoBere = new Okobere();                        
                        balance = okoBere.OkoBere(balance);
                        break;
                    case "4":
                        Shop shop = new Shop();
                        balance = shop.Shop(balance);
                        break;
                    case "5": 
                        Achievementy achievementy = new Achievementy();
                        break;
                    case "exit":
                        Console.WriteLine("Jste si opravdu jistí?");
                        return(balance);
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        Console.WriteLine("Pokud si přejete odejít napište: exit");
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
            double balance = 1000000;
            while(true){
                Console.Write("Zadejte výběr: ");
                Console.WriteLine("enter - napište pokud chcete do kasína");
                Console.WriteLine("exit - napište pokud chcete odejít");
                switch (Console.ReadLine()) 
                {
                    case "enter":
                    Console.WriteLine("Vítejte v kasinu! Vyberte si hru:");
                    Console.WriteLine("1 - Baccarat");
                    Console.WriteLine("2 - Ruleta");
                    Console.WriteLine("3 - Oko Bere");
                    Console.WriteLine("4 - Shop");
                    Console.WriteLine("5 - Achievementy");
                    Console.WriteLine("exit - Konec");
                    Console.Write("Zadejte číslo hry: ");
                    balance = Vyber(balance, Console.ReadLine());
                    break;
                    case "exit":
                    Console.WriteLine("Odcházíte z kasina, mějte se!");
                    break;
                    default: 
                    Console.WriteLine("neplatný vstup");
                    break;
                }
            }
        }
    }
}
