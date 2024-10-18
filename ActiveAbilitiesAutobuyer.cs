using HarmonyLib;
using UnityEngine;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(UIAbilityUnlocks)), HarmonyPatch("Refresh")]
    public class ActiveAbilitiesAutobuyer()
    {
        public static void Postfix(UIAbilityUnlocks __instance)
        {
            if (!AutoClickPlugin.Instance.configAutobuyActiveAbilities.Value)
            {
                return;
            }

            // As buying an ability calls the Refresh, we don't need to loop this
            if (__instance.unlockButton.interactable)
            {
                __instance.unlockButton.onClick.Invoke();
            }
        }
    }
}