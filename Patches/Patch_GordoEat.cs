using HarmonyLib;
using Il2Cpp;
using Il2CppSystem.IO;
using MelonLoader;
using UnityEngine;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(GordoEat))]
public static class Patch_GordoEat
{
    public static IdentifiableTypeGroup WaterGroup;
    [HarmonyPatch(nameof(MaybeEat)), HarmonyPrefix]
    internal static bool MaybeEat(GordoEat __instance, ref bool __result, Collider col)
    {
        var gordoIdentifiable = __instance.GetComponent<GordoIdentifiable>();
        bool isModdedGordo = gordoIdentifiable.identType.name.StartsWith("Yolky") 
                             || gordoIdentifiable.identType.name.StartsWith("Fire")
                             || gordoIdentifiable.identType.name.EndsWith("Water");
        
        if (isModdedGordo)
        {
            if (!__instance.CanEat())
            {
                __result = false;
                return false;
            }
            Identifiable identifiable = col.GetComponent<Identifiable>();
            

            if (identifiable &&  __instance._allEats.Contains(identifiable.identType) &&  !__instance._eating.Contains(col.gameObject))
            {
                __instance.DoEat(col.gameObject);
                __instance.SetEatenCount(__instance.GetEatenCount() + 1);
                // bool flag5 = ;
                if (__instance.GetEatenCount() >= __instance.GetTargetCount())
                {
                    __instance.StartCoroutine(__instance.ReachedTarget());
                }
                __result = true;
                return false;
            }

            __result = false;
            return false;
        }
        return true;
    }
    [HarmonyPatch(nameof(GordoEat.Start)), HarmonyPrefix]
    internal static bool StartPrefix(GordoEat __instance)
    {
        var identifiableType = __instance.GetComponent<GordoIdentifiable>().identType;
        WaterGroup ??= SRLookup.Get<IdentifiableTypeGroup>("WaterGroup");

        switch (identifiableType.ReferenceId)
        {
            case "IdentifiableType.PuddleGordo":
            {
                int eatenCount = __instance.GetEatenCount();
                if (eatenCount == -1 || eatenCount < __instance.GetTargetCount())
                {
                    return false;
                }
                __instance.ImmediateReachedTarget();

                __instance._allEats = new Il2CppSystem.Collections.Generic.List<IdentifiableType>(WaterGroup.GetAllMembers());
                return false;
            }
            case "IdentifiableType.YolkyGordo":
            {
                __instance._allEats = new Il2CppSystem.Collections.Generic.List<IdentifiableType>(EntryPoint.TabbyDef.Diet.GetDietIdentifiableIds());
                return false;
            }
            case "IdentifiableType.FireGordo":
            {
                __instance._allEats = new Il2CppSystem.Collections.Generic.List<IdentifiableType>(EntryPoint.TabbyDef.Diet.GetDietIdentifiableIds());
                return false;
            }
        }
        return true;
    }
    
    
}