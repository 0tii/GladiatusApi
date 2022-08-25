using GladiApi;
using GladiApiConsole;
using System.Globalization;

Character character = await Character.CreateInstanceAsync(DebugConfig.Server, DebugConfig.Country, DebugConfig.SessionHash, DebugConfig.Cookie);

var html = await GladiatusClient.GetWithSession(
    "https://s56-en.gladiatus.gameforge.com/game/index.php?mod=overview",
    character
);

//Console.WriteLine(html);

var intptr = new HeaderInterpreter(html);

//Console.WriteLine($"Experience: {intptr.debugValue}");

Console.WriteLine($"Server Time is {intptr.ServerTime.ToLongDateString()} UTC");
Console.WriteLine("Character Overview:");
Console.WriteLine($"Gold: {intptr.Gold}");
Console.WriteLine($"Rubies: {intptr.Rubies}");
Console.WriteLine($"Highscore Rank: {intptr.LeaderboardPlacement}");
Console.WriteLine($"Level: {intptr.Experience.Level}");
Console.WriteLine($"Current Xp: {intptr.Experience.CurrenValue}");
Console.WriteLine($"Xp to level up: {intptr.Experience.MaxValue}");
