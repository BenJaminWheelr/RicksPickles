using HarmonyLib;
using TMPro;
using UnityEngine;


namespace Plugin.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class ScanPatch
    {
        public static Plugin plugin = Plugin.instance;
        private static TextMeshProUGUI _textMesh;

        [HarmonyPatch(typeof(HUDManager), "UpdateScanNodes")]
        [HarmonyPostfix]
        static void PrintScanNodesName(ref RectTransform[] ___scanElements)
        {
            for (int i = 0; i < ___scanElements.Length; i++)
            {
                var scanElementText = ___scanElements[i].gameObject.GetComponentsInChildren<TextMeshProUGUI>();
                if (scanElementText.Length > 1)
                {
                    if (scanElementText[0].text == "Jar of pickles")
                    {
                        scanElementText[0].text = "Ricks' Pickles";
                    }
                }
            }
        }
    }
}
