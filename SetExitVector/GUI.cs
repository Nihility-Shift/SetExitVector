using VoidManager.CustomGUI;
using static UnityEngine.GUILayout;

namespace SetExitVector
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => $"Set Exit Vector: {(BepinPlugin.Enabled ? "Enabled" : "Disabled")}";

        public override void Draw()
        {
            if (Button($"Set Exit Vector: {(BepinPlugin.Enabled ? "Enabled" : "Disabled")}"))
            {
                BepinPlugin.Enabled = !BepinPlugin.Enabled;
            }
        }
    }
}
