using HarmonyLib;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(UIHero)), HarmonyPatch("OnGoldChanged")]
    public class UpgradeAutobuyer
    {
        public static bool Prefix(UIHero __instance)
        {
            Hero hero = Traverse.Create(__instance).Field("hero").GetValue<Hero>();
            if (GoldBank.CanAfford(hero.LevelUpCost()))
            {
                Traverse.Create(__instance).Method("OnClickBuy").GetValue();
                AutoClickPlugin.Logger.LogInfo("Buying upgrade for " + hero.name);
                return false;
            }
            return true;
        }
    }
}