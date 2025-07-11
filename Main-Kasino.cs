using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;//cteni textu
using System.Text;//ukladani textu
using Baccarat;
using Okobere;
using Ruleta;
using Shop;
using Achievementy;
namespace Kasino
{
    class Program
    {

        static double Vyber(double balance) 
        {
            while(true){
                Console.WriteLine("1 - Baccarat");
                Console.WriteLine("2 - Ruleta");
                Console.WriteLine("3 - Oko Bere");
                Console.WriteLine("4 - Shop");
                Console.WriteLine("5 - Achievementy");
                Console.WriteLine("exit - Konec");
                Console.Write("Zadejte číslo hry: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (Shop.ShopClass.ShopItems["Baccarat"].vlastni == true)
                        {                            
                            Baccarat.BaccaratClass BaccaratPlay = new Baccarat.BaccaratClass();
                            balance = BaccaratPlay.PlayBaccarat(balance);
                            File.WriteAllText("BalanceHodnota.txt", Convert.ToString(balance));
                        break;
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Baccarat");
                            Console.WriteLine("Pokud Chcete hrát musíte si ho zakoupit v shopu");
                            break;
                        }
                    case "2":
                        if(Shop.ShopClass.ShopItems["Ruleta"].vlastni == true){
                            Ruleta.RuletaClass RuletaPlay = new Ruleta.RuletaClass();
                            balance = RuletaPlay.PlayRuleta(balance);
                            File.WriteAllText("BalanceHodnota.txt", Convert.ToString(balance));
                        break;
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Ruletu");
                            Console.WriteLine("Pokud Chcete hrát musíte si ji zakoupit v shopu");
                            break;
                        }
                    case "3":                   
                        Okobere.OkoBereClass OkoBerePlay = new Okobere.OkoBereClass();
                        balance = OkoBerePlay.PlayOkoBere(balance);                        
                        File.WriteAllText("BalanceHodnota.txt", Convert.ToString(balance));
                        break;
                    case "4":
                        Shop.ShopClass ShopView = new Shop.ShopClass();
                        balance = ShopView.ViewShop(balance);                        
                        File.WriteAllText("BalanceHodnota.txt", Convert.ToString(balance));
                        break;
                    case "5": 
                        Achievementy.AchievementyClass.ShowAchievements();
                        break;
                    case "exit":
                        Console.WriteLine("Jste si opravdu jistí?");
                        return(balance);
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        Console.WriteLine("Možnosti:");
                        break;
                }
            }

        }
        static double LoadBalance()
        {
            double balance = 1000000;
            try
            {
                using (StreamReader sr = new StreamReader("BalanceHodnota.txt"))
                {
                    if (double.TryParse(sr.ReadLine(), out double parsedBalance))
                    {
                        balance = parsedBalance;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě při čtení souboru: {ex.Message}. Nastavuji výchozí hodnotu 1000000.");
            }
            return balance;
        }   
        static void Main(string[] args)
        {
            Shop.ShopClass.LoadShopItems();
            Achievementy.AchievementyClass.LoadAch();
            double balance = LoadBalance();
            //copilot:
            
            

            Console.WriteLine("Pokud chcete Uložit všechny hodnoty, musíte odejít pomocí exit");
            while(true){
                Console.Write("Zadejte výběr: ");
                Console.WriteLine("enter - napište pokud chcete do kasína");
                Console.WriteLine("exit - napište pokud chcete odejít");

                switch (Console.ReadLine()) 
                {
                    case "enter":
                    Console.WriteLine("Vítejte v kasinu! Vyberte si hru:");
                    balance = Vyber(balance);
                    break;
                    case "exit":
                    Console.WriteLine("Odcházíte z kasina, mějte se!");
                    return;
                    default: 
                    Console.WriteLine("neplatný vstup");
                    break;
                }
            }
        }
    }
}
