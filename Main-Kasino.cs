using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using Baccarat;
using Okobere;
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
                        if (Shop.Shop.items["Baccarat"].vlastni == true)
                        {                            
                            Baccarat BaccaratPlay = new Baccarat();
                            balance = BaccaratPlay.PlayBaccarat(balance);
                            //balance = Baccarat.PlayBaccarat(balance);
                        break;
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Baccarat");
                            Console.WriteLine("Pokud Chcete hrát musíte si ho zakoupit v shopu");
                            break;
                        }
                    case "2":
                        if(Shop.Shop.items["Ruleta"].vlastni == true){
                            Ruleta RuletaPlay = new Ruleta();
                            balance = RuletaPlay.PlayRuleta(balance);
                        break;
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Ruletu");
                            Console.WriteLine("Pokud Chcete hrát musíte si ji zakoupit v shopu");
                            break;
                        }
                    case "3":                   
                        OkoBereHra OkoBerePlay = new OkoBereHra();
                        balance = OkoBerePlay.OkoBere(balance);
                        break;
                    case "4":
                        shop.Shop shop = new Shop.Shop();
                        balance = shop.ViewShop(balance);
                        break;
                    case "5": 
                        Achievementy.ShowAchievements();
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
