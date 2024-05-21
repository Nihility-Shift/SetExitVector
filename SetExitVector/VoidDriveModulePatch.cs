using CG.Game.SpaceObjects.Controllers;
using CG.Ship.Modules;
using HarmonyLib;

namespace SetExitVector
{
    [HarmonyPatch(typeof(VoidDriveModule), "SetEngineCharging")]
    internal class VoidDriveModulePatch
    {
        static void Postfix(VoidDriveModule __instance, VoidJumpSystem ___voidJumpSystem, bool[] ___engineStates)
        {
            if (!BepinPlugin.Enabled || !__instance.photonView.AmOwner || ___voidJumpSystem.IsExitVectorSet()) return;
            foreach (bool state in ___engineStates) if (!state) return;
            ___voidJumpSystem.ExitVectorSet(true);
        }
    }
}
