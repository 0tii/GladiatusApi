namespace GladiApi
{
    public static class ActionUriProvider
    {
        public static string ExpeditionAttack(Character character, int region, int enemy) 
            => $"https://{character.Region}.gladiatus.gameforge.com/game/ajax.php?mod=location&submod=attack&location={region}&stage={enemy}&premium=0";

        /// <summary>
        /// [POST] Horreum Store Materials. Must be posted with ajax=true and body like:
        /// <code>
        /// {
        ///     {"inventory", "1"}, //boolean
        ///     {"packages", "1"}, //boolean
        ///     {"sell", "1"} //1 = sell, 0 = delete
        /// }
        /// </code>
        /// </summary>
        /// <returns></returns>
        public static string HorreumStore(Character character, bool packages, bool inventory)
            => $"https://{character.Region}.gladiatus.gameforge.com/game/ajax.php?mod=forge&submod=storageIn";
    }
}
