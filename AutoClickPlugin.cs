using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace TimeAutoclickers
{
    [BepInPlugin(Constants.PLUGIN_GUID, Constants.PLUGIN_NAME, Constants.PLUGIN_VERSION)]
    public class AutoClickPlugin : BaseUnityPlugin
    {
        public static AutoClickPlugin Instance { get; private set; }
        public new static ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            Logger = base.Logger;

            Logger.LogInfo($"Running Ashen's AutoClicker Plugin v{Constants.PLUGIN_VERSION}");
            Logger.LogInfo("https://github.com/TheAshenWolf/TimeAutoclickers");

            Instance = this;
            Harmony harmony = new Harmony(Constants.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
}