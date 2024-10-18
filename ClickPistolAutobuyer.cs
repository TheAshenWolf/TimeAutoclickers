using HarmonyLib;
using UnityEngine;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(UISkillList)), HarmonyPatch("Start")]
    public class ClickPistolAutobuyer()
    {
        public static void Postfix()
        {
            if (!AutoClickPlugin.Instance.configAutobuyClickPistol.Value)
            {
                return;
            }

            UISkill uiSkill = Object.FindObjectOfType<UISkill>();
            Traverse onClickBuyMethod = Traverse.Create(uiSkill).Method("OnClickBuy");
            for (int i = 0; i < 13; i++)
            {
                onClickBuyMethod.GetValue();
            }
        }
    }
}