using System;
using System.Collections.Generic;
using System.Threading;
using Achievementy; 
namespace Ruleta
{
    class RuletaHra
    {
        public double StartGame()
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
                    Console.WriteLine("Děkujeme za hru! ");
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
                Thread.Sleep(2000);
                Console.WriteLine($"Padlo číslo: {winningNumber} ({winningColor})");

                bool won = false;

                if (betType == 1 && playerNumber == winningNumber)
                {
                    int winnings = bet * 35;
                    balance += winnings;
                    Console.WriteLine($"  Gratulujeme! Vyhráli jste {winnings} Kč!");
                    Achievementy.JackpotAchievement(); 
                    won = true;
                }
                else if (betType == 2 && playerColor == winningColor)
                {
                    int winnings = bet * 2;
                    balance += winnings;
                    Console.WriteLine($"  Gratulujeme! Vyhráli jste {winnings} Kč!");
                    won = true;
                }
                else
                {
                    balance -= bet;
                    Console.WriteLine(" Bohužel jste prohráli. :(");
                }

                Achievementy.CheckAchievements(betType == 1 ? "number" : "color", bet, won);

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
