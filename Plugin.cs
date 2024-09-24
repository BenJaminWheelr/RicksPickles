using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Plugin.Patches;

namespace Plugin
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "POOPMAN.RICKSPICKLES";
        private const string modName = "RICKSPICKLES";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        public static Plugin instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("I have awaken");

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PickleSearch));
            harmony.PatchAll(typeof(ScanPatch));


        }

    }
}
