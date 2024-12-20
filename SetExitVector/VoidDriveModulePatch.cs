using CG.Game.SpaceObjects.Controllers;
using CG.Ship.Modules;
using HarmonyLib;
using Photon.Pun;

namespace SetExitVector
{
    //If all engines are charging, assign exit vector when last engine is set to start charging..
    [HarmonyPatch(typeof(VoidDriveModule), "SetEngineCharging")]
    internal class VoidDriveModulePatch
    {
        static void Postfix(VoidDriveModule __instance, VoidJumpSystem ___voidJumpSystem, bool[] ___engineChargedStates)
        {
            //Host, config, vector already set, interdiction
            if (!PhotonNetwork.IsMasterClient || !PluginConfig.ExitVector.Value || ___voidJumpSystem.IsExitVectorSet() || __instance.VoidJumpCapable.Value <= 0) return;
            foreach (bool state in ___engineChargedStates) if (!state) return;
            ___voidJumpSystem.ExitVectorSet(true);
        }
    }
}
