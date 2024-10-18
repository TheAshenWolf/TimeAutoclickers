using HarmonyLib;

namespace TimeAutoclickers
{
    [HarmonyPatch(typeof(UIHero)), HarmonyPatch("OnGoldChanged")]
    public class UpgradeAutobuyer
    {
        public static bool Prefix(UIHero __instance)
        {
            if (!AutoClickPlugin.Instance.configAutobuyUpgrades.Value)
            {
                return true;
            }

            Hero hero = Traverse.Create(__instance).Field("hero").GetValue<Hero>();
            if (GoldBank.CanAfford(hero.LevelUpCost()))
            {
                Traverse.Create(__instance).Method("OnClickBuy").GetValue();
                return false;
            }
            return true;
        }
    }
}