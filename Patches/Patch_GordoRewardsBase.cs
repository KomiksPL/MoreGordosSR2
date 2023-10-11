using HarmonyLib;
using Il2Cpp;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(GordoRewardsBase), "GiveRewards")]
public class Patch_GordoRewardsBase
{
    public static void Prefix(GordoRewardsBase __instance)
    {
        if (__instance.eat == null) return;
        if (__instance.eat.snareModel == null) return;
        if (__instance.eat.snareModel.gordoTypeId == null) return;
        
        if (__instance.eat.snareModel.gordoTypeId == EntryPoint.FireGordo)
        {
            __instance.eat.slimeDefinition.prefab = EntryPoint.FireDef.prefab;
        }
        if (__instance.eat.snareModel.gordoTypeId == EntryPoint.YolkyGordo)
        {
            __instance.eat.slimeDefinition.prefab = EntryPoint.YolkyDef.prefab;
        }
    }
    public static void Postfix(GordoRewardsBase __instance)
    {
        if (__instance.eat == null) return;
        if (__instance.eat.snareModel == null) return;
        if (__instance.eat.snareModel.gordoTypeId == null) return;
        if (__instance.eat.snareModel.gordoTypeId == EntryPoint.FireGordo)
        {
            __instance.eat.slimeDefinition.prefab = EntryPoint.PinkDef.prefab;
        }
        if (__instance.eat.snareModel.gordoTypeId == EntryPoint.YolkyGordo)
        {
            __instance.eat.slimeDefinition.prefab = EntryPoint.PinkDef.prefab;
        }
    }
}