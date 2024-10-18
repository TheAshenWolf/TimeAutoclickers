using HarmonyLib;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(Arena)), HarmonyPatch("FailBossArena")]
    public class BossSkillActivator
    {
        public static bool Prefix(Arena __instance)
        {
            if (!AutoClickPlugin.Instance.configAutoActivateSkillsOnBossFail.Value)
            {
                return true;
            }

            ActiveAbilities.ActivateAll();
            return true;
        }
    }
}