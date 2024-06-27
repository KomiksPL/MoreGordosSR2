using HarmonyLib;
using Il2Cpp;

namespace MoreGordosMod.Patches;

// [HarmonyPatch(typeof(GordoRewardsBase), "GiveRewards")]
// public static class Patch_GordoRewardsBase
// {
//     public static void Prefix(GordoRewardsBase __instance)
//     {
//         // if (!__instance._eat) return;
//         // if (__instance._eat.SnareModel == null) return;
//         // if (!__instance._eat.SnareModel.gordoTypeId) return;
//         //
//         // if (__instance._eat.SnareModel.gordoTypeId == EntryPoint.FireGordo)
//         // {
//         //     __instance._eat.SlimeDefinition.prefab = EntryPoint.FireDef.prefab;
//         // }
//         // if (__instance._eat.SnareModel.gordoTypeId == EntryPoint.YolkyGordo)
//         // {
//         //     __instance._eat.SlimeDefinition.prefab = EntryPoint.YolkyDef.prefab;
//         // }
//     }
//     public static void Postfix(GordoRewardsBase __instance)
//     {
//         // if (!__instance._eat) return;
//         // if (__instance._eat.SnareModel == null) return;
//         // if (!__instance._eat.SnareModel.gordoTypeId) return;
//         // if (__instance._eat.SnareModel.gordoTypeId == EntryPoint.FireGordo)
//         // {
//         //     __instance._eat.SlimeDefinition.prefab = EntryPoint.PinkDef.prefab;
//         // }
//         // if (__instance._eat.SnareModel.gordoTypeId == EntryPoint.YolkyGordo)
//         // {
//         //     __instance._eat.SlimeDefinition.prefab = EntryPoint.PinkDef.prefab;
//         // }
//     }
// }
