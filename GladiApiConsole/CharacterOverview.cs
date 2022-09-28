using GladiApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApiConsole
{
    public class CharacterOverview
    {
        public OverviewInterpreter characterInfo;
        public Character character;

        public CharacterOverview(Character character, string html)
        {
            characterInfo = new(html);
            this.character = character;
        }

        public void PrintCharacterOverview()
        {
            Console.WriteLine($"Server Time is {characterInfo.Header.ServerTime.ToLongDateString()} UTC");
            Console.WriteLine("Character Overview:");
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"Gold: {characterInfo.Header.Gold}");
            Console.WriteLine($"Rubies: {characterInfo.Header.Rubies}");
            Console.WriteLine($"Highscore Rank: {characterInfo.Header.LeaderboardPlacement}");
            Console.WriteLine($"Level: {characterInfo.Header.Experience.Level}");
            Console.WriteLine($"Current XP: {characterInfo.Header.Experience.CurrenValue}");
            Console.WriteLine($"XP to level up: {characterInfo.Header.Experience.MaxValue}");
            Console.WriteLine($"Current HP: {characterInfo.Header.Health.CurrenValue}");
            Console.WriteLine($"Max HP: {characterInfo.Header.Health.MaxValue}");
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"Expedition Points: {characterInfo.Header.ExpeditionPoints.CurrentPoints}");
            Console.WriteLine($"Expedition Points Max: {characterInfo.Header.ExpeditionPoints.MaxPoints}");
            Console.WriteLine($"Cooldown active? {characterInfo.Header.ExpeditionPoints.Cooldown}");
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"Dungeon Points: {characterInfo.Header.DungeonPoints.CurrentPoints}");
            Console.WriteLine($"Dungeon Points Max: {characterInfo.Header.DungeonPoints.MaxPoints}");
            Console.WriteLine($"Cooldown active? {characterInfo.Header.DungeonPoints.Cooldown}");
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"Arena cooldown: {characterInfo.Header.Arena.Cooldown}");
            Console.WriteLine($"Turma cooldown: {characterInfo.Header.CircusTurma.Cooldown}");
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"Stats:");
            Console.WriteLine($"Strength: {characterInfo.Strength.Value}");
            Console.WriteLine($"Dexterity: {characterInfo.Dexterity.Value}");
            Console.WriteLine($"Agility: Current: {characterInfo.Agility.Value} Base: {characterInfo.Agility.BaseValue} Max: {characterInfo.Agility.MaxValue}");
            Console.WriteLine($"Constitution: {characterInfo.Constitution.Value}");
            Console.WriteLine($"Charisma: {characterInfo.Charisma.Value}");
            Console.WriteLine($"Intelligence: {characterInfo.Intelligence.Value}");
        }

        public async void PrintReportsAsync()
        {
            var reports = await GladiatusClient.GetWithSession(
                UriProvider.ExpeditionReportsUri(character),
                character
            );

            var report = new ReportsInterpreter(reports, EncounterType.Expedition);
            foreach (var encounter in report.Encounters)
                Console.WriteLine($"Name: {encounter.Name} - Success? {encounter.Successful} - Gold: {encounter.Gold} - Rubies: {encounter.Rubies}");
        }
    }
}
