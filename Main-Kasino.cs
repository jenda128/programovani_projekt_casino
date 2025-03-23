using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using Kasino;

namespace Kasino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítejte v kasinu! Vyberte si hru:");
            Console.WriteLine("1 - Baccarat");
            Console.WriteLine("2 - Ruleta");
            Console.WriteLine("3 - Oko Bere");
            Console.WriteLine("4 - Konec");
            
            while (true)
            {
                Console.Write("Zadejte číslo hry: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        BaccaratKasino baccarat = new BaccaratKasino();
                        baccarat.Baccarat(100); // Start hry s počátečním bankem 100
                        break;
                    case "2":
                        Ruleta ruleta = new Ruleta();
                        ruleta.RuletaHra();
                        break;
                    case "3":
                        Okobere okoBere = new Okobere();
                        okoBere.OkoBere();
                        break;
                    case "4":
                        Console.WriteLine("Odcházíte z kasina, mějte se!");
                        return; // Ukončení programu
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        break;
                }
            }
        }
    }
}