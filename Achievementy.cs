using System;
using System.Collections.Generic;

namespace Achievementy
{
    public static class AchievementyClass
    {
        public static Dictionary<string, bool> ach = new Dictionary<string, bool>();

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
                    File.WriteAllLines("AchievementyHodnoty.txt", ach.Select(item => (item.Key + " " + item.Value)));
                }
            }

            if (bet >= 1000 && !ach["High Roller - sázka 1000+ Kč"])
            {
                ach["High Roller - sázka 1000+ Kč"] = true;
                Console.WriteLine(" Gratulujeme! Získali jste achievement: High Roller - sázka 1000+ Kč!");
                    File.WriteAllLines("AchievementyHodnoty.txt", ach.Select(item => (item.Key + " " + item.Value)));
            }
        }

        public static void JackpotAchievement()
        {
            if (!ach["Jackpot - uhodnuto přesné číslo"])
            {
                ach["Jackpot - uhodnuto přesné číslo"] = true;
                Console.WriteLine(" Gratulujeme! Získali jste achievement: Jackpot - uhodnuto přesné číslo!");
                    File.WriteAllLines("AchievementyHodnoty.txt", ach.Select(item => (item.Key + " " + item.Value)));
            }
        }

        public static void LuckyHandAchievement()
        {
            if (!ach["Lucky Hand - získání 21 bodů"])
            {
                ach["Lucky Hand - získání 21 bodů"] = true;
                Console.WriteLine(" Gratulujeme! Získali jste achievement: Lucky Hand - získání 21 bodů!");
                    File.WriteAllLines("AchievementyHodnoty.txt", ach.Select(item => (item.Key + " " + item.Value)));
            }
        }

        public static void PrvniWinBac (double vysledek) 
        {
            if (!ach["První Výhra v Baccaratu"]) {
                if(vysledek>0) {
                    ach["První Výhra v Baccaratu"] = true;
                    Console.WriteLine(" Gratulujeme! Získali jste achievement: První Výhra v Baccaratu");
                    File.WriteAllLines("AchievementyHodnoty.txt", ach.Select(item => (item.Key + " " + item.Value)));
                }
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
        public static void LoadAch()
        {
            ach.Clear();
            string filePath = "AchievementyHodnoty.txt";
            //copy paste ach hodnoty z textaku
            string[] radky = File.ReadAllLines(filePath);
            foreach (string line in radky)
            {
                string[] parts = line.Split(" ");
                if (parts.Length == 2 && bool.TryParse(parts[1], out bool vlastni))
                {
                    ach[parts[0]] = (vlastni);
                }
            }
        }
    }
}
