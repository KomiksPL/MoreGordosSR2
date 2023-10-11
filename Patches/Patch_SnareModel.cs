using HarmonyLib;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.DataModel;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(SnareModel), "GetGordoIdForBait")]
public class Patch_SnareModel
{
    public static bool Prefix(SnareModel __instance, ref IdentifiableType __result)
    {
        if (__instance.baitTypeId.TryCast<SlimeDefinition>())
        {
            __result = EntryPoint.TarrGordo;
            return false;
        }

        switch (__instance.baitTypeId.name)
        {
            case "StrangeDiamondCraft":
                __result = EntryPoint.LuckyGordo;
                return false;
            case "DeepBrineCraft":
                __result = EntryPoint.PuddleGordo;
                return false;
            case "LavaDustCraft":
                __result = EntryPoint.FireGordo;
                return false;
            case "SunSapCraft":
                __result = EntryPoint.YolkyGordo;
                return false;
            default:
                return true;
        }
    }
    
}