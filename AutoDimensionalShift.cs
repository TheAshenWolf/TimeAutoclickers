using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace TimeAutoclickers
{
    [HarmonyPatch]
    public class AutoDimensionalShift()
    {
        public static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(UIAbilityButton), "OnAbilityReady");
            yield return AccessTools.Method(typeof(UIAbilityButton), "Start");
        }

        public static void Postfix(UIAbilityButton __instance)
        {
            ActiveAbilities.Ability ability = Traverse.Create(__instance).Field("ability").GetValue<ActiveAbilities.Ability>();

            if (ability == ActiveAbilities.GetAbilities()[6])
            {
                ability.Activate();
            }
        }
    }
}