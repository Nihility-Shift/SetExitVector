using Gameplay.Quests;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Reflection;
using UI.AstralMap;

namespace SetExitVector
{
    [HarmonyPatch(typeof(AstralMapController), "VoidEntered")]
    internal class AstralMapControllerPatch
    {
        private static readonly MethodInfo SelectDestinationMethod = AccessTools.Method(typeof(ObjectiveDisplay), "SelectDestination");

        static void Postfix(ObjectiveDisplay ____sectorDisplay, List<UIObjective> ____uiObjectives)
        {
            if (!PhotonNetwork.IsMasterClient || GameSessionManager.ActiveSession.ActiveQuest is EndlessQuest) return;

            List<UIObjective> activeObjectives = ____uiObjectives.FindAll(uiObjective => uiObjective.SectorState.Value == UIObjective.MapObjectState.Active);

            if (PluginConfig.SideQuestSector.Value &&
                SetSector(activeObjectives, ____sectorDisplay,
                uiObjective => !uiObjective.IsMainObjective && !uiObjective.IsInterdiction && !uiObjective.isExiting)) return;

            if (PluginConfig.MissionSector.Value &&
                SetSector(activeObjectives, ____sectorDisplay,
                uiObjective => uiObjective.IsMainObjective)) return;

            if (PluginConfig.ExitSector.Value &&
                SetSector(activeObjectives, ____sectorDisplay,
                uiObjective => uiObjective.isExiting)) return;
        }

        private static bool SetSector(List<UIObjective> objectives, ObjectiveDisplay display, Predicate<UIObjective> sectorConditions)
        {
            foreach (UIObjective uiObjective in objectives)
            {
                if (sectorConditions(uiObjective))
                {
                    SelectDestinationMethod.Invoke(display, new object[] { uiObjective });
                    return true;
                }
            }
            return false;
        }
    }
}
