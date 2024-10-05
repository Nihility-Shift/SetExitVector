using VoidManager.CustomGUI;
using static UnityEngine.GUILayout;

namespace SetExitVector
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "Set Exit Vector";

        public override void Draw()
        {
            Label("When charging the Void Drive");
            if (Button($"Set Exit Vector: {(PluginConfig.ExitVector.Value ? "Enabled" : "Disabled")}"))
            {
                PluginConfig.ExitVector.Value = !PluginConfig.ExitVector.Value;
            }

            /* features disabled
            Label("When entering a Void Jump");
            if (Button($"Select Side Quests: {(PluginConfig.SideQuestSector.Value ? "Enabled" : "Disabled")}"))
            {
                PluginConfig.SideQuestSector.Value = !PluginConfig.SideQuestSector.Value;
            }
            if (Button($"Select Mission Quests: {(PluginConfig.MissionSector.Value ? "Enabled" : "Disabled")}"))
            {
                PluginConfig.MissionSector.Value = !PluginConfig.MissionSector.Value;
            }
            if (Button($"Select Exit Sector: {(PluginConfig.ExitSector.Value ? "Enabled" : "Disabled")}"))
            {
                PluginConfig.ExitSector.Value = !PluginConfig.ExitSector.Value;
            }
            */
        }
    }
}
