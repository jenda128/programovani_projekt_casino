using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace Kasino
{
        class Baccarat{
        private void Pravidla() {
            Console.WriteLine("V Baccaratu hráč sází na hráče(Player), bankéře(Banker) nebo remízu(Tie).Hráč i bankéř dostanou dvě karty, přičemž cílem je mít hodnotu co nejblíže 9(10 + se počítá jen poslední číslice).");
            Console.WriteLine("-2–9 = nominální hodnota");
            Console.WriteLine("-10, J, Q, K = 0");
            Console.WriteLine("-A = 1");
            Console.WriteLine("Pro vaše pohodlí rovnou převádíme všechny karty na čísla a sčítáme je takže uvidíte pokaždé rouvnou součet karet bankéře a hráče");
            Console.WriteLine();
            Console.WriteLine("Hráč líže podle svého součtu:");
            Console.WriteLine("- 1-2-3-4-5-10 → líže třetí kartu");
            Console.WriteLine("- 6-7 → stojí");
            Console.WriteLine("- 8-9 → natural (konec hry)");
            Console.WriteLine();
            //cast s bankerovou treti kartou je spatne
            Console.WriteLine("Bankéř líže podle hráčovy třetí karty:");
            Console.WriteLine("- 3 → líže, pokud hráč nelízl 8");
            Console.WriteLine("- 4 → líže, pokud hráč nelízl 1, 8, 9, 10");
            Console.WriteLine("- 5 → líže, pokud hráč nelízl 1, 2, 3, 8, 9, 10");
            Console.WriteLine("- 6 → líže, pokud hráč nelízl 1, 2, 3, 4, 5, 8, 9, 10");
            Console.WriteLine("- 7 → stojí");
            Console.WriteLine("- 8-9 → natural (konec hry)");
            Console.WriteLine();
            Console.WriteLine("Pokud hráč nelíže třetí kartu, bankéř stojí na 6.");
            return;
        }
        private double HraBaccarat(double sazka, string predikce) 
        {            
            Random rnd = new Random();
            int kartaHrace1 = rnd.Next(0,10);
            int kartaHrace2 = rnd.Next(0, 10);
            int kartaBanekere1 = rnd.Next(0, 10);
            int kartaBankere2 = rnd.Next(0, 10);
            int soucetHrace = kartaHrace1 + kartaHrace2;
            int soucetBankere = kartaBanekere1 + kartaBankere2;
            if (soucetHrace >= 10)
            {
                soucetHrace -= 10;
            }
            if (soucetBankere >= 10) 
            { 
                soucetBankere -= 10;
            }
            Console.WriteLine("Hráčova první karta: " + kartaHrace1 + " Hrářova druhá karta: " + kartaHrace2 + " součet hráčovích prvních dvou karet: " + soucetHrace);
            Console.WriteLine("Bankéřova první karta: " + kartaBanekere1 + " Bankéřova druhá karta: " + kartaBankere2 + " součet bankéřovích prvních dvou karet: " + soucetBankere);



            //pokud remiza v prvnim kole
            if (soucetHrace > 7 && soucetBankere > 7 && predikce == "remiza")
            {
                return (sazka * 8);
            }
            else if (soucetHrace > 7 && soucetBankere > 7 && predikce != "remiza")
            {
                return (sazka * -1);
            }
            //pokud hrac vyhral v prvnim kole
            else if (soucetHrace > 7)
            {
                if (predikce == "hrac")
                {
                    return (sazka);
                }
                else if (predikce != "hrac")
                {
                    return (sazka*-1);
                }
            }
            //pokud banker vyhral v prnim kole
            else if (soucetBankere > 7)
            {
                if (predikce == "banker")
                {
                    return (sazka*0.95);
                }
                else if(predikce !="banker")
                {
                    return (sazka);
                }
            }
            //treti karta pro hrace
            int kartaHrace3 = 0;
            bool bylaTretiKarta = false;
            if (soucetHrace > 6)
            {
                bylaTretiKarta = true;
                kartaHrace3 = rnd.Next(0, 10);
                soucetHrace += kartaHrace3;
            }
            //treti karta bankere
            int kartaBankere3 = 0;
            if (kartaHrace3 != 8 && soucetBankere == 3)
            {
                kartaBankere3 = rnd.Next(0, 10);
                soucetBankere += kartaBankere3;
            }
            else if (kartaHrace3 < 1 && kartaHrace3 >8 && soucetBankere == 4)
            {
                kartaBankere3 = rnd.Next(0, 10);
                soucetBankere += kartaBankere3;
            }
            else if (kartaHrace3 > 3 && kartaHrace3 < 8 && soucetBankere == 5)
            {
                kartaBankere3 = rnd.Next(0, 10);
                soucetBankere += kartaBankere3;
            }
            else if ((kartaHrace3 == 6 || kartaHrace3 == 7) && soucetBankere == 6)
            {
                kartaBankere3 = rnd.Next(0, 10);
                soucetBankere += kartaBankere3;
            }
            //pokud nebyla hracova 3. karta
            else if (bylaTretiKarta == false && soucetBankere != 6)
            {
                kartaBankere3 = rnd.Next(0, 10);
                soucetBankere += kartaBankere3;
            }
            //soucet je mensi nez 10
            if (soucetHrace > 9)
            {
                soucetHrace -= 10;
            }
            if (soucetBankere > 9)
            {
                soucetBankere -= 10;
            }
            Console.WriteLine("Hráčova třetí karta " + kartaHrace3 + " součet hráčovích karet: " + soucetHrace);
            Console.WriteLine("Bankéřova třetí karta " + kartaBankere3 + " součet bankéřovích karet: " + soucetBankere);
            //pokud remiza po 3. kartach
            if (soucetBankere == soucetHrace)
            {
                if (predikce == "remiza")
                {
                    return (sazka * 8);
                }
                else { return (sazka * -1); }
            }
            //pokud hrac vyhral po 3.kartach
            if (soucetHrace > soucetBankere)
            {
                if(predikce == "hrac")
                {
                    return (sazka);
                }
                else
                {
                    return (sazka * -1);
                }
            }
            //pokud banker vyhral po 3. kartach
            if (soucetBankere > soucetHrace)
            {
                if (predikce == "banker")
                {
                    return (sazka*0.95);
                }
                else
                {
                    return (sazka * -1);
                }
            }
            Console.WriteLine("chyba");
            return (0);


        }

        public double Baccarat(double Balance)
        {
            double staraBalance = 100;
            double Balance = 100;
            Console.WriteLine("Pro Pravidla hry napište: Pravidla");
            Console.WriteLine("Pro hraní hry napište: Hra");
            while (true) {
                string lobbyInput = Console.ReadLine();
                if (lobbyInput == "Pravidla") {
                    Pravidla();
                }
                else if (lobbyInput == "Hra")
                {

                    Console.WriteLine("Napište hodnotu kterou chcete vsadit");
                    while (true) {
                        if (int.TryParse(Console.ReadLine(), out double input))
                        {
                            if (input <= Balance)
                            {
                                Console.WriteLine("Teď napište na koho sázíte");
                                while (true)
                                {
                                    Console.WriteLine("Pokud sázíte na hráče napište:hrac");
                                    Console.WriteLine("Pokud sázíte na bankéře napište:banker");
                                    Console.WriteLine("Pokud sázíte na remízu napište:remiza");
                                    string predikce = Console.ReadLine();
                                    if (predikce == "hrac" || predikce == "banker" || predikce == "remiza")
                                    {
                                        staraBalance = Balance;
                                        Balance += HraBaccarat(input, predikce);
                                        if (Balance > staraBalance)
                                        {
                                            Console.WriteLine("Vyhráli jste váš nový zbytek je: "+Balance);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Prohráli jste váš nový zbytek je: "+Balance);
                                        }
                                    }
                                    else if (predikce == "exit")
                                    {
                                        Console.WriteLine("Napište hodnotu kterou chcete vsadit");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pokud jste se rozhodli že už nechcete hrát napiste exit, jinak prosím zadejte validní vstup");
                                    }
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Zadali jste větší hodnotu než právě teď vlastníte. Právě teď vám zbývá:" + Balance);
                                Console.WriteLine("Pokud si nepřejete pokračovat napište exit");
                                Console.WriteLine("Pokud stále chcete pokračovat napište částku menší nebo rovnou" + Balance);
                            }
                            
                        }
                        else if (Console.ReadLine() == "exit")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pokud se snažíte odejít napište exit");
                            continue;
                        }
                    }

                }
                else if (lobbyInput == "exit")
                {
                    Console.WriteLine("odcházíte se zbytkem: " + Balance);
                    return(Balance);
                }
                else 
                { 
                    Console.WriteLine("Zadali jste neplatný vstup zkuste to prosím znova");
                }
            }
        }

        class Ruleta
{
    public void RuletaHra()
    {
        Random random = new Random();
        int balance = 1000;
        HashSet<int> redNumbers = new HashSet<int> { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("$$$ Vítejte v ruletě! $$$");
            Console.WriteLine($"$$$ Aktuální zůstatek: {balance} Kč $$$");
            Console.WriteLine("Vyberte typ sázky:");
            Console.WriteLine("1 - Číslo (0-36)");
            Console.WriteLine("2 - Barva (červená/černá)");
            Console.WriteLine("3 - Ukončit hru");

            int betType;
            while (!int.TryParse(Console.ReadLine(), out betType) || (betType < 1 || betType > 3))
            {
                Console.WriteLine("Neplatná volba, zadejte 1, 2 nebo 3:");
            }

            if (betType == 3)
            {
                Console.WriteLine("Děkujeme za hru! 🎲");
                break;
            }

            int bet;
            Console.WriteLine("Zadejte sázku:");
            while (!int.TryParse(Console.ReadLine(), out bet) || bet <= 0 || bet > balance)
            {
                Console.WriteLine("Neplatná částka, zadejte správnou sázku:");
            }

            int playerNumber = -1;
            string playerColor = "";

            if (betType == 1)
            {
                Console.WriteLine("Vyberte číslo (0-36):");
                while (!int.TryParse(Console.ReadLine(), out playerNumber) || (playerNumber < 0 || playerNumber > 36))
                {
                    Console.WriteLine("Neplatná volba, zadejte číslo mezi 0 a 36:");
                }
            }
            else if (betType == 2)
            {
                Console.WriteLine("Vyberte barvu (červená/černá):");
                while (true)
                {
                    playerColor = Console.ReadLine().ToLower();
                    if (playerColor == "červená" || playerColor == "cervena" || playerColor == "černá" || playerColor == "cerna")
                        break;
                    Console.WriteLine("Neplatná volba, zadejte 'červená' nebo 'černá':");
                }
            }

            int winningNumber = random.Next(0, 37);
            string winningColor = redNumbers.Contains(winningNumber) ? "červená" : (winningNumber == 0 ? "zelená" : "černá");

            Console.WriteLine("Ruleta se točí... 🌀");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Padlo číslo: {winningNumber} ({winningColor})");

            if (betType == 1 && playerNumber == winningNumber)
            {
                int winnings = bet * 35;
                balance += winnings;
                Console.WriteLine($" Gratulujeme! Vyhráli jste {winnings} Kč!");
            }
            else if (betType == 2 && playerColor == winningColor)
            {
                int winnings = bet * 2;
                balance += winnings;
                Console.WriteLine($" Gratulujeme! Vyhráli jste {winnings} Kč!");
            }
            else
            {
                balance -= bet;
                Console.WriteLine(" Bohužel jste prohráli.");
            }

            if (balance <= 0)
            {
                Console.WriteLine(" Nemáte dostatek peněz. Konec hry.");
                break;
            }

            Console.WriteLine("Stiskněte ENTER pro další kolo...");
            Console.ReadLine();
        }
    }
}
        


        
    }

class Okobere
{
    public Random rand = new Random();
    public string[] karty = { "7", "8", "9", "10", "J", "Q", "K", "A" };

    public int Hodnota(string karta)
    {
        if (karta == "A") return 11;
        if (karta == "J" || karta == "Q" || karta == "K") return 1;
        return int.Parse(karta);
    }

    public int Skore(List<string> karty)
    {
        int s = 0;
        foreach (var k in karty) s += Hodnota(k);
        return s;
    }

    public void ZobrazKarty(List<string> hrac)
    {
        Console.WriteLine($"Tvoje karty: {string.Join(", ", hrac)} (skóre: {Skore(hrac)})");
    }

    public void OkoBere()
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
}
