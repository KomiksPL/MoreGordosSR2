using HarmonyLib;
using Il2Cpp;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(AutoSaveDirector), "Awake")]
public static class Patch_AutoSaveDirector
{
    public static void Prefix(AutoSaveDirector __instance)
    {
        foreach (IdentifiableTypeGroup identifiableTypeGroup in __instance.identifiableTypes.memberGroups)
        {
            if (!identifiableTypeGroup.name.Equals("GordoGroup")) continue;
            identifiableTypeGroup.memberTypes.Add(EntryPoint.FireGordo);
            identifiableTypeGroup.memberTypes.Add(EntryPoint.LuckyGordo);
            identifiableTypeGroup.memberTypes.Add(EntryPoint.PuddleGordo);
            identifiableTypeGroup.memberTypes.Add(EntryPoint.YolkyGordo);
            identifiableTypeGroup.memberTypes.Add(EntryPoint.TarrGordo);
        }
        
    }
}