using GladiApi;
using GladiApiConsole;

Character character = await Character.CreateInstanceAsync(DebugConfig.Server, DebugConfig.Country, DebugConfig.SessionHash, DebugConfig.Cookie);

//Get and print character overview
/*
var html = await GladiatusClient.GetWithSession(
    UriProvider.OverviewUri(character, 1),
    character
);

var overview = new CharacterOverview(html);
overview.PrintCharacterOverview();
*/

var reports = await GladiatusClient.GetWithSession(
    UriProvider.ExpeditionReportsUri(character),
    character
);

var report = new ReportsInterpreter(reports, EncounterType.Expedition);
Console.WriteLine(report.debugContent);