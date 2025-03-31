using System;
using System.Collections.Generic;

namespace Achievementy
{
    public static class Achievementy
    {
        public static Dictionary<string, bool> ach = new Dictionary<string, bool>
        {
            { "Lucky Streak - 5x správná barva", false },
            { "High Roller - sázka 1000+ Kč", false },
            { "Jackpot - uhodnuto přesné číslo", false },
            { "Lucky Hand - získání 21 bodů", false }
        };

        private static int correctColorGuesses = 0;

        public static void CheckAchievements(string type, int bet, bool won)
        {
            if (type == "color" && won)
            {
                correctColorGuesses++;
                if (correctColorGuesses == 5 && !ach["Lucky Streak - 5x správná barva"])
                {
                    ach["Lucky Streak - 5x správná barva"] = true;
                    Console.WriteLine(" Gratulujeme! Získali jste achievement: Lucky Streak - 5x správná barva!");
                }
            }

            if (bet >= 1000 && !ach["High Roller - sázka 1000+ Kč"])
            {
                ach["High Roller - sázka 1000+ Kč"] = true;
                Console.WriteLine(" Gratulujeme! Získali jste achievement: High Roller - sázka 1000+ Kč!");
            }
        }

        public static void JackpotAchievement()
        {
            if (!ach["Jackpot - uhodnuto přesné číslo"])
            {
                ach["Jackpot - uhodnuto přesné číslo"] = true;
                Console.WriteLine(" Gratulujeme! Získali jste achievement: Jackpot - uhodnuto přesné číslo!");
            }
        }

        public static void LuckyHandAchievement()
        {
            if (!ach["Lucky Hand - získání 21 bodů"])
            {
                ach["Lucky Hand - získání 21 bodů"] = true;
                Console.WriteLine(" Gratulujeme! Získali jste achievement: Lucky Hand - získání 21 bodů!");
            }
        }

        public static void ShowAchievements()
        {
            Console.WriteLine(" SPLNĚNÉ ACHIEVEMENTY ");
            bool hasAchievements = false;
            foreach (var achievement in ach)
            {
                if (achievement.Value) 
                {
                    Console.WriteLine($" {achievement.Key}");
                    hasAchievements = true;
                }
            }

            if (!hasAchievements)
            {
                Console.WriteLine("Žádné achievementy zatím nejsou splněné.");
            }
            Console.WriteLine(":)");
        }
    }
}
