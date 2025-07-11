using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Shop
{
    class ShopClass
    {
        /*generovane chatgpt:
        private double balance;
        private Dictionary<string, (int cena, bool vlastni)> ShopItems;

        public Shop(double initialBalance)
        {
            balance = initialBalance;

            // Seznam věcí, které lze koupit (název → cena, zda je hráč vlastní)
            ShopItems = new Dictionary<string, (int, bool)>
            {
                { "Baccarat", (1000, false) },
                { "Ruleta", (1200, false) },
                { "Poker", (1500, false) } // Můžeš jednoduše přidávat další věci
            };*/
        //tbh s timhle kodem mi pomohl chat gpt protoze jsem si uz vubec nepamatoval jak se pracuje se slovnikem
        //dictionary jsem delal s chatgpt

        /* public static Dictionary<string, (int cena, bool vlastni)> ShopItems { get; private set; } = new Dictionary<string, (int, bool)>
        {
            { "Baccarat", (1000, false) },
            { "Ruleta", (1200, false) },//tady pridejte svoje polozky ve stejnym formatu jako bacarat a ruleta
            { "Power-Up - OkoBere", (500, false) },
            { "Power-Up - Baccarat", (700, false) }
        }; */

        public static Dictionary<string, (int cena, bool vlastni)> ShopItems = new Dictionary<string, (int, bool)>();
        public static void LoadShopItems()
        {
            ShopItems.Clear();
            string filePath = "ShopHodnoty.txt";
            //copy paste shop hodnoty z textaku
            //copilot:
            string[] radky = File.ReadAllLines(filePath);
            foreach (string line in radky)
            {
                string[] parts = line.Split(" ");
                if (parts.Length == 3 && int.TryParse(parts[1], out int cena) && bool.TryParse(parts[2], out bool vlastni))
                {
                    ShopItems[parts[0]] = (cena, vlastni);
                }
            }
        }

        public double ViewShop(double balance)
        {
            Console.WriteLine("Vítejte v shopu");
            while (true)
            {
                /*taky chatgpt:foreach (var item in ShopItems)
                {
                    string stav = item.Value.vlastni ? "(Vlastní)" : $"- {item.Value.cena} chechtáků";
                    Console.WriteLine($"{item.Key}: {stav}");
                }*/
                foreach (var item in ShopItems)
                {
                    Console.WriteLine(item.Key + " Vlastníte: " + item.Value.vlastni + " Cena: " + item.Value.cena);
                }
                Console.WriteLine("Napište název hry nebo power-upu, který chcete koupit, nebo 'exit' pro odchod.");
                //ShopItems.ContainsKey(input)
                string input = Console.ReadLine();
                if (ShopItems.ContainsKey(input))
                {
                    var (cena, vlastni) = ShopItems[input];
                    if (vlastni == true)
                    {
                        Console.WriteLine("Tuto hru nebo power-up už vlastníte");
                    }
                    else if (balance < cena)
                    {
                        Console.WriteLine("Nemáte dostatek chechtáků");
                    }
                    else
                    {
                        balance -= cena;
                        ShopItems[input] = (cena, true); // opravena chyba s immutable tuple
                        Console.WriteLine("koupili jste: " + input + " zbývá vám: " + balance + " chechtáků");
                    }
                }
                else if (input == "exit")
                {
                    File.WriteAllLines("ShopHodnoty.txt", ShopItems.Select(item => (item.Key + " " + item.Value.cena + " " + item.Value.vlastni)));
                    File.WriteAllText("BalanceHodnota.txt", Convert.ToString(balance));
                    return balance;
                }
                else
                {
                    Console.WriteLine("Neplatný vstup zkuste znovu");
                }
            }
        }

        public static double BacPowerUpUse(double vyhra)
        {
            if (ShopItems.ContainsKey("Power-Up-Baccarat-vyšší-výhra(one-time-use)") &&
                ShopItems["Power-Up-Baccarat-vyšší-výhra(one-time-use)"].vlastni == true)
            {
                // opravena chyba: nelze upravit vlastnost přímo, musíme přepsat celý tuple
                var item = ShopItems["Power-Up-Baccarat-vyšší-výhra(one-time-use)"];
                ShopItems["Power-Up-Baccarat-vyšší-výhra(one-time-use)"] = (item.cena, false);
                return vyhra * 1.5; // zde se přidá efekt power-upu na výhru
            }
            else
            {
                Console.WriteLine("Nevlastníte PowerUp");
                return vyhra; // pokud hráč power-up nevlastní, výhra zůstane stejná
            }
        }
    }
}
