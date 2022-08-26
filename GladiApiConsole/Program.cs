using GladiApi;
using GladiApiConsole;
using System.Globalization;

Character character = await Character.CreateInstanceAsync(DebugConfig.Server, DebugConfig.Country, DebugConfig.SessionHash, DebugConfig.Cookie);

var html = await GladiatusClient.GetWithSession(
    "https://s56-en.gladiatus.gameforge.com/game/index.php?mod=overview",
    character
);

//await File.WriteAllTextAsync("html.txt", html);

//Console.WriteLine(html);

var intptr = new HeaderInterpreter(html);

Console.WriteLine($"Cooldown: {intptr.debugValue}");

Console.WriteLine($"Server Time is {intptr.ServerTime.ToLongDateString()} UTC");
Console.WriteLine("Character Overview:");
Console.WriteLine($"Gold: {intptr.Gold}");
Console.WriteLine($"Rubies: {intptr.Rubies}");
Console.WriteLine($"Highscore Rank: {intptr.LeaderboardPlacement}");
Console.WriteLine($"Level: {intptr.Experience.Level}");
Console.WriteLine($"Current Xp: {intptr.Experience.CurrenValue}");
Console.WriteLine($"Xp to level up: {intptr.Experience.MaxValue}");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Expedition Points: {intptr.ExpeditionPoints.CurrentPoints}");
Console.WriteLine($"Expedition Points Max: {intptr.ExpeditionPoints.MaxPoints}");
Console.WriteLine($"Cooldown active? {intptr.ExpeditionPoints.Cooldown}");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Dungeon Points: {intptr.DungeonPoints.CurrentPoints}");
Console.WriteLine($"Dungeon Points Max: {intptr.DungeonPoints.MaxPoints}");
Console.WriteLine($"Cooldown active? {intptr.DungeonPoints.Cooldown}");