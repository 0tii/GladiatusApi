using GladiApi;
using GladiApiConsole;

string gaoContent = System.IO.File.ReadAllText(@"C:\Users\Daniel\Downloads\character.gao");

Character character = await Character.CreateInstanceAsync(gaoContent, "yolo");

//Get and print character overview
/*
var html = await character.HttpClient.GetWithSession(
    UriProvider.OverviewUri(character, 1),
    character
);

var overview = new CharacterOverview(character, html);
overview.PrintCharacterOverview();
*/
//await overview.PrintReportsAsync();


//await character.Horreum.StoreResources(true, true, true);
