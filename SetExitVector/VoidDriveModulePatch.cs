using CG.Game.SpaceObjects.Controllers;
using CG.Ship.Modules;
using HarmonyLib;
using Photon.Pun;

namespace SetExitVector
{
    [HarmonyPatch(typeof(VoidDriveModule), "SetEngineCharging")]
    internal class VoidDriveModulePatch
    {
        static void Postfix(VoidDriveModule __instance, VoidJumpSystem ___voidJumpSystem, bool[] ___engineStates)
        {
            //Host, config, vector already set, interdiction
            if (!PhotonNetwork.IsMasterClient || !PluginConfig.ExitVector.Value || ___voidJumpSystem.IsExitVectorSet() || __instance.VoidJumpCapable.Value <= 0) return;
            foreach (bool state in ___engineStates) if (!state) return;
            ___voidJumpSystem.ExitVectorSet(true);
        }
    }
}
