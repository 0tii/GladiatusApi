namespace GladiApi
{
    public static class ActionUriProvider
    {
        public static string ExpeditionAttack(Character character, int region, int enemy) 
            => $"https://{character.Region}.gladiatus.gameforge.com/game/ajax.php?mod=location&submod=attack&location={region}&stage={enemy}&premium=0";

        public static string HorreumStore(Character character, bool packages, bool inventory)
            => $"";
    }
}
