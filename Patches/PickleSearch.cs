using System;
using HarmonyLib;


namespace Plugin.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class PickleSearch
    {
        public static Plugin plugin = Plugin.instance;


        [HarmonyPatch(nameof(RoundManager.LoadNewLevel))]
        [HarmonyPrefix]
        static bool Pickle_Search(ref SelectableLevel newLevel)
        {
            try
            {
                foreach (var item in newLevel.spawnableScrap)
                {
                    if (item.spawnableItem.itemName == "Jar of pickles")
                    {
                        plugin.mls.LogInfo("------FOUND---PICKLES------");
                        item.spawnableItem.itemName = "Ricks' Pickles";
                        item.spawnableItem.minValue = 100;
                        item.spawnableItem.maxValue = 5000;
                    }
                }
            }
            catch (Exception ex)
            {
                // Error when landing on Company Planet
            }
            return true;

        }
    }
}
