using HarmonyLib;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.DataModel;
using MelonLoader;

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
        switch (__instance.baitTypeId.referenceId)
        {
            case "IdentifiableType.StrangeDiamondCraft":
                __result = EntryPoint.LuckyGordo;
                return false;
            case "IdentifiableType.DeepBrineCraft":
                __result = EntryPoint.PuddleGordo;
                return false;
            case "IdentifiableType.LavaDustCraft":
                __result = EntryPoint.FireGordo;
                return false;
            case "IdentifiableType.SunSapCraft":
                __result = EntryPoint.YolkyGordo;
                return false;
            default:
                return true;
        }
        // return true;
    }
    
}