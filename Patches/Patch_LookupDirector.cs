using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(LookupDirector), nameof(LookupDirector.Awake))]
public static class Patch_LookupDirector
{
    public static void Prefix(LookupDirector __instance)
    {
        MelonLogger.Msg("yes");
        foreach (IdentifiableTypeGroup identifiableTypeGroup in __instance._allIdentifiableTypeGroups.items)
        {
            if (!identifiableTypeGroup.name.Equals("GordoGroup")) continue;
            identifiableTypeGroup._memberTypes.Add(EntryPoint.FireGordo);
            identifiableTypeGroup._memberTypes.Add(EntryPoint.LuckyGordo);
            identifiableTypeGroup._memberTypes.Add(EntryPoint.PuddleGordo);
            identifiableTypeGroup._memberTypes.Add(EntryPoint.YolkyGordo);
            identifiableTypeGroup._memberTypes.Add(EntryPoint.TarrGordo);
        }
        
    }
}