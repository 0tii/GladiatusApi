using GladiApi;
using GladiApiConsole;

Character character = await Character.CreateInstanceAsync(DebugConfig.Server, DebugConfig.Country, DebugConfig.SessionHash, DebugConfig.Cookie);

var intptr = new HeaderInterpreter(await GladiatusClient.GetWithSession(
    "https://s56-en.gladiatus.gameforge.com/game/index.php?mod=overview",
    character
));

Console.WriteLine("Character Overview:");
Console.WriteLine($"Gold: {intptr.Gold}");
Console.WriteLine($"Rubies: {intptr.Rubies}");
Console.WriteLine($"Highscore Rank: {intptr.LeaderboardPlacement}");
Console.WriteLine($"Level: {intptr.Level.CurrenValue}");