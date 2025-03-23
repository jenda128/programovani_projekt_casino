using System;
using System.Collections.Generic;

class Okobere
{
    static Random rand = new Random();
    static string[] karty = { "7", "8", "9", "10", "J", "Q", "K", "A" };

    static int Hodnota(string karta)
    {
        if (karta == "A") return 11;
        if (karta == "J" || karta == "Q" || karta == "K") return 1;
        return int.Parse(karta);
    }

    static int Skore(List<string> karty)
    {
        int s = 0;
        foreach (var k in karty) s += Hodnota(k);
        return s;
    }

    static void ZobrazKarty(List<string> hrac)
    {
        Console.WriteLine($"Tvoje karty: {string.Join(", ", hrac)} (skóre: {Skore(hrac)})");
    }

    static void Main()
    {
        Console.WriteLine("Oko bere!");
        int bank = 100, sazka;

        while (bank > 0)
        {
            Console.Write($"Kolik vsadíš? (max {bank}, 0 = konec): ");
            if (!int.TryParse(Console.ReadLine(), out sazka) || sazka <= 0 || sazka > bank) continue;
            bank -= sazka;

            List<string> hrac = new List<string> { karty[rand.Next(karty.Length)] };
            List<string> banker = new List<string> { karty[rand.Next(karty.Length)] };

            while (true)
            {
                ZobrazKarty(hrac);
                if (Skore(hrac) > 21) { Console.WriteLine("Přetáhl jsi! Prohra."); break; }

                Console.Write("Táhneš? (a/n): ");
                if (Console.ReadLine().ToLower() == "a")
                {
                    hrac.Add(karty[rand.Next(karty.Length)]);
                }
                else
                {
                    while (Skore(banker) < 17)
                    {
                        banker.Add(karty[rand.Next(karty.Length)]);
                    }

                    Console.WriteLine($"Bankéřovy karty: {string.Join(", ", banker)} (skóre: {Skore(banker)})");

                    if (Skore(banker) > 21 || Skore(hrac) > Skore(banker))
                    {
                        Console.WriteLine("Vyhrál jsi!");
                        bank += sazka * 2;
                    }
                    else
                    {
                        Console.WriteLine("Prohrál jsi!");
                    }
                    break;
                }
            }
            Console.WriteLine($"Bank: {bank} Kč");
        }
        Console.WriteLine("Bank je prázdný! Konec hry.");
    }
}
