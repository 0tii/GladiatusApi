using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Central provider for document GET URIs of different game pages
    /// </summary>
    public static class UriProvider
    {
        public static string OverviewUri(Character chr, bool withSession = false)
            => $"https://{chr.Authentication.ServerId}.gladiatus.gameforge.com/game/index.php?mod=overview{(withSession ? $"&sh={chr.Authentication.SessionHash}" : "")}";

        public static string OverviewUri(Character chr, int doll, bool withSession = false)
            => $"https://{chr.Authentication.ServerId}.gladiatus.gameforge.com/game/index.php?mod=overview&doll={doll}{(withSession ? $"&sh={chr.Authentication.SessionHash}" : "")}";

        public static string ExpeditionReportsUri(Character chr, bool withSession = false)
            => $"https://{chr.Authentication.ServerId}.gladiatus.gameforge.com/game/index.php?mod=reports&submod=showExpeditions{(withSession ? $"&sh={chr.Authentication.SessionHash}" : "")}";

        public static string DungeonReportsUri(Character chr, bool withSession = false)
            => $"https://{chr.Authentication.ServerId}.gladiatus.gameforge.com/game/index.php?mod=reports&submod=showDungeons{(withSession ? $"&sh={chr.Authentication.SessionHash}" : "")}";

        public static string ArenaReportsUri(Character chr, bool withSession = false)
            => $"https://{chr.Authentication.ServerId}.gladiatus.gameforge.com/game/index.php?mod=reports&submod=showArena{(withSession ? $"&sh={chr.Authentication.SessionHash}" : "")}";

        public static string CircusTurmaReportsUri(Character chr, bool withSession = false)
            => $"https://{chr.Authentication.ServerId}.gladiatus.gameforge.com/game/index.php?mod=reports&submod=showCircusTurma{(withSession ? $"&sh={chr.Authentication.SessionHash}" : "")}";
    }
}
