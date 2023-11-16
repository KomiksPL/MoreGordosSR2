using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(GordoEat))]
public static class Patch_GordoEat
{
    public static IdentifiableTypeGroup WaterGroup;
    [HarmonyPatch(nameof(MaybeEat)), HarmonyPrefix]
    internal static bool MaybeEat(GordoEat __instance, ref bool __result, Collider col)
    {
        WaterGroup ??= SRLookup.Get<IdentifiableTypeGroup>("WaterGroup");
        if (__instance.GetComponent<GordoIdentifiable>().identType == EntryPoint.PuddleGordo)
        {
            if (!__instance.CanEat())
            {
                __result = false;
                return false;
            }
            Identifiable identifiable = col.GetComponent<Identifiable>();
            if (identifiable != null && WaterGroup.IsMember(identifiable.identType) && !__instance._eating.Contains(col.gameObject))
            {
                __instance.DoEat(col.gameObject);
                __instance.SetEatenCount(__instance.GetEatenCount() + 1);
                bool flag5 = __instance.GetEatenCount() >= __instance.GetTargetCount();
                if (flag5)
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
    [HarmonyPatch(nameof(Start)), HarmonyPrefix]
    internal static bool Start(GordoEat __instance)
    {

        if (__instance.GetComponent<GordoIdentifiable>().identType == EntryPoint.PuddleGordo)
        {
            int eatenCount = __instance.GetEatenCount();
            if (eatenCount == -1 || eatenCount < __instance.GetTargetCount())
            {
                return false;
            }
            __instance.ImmediateReachedTarget();
            return false;
        }
        return true;
    }
    
}