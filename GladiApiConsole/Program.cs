using GladiApi;

Character character = await Character.CreateInstanceAsync(DebugConfig.Server, DebugConfig.Country, DebugConfig.SessionHash, DebugConfig.Cookie);

var html = await GladiatusClient.GetWithSession(
    UriProvider.OverviewUri(character),
    character
);

//System.IO.File.WriteAllText (@"D:\keincooldown.html",  html);

var intptr = new OverviewInterpreter(html);

//Console.WriteLine($"Debug Value='{intptr.debugValue}'");

Console.WriteLine($"Server Time is {intptr.Header.ServerTime.ToLongDateString()} UTC");
Console.WriteLine("Character Overview:");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Gold: {intptr.Header.Gold}");
Console.WriteLine($"Rubies: {intptr.Header.Rubies}");
Console.WriteLine($"Highscore Rank: {intptr.Header.LeaderboardPlacement}");
Console.WriteLine($"Level: {intptr.Header.Experience.Level}");
Console.WriteLine($"Current Xp: {intptr.Header.Experience.CurrenValue}");
Console.WriteLine($"Xp to level up: {intptr.Header.Experience.MaxValue}");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Expedition Points: {intptr.Header.ExpeditionPoints.CurrentPoints}");
Console.WriteLine($"Expedition Points Max: {intptr.Header.ExpeditionPoints.MaxPoints}");
Console.WriteLine($"Cooldown active? {intptr.Header.ExpeditionPoints.Cooldown}");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Dungeon Points: {intptr.Header.DungeonPoints.CurrentPoints}");
Console.WriteLine($"Dungeon Points Max: {intptr.Header.DungeonPoints.MaxPoints}");
Console.WriteLine($"Cooldown active? {intptr.Header.DungeonPoints.Cooldown}");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Arena cooldown: {intptr.Header.Arena.Cooldown}");
Console.WriteLine($"Turma cooldown: {intptr.Header.CircusTurma.Cooldown}");
Console.WriteLine($"---------------------------------------");
Console.WriteLine($"Stats:");
Console.WriteLine($"Strength: {intptr.Strength.Value}");
Console.WriteLine($"Dexterity: {intptr.Dexterity.Value}");
Console.WriteLine($"Agility: Current: {intptr.Agility.Value} Base: {intptr.Agility.BaseValue} Max: {intptr.Agility.MaxValue}");
Console.WriteLine($"Constitution: {intptr.Constitution.Value}");
Console.WriteLine($"Charisma: {intptr.Charisma.Value}");
Console.WriteLine($"Intelligence: {intptr.Intelligence.Value}");

