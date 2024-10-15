using HarmonyLib;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(Arena)), HarmonyPatch("FailBossArena")]
    public class BossSkillActivator
    {
        public static bool Prefix(Arena __instance)
        {
            AutoClickPlugin.Logger.LogInfo("Failed the boss arena. Attempting to activate skills.");
            ActiveAbilities.ActivateAll();
            return true;
        }
    }
}