using System.Numerics;
using System.Reflection;
using Achievementy;

namespace Baccarat
{
    class BaccaratClass
    {
        static void Pravidla() {
            Console.WriteLine("V Baccaratu hráč sází na hráče(Player), bankéře(Banker) nebo remízu(Tie).Hráč i bankéř dostanou dvě karty, přičemž cílem je mít hodnotu co nejblíže 9(10 + se počítá jen poslední číslice).");
            Console.WriteLine("-2–9 = nominální hodnota");
            Console.WriteLine("-10, J, Q, K = 0");
            Console.WriteLine("-A = 1");
            Console.WriteLine("Pro vaše pohodlí rovnou převádíme všechny karty na čísla a sčítáme je, takže uvidíte pokaždé rouvnou součet karet bankéře a hráče");
            Console.WriteLine();
            Console.WriteLine("Hráč líže podle svého součtu:");
            Console.WriteLine("- 1-2-3-4-5-10 → líže třetí kartu");
            Console.WriteLine("- 6-7 → stojí");
            Console.WriteLine("- 8-9 → natural (konec hry)");
            Console.WriteLine();
            //cast s bankerovou treti kartou je nesrozumitelna
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

        static double vyhralNaNatural (string predikce, int soucetHrace, int soucetBankere, double sazka) 
        {
            //pokud remiza
            if (soucetHrace > 7 && soucetBankere > 7 && predikce == "remiza")
            {
                return (sazka * 8);
            }
            else if (soucetHrace > 7 && soucetBankere > 7 && predikce != "remiza")
            {
                return (sazka * -1);
            }
            //pokud hrac vyhralNaNatural
            else if (soucetHrace > 7)
            {
                if (predikce == "hrac")
                {
                    return sazka;
                }
                else if (predikce != "hrac")
                {
                    return (sazka*-1);
                }
                else 
                {
                    Console.WriteLine("chyba");
                    return 0;
                }
            }
            //pokud banker vyhralNaNatural
            else if (soucetBankere > 7)
            {
                if (predikce == "banker")
                {
                    return (sazka*0.95);
                }
                else if(predikce !="banker")
                {
                    return sazka;
                }
                else 
                {
                    Console.WriteLine("chyba");
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        static double vyhralPo3Karte(string predikce, int soucetHrace, int soucetBankere, double sazka)
        {
            if (vyhralNaNatural(predikce, soucetHrace, soucetBankere, sazka) != 0)
            {
            return(vyhralNaNatural(predikce, soucetHrace, soucetBankere, sazka));
            }
            else 
            {
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
                else if (soucetHrace > soucetBankere)
                {
                    if(predikce == "hrac")
                    {
                        return sazka;
                    }
                    else
                    {
                        return (sazka * -1);
                    }
                }
                //pokud banker vyhral po 3. kartach
                else if (soucetBankere > soucetHrace)
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
                else {
                Console.WriteLine("chyba");
                return 0;
                }
            }
        }

        static double HraBaccarat(double sazka, string predikce) 
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
            if (vyhralNaNatural(predikce, soucetHrace, soucetBankere, sazka) != 0)
            {
            return(vyhralNaNatural(predikce, soucetHrace, soucetBankere, sazka));
            }
            
            //File.WriteAllLines("BalanceHodnota.txt", balance);
            
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
            return vyhralPo3Karte(predikce, soucetHrace, soucetBankere, sazka);
        }

        public double PlayBaccarat(double balance)
        {
            double starabalance = balance;
            int input = 0;
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
                        if (int.TryParse(Console.ReadLine(), out input))
                        {
                            if (input <= balance)
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
                                        starabalance = balance;
                                        Console.WriteLine("Pokud si přejte použít power-up napište: Power-Up");
                                        if (Console.ReadLine() == "Power-Up") balance += Shop.ShopClass.BacPowerUpUse(HraBaccarat(input, predikce));
                                        else balance += HraBaccarat(input, predikce);
                                        Achievementy.AchievementyClass.PrvniWinBac((starabalance-balance));
                                        if (balance > starabalance)
                                        {
                                            Console.WriteLine("Vyhráli jste váš nový zbytek je: " + balance);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Prohráli jste váš nový zbytek je: " + balance);
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
                                Console.WriteLine("Zadali jste větší hodnotu než právě teď vlastníte. Právě teď vám zbývá:" + balance);
                                Console.WriteLine("Pokud si nepřejete pokračovat napište exit");
                                Console.WriteLine("Pokud stále chcete pokračovat napište částku menší nebo rovnou" + balance);
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
                    Console.WriteLine("odcházíte se zbytkem: " + balance);
                    return balance;
                }
                else 
                { 
                    Console.WriteLine("Zadali jste neplatný vstup zkuste to prosím znova");
                }
            }
        }
    }
}
