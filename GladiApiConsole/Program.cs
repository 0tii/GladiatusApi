using GladiApi;
using GladiApiConsole;

Character character = await Character.CreateInstanceAsync(DebugConfig.Server, DebugConfig.Country, DebugConfig.SessionHash, DebugConfig.Cookie);

var intprt = new HeaderInterpreter(await GladiatusClient.GetWithSession(
    "https://s56-en.gladiatus.gameforge.com/game/index.php?mod=overview",
    character
));

Console.WriteLine(intprt.Gold);