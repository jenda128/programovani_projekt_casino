using System;
using System.Collections.Generic;

namespace Okobere
{
    class OkoBereClass
    {
        private Random rand = new Random();
        private string[] karty = { "7", "8", "9", "10", "J", "Q", "K", "A" };
        private bool okoBerePowerUp = false; // Nová proměnná pro sledování, zda hráč použil power-up

        private int Hodnota(string karta)
        {
            if (karta == "A") return 11;
            if (karta == "J" || karta == "Q" || karta == "K") return 1;
            return int.Parse(karta);
        }

        private int Skore(List<string> karty)
        {
            int s = 0;
            foreach (var k in karty) s += Hodnota(k);
            return s;
        }

        private void ZobrazKarty(List<string> hrac)
        {
            Console.WriteLine($"Tvoje karty: {string.Join(", ", hrac)} (skóre: {Skore(hrac)})");
        }

        // Funkce pro použití power-upu "OkoBere"
        private void UseOkoBerePowerUp(List<string> hrac)
        {
            if (okoBerePowerUp)
            {
                string stejnaKarta = hrac[0]; // Získáme první kartu hráče
                hrac.Add(stejnaKarta); // Přidáme stejnou kartu
                Console.WriteLine($"Použil jsi power-up OkoBere! Tvoje nová karta: {stejnaKarta}");
                okoBerePowerUp = false; // Power-up je spotřebován
            }
            else
            {
                Console.WriteLine("Nemáš power-up OkoBere.");
            }
        }

        public double PlayOkoBere(double balance)
        {
            Console.WriteLine("Oko bere!");
            int sazka = 0;
            while (balance > 0)
            {
                Console.Write($"Kolik vsadíš? (max {balance}, 0 = konec): ");
                if (!double.TryParse(Console.ReadLine(), out sazka) || sazka <= 0 || sazka > balance) continue;
                balance -= sazka;

                List<string> hrac = new List<string> { karty[rand.Next(karty.Length)] };
                List<string> banker = new List<string> { karty[rand.Next(karty.Length)] };

                while (true)
                {
                    ZobrazKarty(hrac);
                    int skoreHrace = Skore(hrac);

                    if (skoreHrace == 21)
                    {
                        Console.WriteLine("Gratulace! Máš přesně 21 bodů!");
                        Achievementy.AchievementyClass.CheckAchievements("luckyhand", 0, true); // Achievement
                    }

                    if (skoreHrace > 21)
                    {
                        Console.WriteLine("Přetáhl jsi! Prohra.");
                        break;
                    }

                    // Možnost použít power-up
                    Console.Write("Chceš použít power-up 'OkoBere' pro stejnou kartu? (a/n): ");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        UseOkoBerePowerUp(hrac);
                    }

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
                            balance += sazka * 2;
                        }
                        else
                        {
                            Console.WriteLine("Prohrál jsi!");
                        }
                        break;
                    }
                }
                Console.WriteLine($"Zůstatek: {balance} Kč");
            }
            Console.WriteLine("Nemáš žádné peníze! Konec hry.");
        }
    }
}
