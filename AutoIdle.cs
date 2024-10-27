using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(Arena)), HarmonyPatch("StartArena")]
    public class AutoIdle
    {
        public static void Postfix()
        {
            UIButtonIdleMode[] buttons = Object.FindObjectsOfType<UIButtonIdleMode>();
            foreach (UIButtonIdleMode button in buttons)
            {
                if ((int)Traverse.Create(button).Field("weaponMode").GetValue() == 1)
                    continue;
                Traverse.Create(button).Field("button").GetValue<Button>().onClick.Invoke();
            }
        }
    }
}