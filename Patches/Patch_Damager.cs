using HarmonyLib;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.Damage;
using UnityEngine;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(Damager), "TryToDamage")]
public static class Patch_Damager
{
    public static void Prefix(Damager __instance, GameObject gameObj)
    {
        GordoIdentifiable component = __instance.GetComponent<GordoIdentifiable>();
        if (component != null && component.identType == EntryPoint.TarrGordo)
        {
            GordoEat component2 = __instance.GetComponent<GordoEat>();
            if (component2.eatFX != null)
            {
                SRBehaviour.SpawnAndPlayFX(component2.eatFX, gameObj.transform.position, gameObj.transform.localRotation);
            }
            if (component2.eatCue != null)
            {
                SECTR_AudioSystem.Play(component2.eatCue, gameObj.transform.position, false);
            }
            component2.eating.Add(gameObj);
            component2.SetEatenCount(component2.GetEatenCount() + 1);
            if (component2.GetEatenCount() >= component2.GetTargetCount())
            {
                component2.StartCoroutine(component2.ReachedTarget());
            }
        }
    }
}