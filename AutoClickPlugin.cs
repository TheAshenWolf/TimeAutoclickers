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
        public const string PLUGIN_VERSION = "1.1.0";
    }


    [BepInPlugin(Constants.PLUGIN_GUID, Constants.PLUGIN_NAME, Constants.PLUGIN_VERSION)]
    public class AutoClickPlugin : BaseUnityPlugin
    {
        public static ManualLogSource logger;

        private void Awake()
        {
            Logger.LogInfo($"Running Ashen's AutoClicker Plugin v{Constants.PLUGIN_VERSION}");
            Logger.LogInfo("https://github.com/TheAshenWolf/TimeAutoclickers");
            logger = Logger;

            Harmony harmony = new Harmony(Constants.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
}