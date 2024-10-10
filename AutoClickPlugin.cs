using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace TimeAutoclickers
{
    public static class Constants
    {
        public const string PLUGIN_GUID = "com.github.TheAshenWolf.TimeAutoclickers";
        public const string PLUGIN_NAME = "TimeAutoclickers";
        public const string PLUGIN_VERSION = "1.0.0";
    }


    [BepInPlugin(Constants.PLUGIN_GUID, Constants.PLUGIN_NAME, Constants.PLUGIN_VERSION)]
    public class AutoClickPlugin : BaseUnityPlugin
    {
        public static ManualLogSource logger;

        private void Awake()
        {
            Logger.LogInfo($"Time to autoclick!");
            logger = Logger;

            Harmony harmony = new Harmony(Constants.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(UIHero)), HarmonyPatch("OnGoldChanged")]
    public class Autobuy
    {
        public static bool Prefix(UIHero __instance)
        {
            Hero hero = Traverse.Create(__instance).Field("hero").GetValue<Hero>();
            if (GoldBank.CanAfford(hero.LevelUpCost()))
            {
                Traverse.Create(__instance).Method("OnClickBuy").GetValue();
                AutoClickPlugin.logger.LogInfo("Buying upgrade for " + hero.name);
                return false;
            }
            return true;
        }
    }
}