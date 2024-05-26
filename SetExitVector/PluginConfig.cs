using BepInEx.Configuration;

namespace SetExitVector
{
    internal class PluginConfig
    {
        internal static ConfigEntry<bool> ExitVector;
        internal static ConfigEntry<bool> SideQuestSector;
        internal static ConfigEntry<bool> MissionSector;
        internal static ConfigEntry<bool> ExitSector;

        internal static void BindConfigs(BepinPlugin plugin)
        {
            ExitVector = plugin.Config.Bind("SetExitVector", "ExitVector", true);
            SideQuestSector = plugin.Config.Bind("SetExitVector", "SideQuestSector", true);
            MissionSector = plugin.Config.Bind("SetExitVector", "MissionSector", true);
            ExitSector = plugin.Config.Bind("SetExitVector", "ExitSector", true);
        }
    }
}
