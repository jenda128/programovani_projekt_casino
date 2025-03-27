using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using Baccarat;
using oko-bere;
using ruleta;

namespace Kasino
{
    class Program
    {
        static double Vyber(double balance, string input, vlastniBaccarat, vlastniRuleta) 
        {
            
            while(true){
                switch (input)
                {
                    case "1":
                        if (vlastniBaccarat == true)
                        {                            
                        BaccaratKasino baccarat = new BaccaratKasino();
                        return(baccarat.Baccarat(balance));
                        }
                        else 
                        {
                            Console.WriteLine("Nevlastníte Baccarat");
                            Console.WriteLine("Pokud Chcete hrát musíte si ho zakoupit v shopu");
                            break;
                        }
                    case "2":
                        if(vlastniRuleta == true){
                        Ruleta ruleta = new Ruleta();
                        return(ruleta.RuletaHra(balance));
                        }else 
                        {
                            Console.WriteLine("Nevlastníte Ruletu");
                            Console.WriteLine("Pokud Chcete hrát musíte si ji zakoupit v shopu");
                            break;
                        }
                    case "3":
                        Okobere okoBere = new Okobere();                        
                        return (okoBere.OkoBere(balance));
                    case "4":
                        Shop shop = new Shop();
                        break
                    case "5": 
                        Achievementy achievementy = new Achievementy()
                        break
                    case "6":
                        Console.WriteLine("Jste si opravdu jistí?");
                        return(balance); // Ukončení programu
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
            bool vlastniBaccarat = false;
            bool vlastniRuleta = false;
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
                    Console.WriteLine("5 - Achievementy")
                    Console.WriteLine("6 - Konec")
                    Console.Write("Zadejte číslo hry: ");
                    double balance = Vyber(balance, Console.ReadLine(), vlastniBaccarat, vlastniRuleta);
                    break;
                    case "exit":
                    Console.WriteLine("Odcházíte z kasina, mějte se!")
                    break;
                    else {
                        Console.WriteLine("neplatný vstup");
                    }
                }
            }
        }
    }
}