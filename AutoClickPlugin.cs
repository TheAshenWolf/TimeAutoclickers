using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace TimeAutoclickers
{
    [BepInPlugin(Constants.PLUGIN_GUID, Constants.PLUGIN_NAME, Constants.PLUGIN_VERSION)]
    public class AutoClickPlugin : BaseUnityPlugin
    {
        public static AutoClickPlugin Instance { get; private set; }
        public new static ManualLogSource Logger { get; private set; }

        public ConfigEntry<bool> configAutobuyUpgrades;
        public ConfigEntry<bool> configAutobuyClickPistol;
        public ConfigEntry<bool> configAutobuyActiveAbilities;

        public ConfigEntry<bool> configAutorunDimensionalShift;
        public ConfigEntry<bool> configAutoActivateSkillsOnBossFail;
        public ConfigEntry<bool> configAutoActivateCooldownSkill;

        public ConfigEntry<bool> configAutoIdle;

        private void Awake()
        {
            Logger = base.Logger;

            SetupConfig();

            Logger.LogInfo($"Running Ashen's AutoClicker Plugin v{Constants.PLUGIN_VERSION}");
            Logger.LogInfo("https://github.com/TheAshenWolf/TimeAutoclickers");

            Instance = this;
            Harmony harmony = new Harmony(Constants.PLUGIN_GUID);
            harmony.PatchAll();
        }

        private void SetupConfig()
        {
            configAutobuyUpgrades = Config.Bind("Autobuyers", "Autobuy Upgrades", true,
                "Automatically buys upgrades as soon as they are affordable.");
            configAutobuyClickPistol = Config.Bind("Autobuyers", "Autobuy Click Pistol", true,
                "Automatically buys the Click Pistol upgrade as soon as it is affordable.");
            configAutobuyActiveAbilities = Config.Bind("Autobuyers", "Autobuy Active Abilities", true,
                "Automatically buys active abilities as soon as they are affordable.");

            configAutorunDimensionalShift = Config.Bind("Skills", "Autorun Dimensional Shift", true,
                "Performs the Dimensional Shift on cooldown.");
            configAutoActivateSkillsOnBossFail = Config.Bind("Skills", "Auto-Activate Skills on Boss Fail", true,
                "Automatically activates skills when you fail a boss arena.");
            configAutoActivateCooldownSkill = Config.Bind("Skills", "Auto-Activate Cooldown Skill", true,
                "Automatically runs the cooldown skill on cooldown.");

            configAutoIdle = Config.Bind("Misc", "Auto Idle", true,
                "Automatically switches the guns to idle.");
        }
    }
}