using System.Collections;
using HarmonyLib;
using Il2CppMonomiPark.SlimeRancher.UI.Localization;
using MelonLoader;
using UnityEngine;
using UnityEngine.Localization.Tables;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(LocalizationDirector), "LoadTables")]
public static class Patch_LocalizationDirector
{
    private static IEnumerator LoadTable(LocalizationDirector director)
    {
        WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(0.1f);
        yield return waitForSecondsRealtime;
        StringTable pedia = director.Tables["Pedia"];
        pedia.AddEntry("t.tarr_gordo", "Tarr Gordo");
        pedia.AddEntry("t.fire_gordo", "Fire Gordo");
        pedia.AddEntry("t.puddle_gordo", "Puddle Gordo");
        pedia.AddEntry("t.lucky_gordo", "Lucky Gordo");
        pedia.AddEntry("t.yolky_gordo", "Yolky Gordo");
        StringTable ui = director.Tables["UI"];
        ui.AddEntry("m.foodgroup.nontarrgold_slimes", "Slimes and Ranchers");
    }
    public static void Postfix(LocalizationDirector __instance)
    {
        MelonCoroutines.Start(LoadTable(__instance));
    }
}