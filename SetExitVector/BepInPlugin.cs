using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace SetExitVector
{
    static class MyPluginInfo
    {
        public const string PLUGIN_GUID = "id107.setexitvector";
        public const string PLUGIN_NAME = "SetExitVector";
        public const string PLUGIN_VERSION = "1.0.1";
    }

    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            PluginConfig.BindConfigs(this);
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}