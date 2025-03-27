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
        static double Vyber(double balance, string input, vlastniRuleta, vlastniBaccarat, vlastniRuleta) 
        {
            
            Console.WriteLine("Vítejte v kasinu! Vyberte si hru:");
            Console.WriteLine("1 - Baccarat");
            Console.WriteLine("2 - Ruleta");
            Console.WriteLine("3 - Oko Bere");
            Console.WriteLine("4 - Shop");
            Console.WriteLine("5 - Achievementy")
            Console.WriteLine("6 - Konec")
            Console.Write("Zadejte číslo hry: ");

                switch (input)
                {
                    case "1":

                        BaccaratKasino baccarat = new BaccaratKasino();
                        baccarat.Baccarat(balance); // Start hry s počátečním bankem 100
                        break;
                    case "2":
                        Ruleta ruleta = new Ruleta();
                        ruleta.RuletaHra(balance);
                        break;
                    case "3":
                        Okobere okoBere = new Okobere();
                        okoBere.OkoBere(balance);
                        break;
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
        static void Main(string[] args)
        {
            bool vlastniBaccarat = false;
            bool vlastniOkobere = false;
            bool vlastniRuleta = false;
            double balance = 1000000;
            while{
                Console.Write("Zadejte výběr: ");
                Console.WriteLine("enter - napište pokud chcete do kasína");
                Console.WriteLine("exit - napište pokud chcete odejít");
                switch (Console.ReadLine()) 
                {
                    case "enter":                
                    double balance = Vyber(balance, Console.ReadLine(), vlastniBaccarat, vlastniOkobere, vlastniRuleta);
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