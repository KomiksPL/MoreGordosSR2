using HarmonyLib;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.Damage;
using Il2CppMonomiPark.SlimeRancher.Regions;
using MelonLoader;
using UnityEngine;

namespace MoreGordosMod.Patches;

[HarmonyPatch(typeof(GordoSnare))]
public static class Patch_GordoSnare
{
    private static void RemoveComponent<T>(this GameObject @this, GordoSnare gordoSnare) where T : Component
    {
        gordoSnare.RemoveComponent<T>(@this);
    }
    private static void RemoveComponents<T>(this GameObject @this, GordoSnare gordoSnare) where T : Component
    {
        gordoSnare.RemoveComponents<T>(@this);
    }
    [HarmonyPatch(nameof(AttachBait)), HarmonyPrefix]
    public static bool AttachBait(GordoSnare __instance, IdentifiableType id)
    {
        if (id.TryCast<SlimeDefinition>())
        {
            __instance.ClearBait();
            __instance._model.baitTypeId = id;
            __instance.Bait = UnityEngine.Object.Instantiate<GameObject>(id.prefab, __instance.transform);
            __instance.Bait.transform.position = __instance.BaitPosition.transform.position;
            __instance.Bait.transform.rotation = Quaternion.identity;
            GameObject bait = __instance.Bait;
            bait.RemoveComponents<Collider>(__instance);
            bait.RemoveComponent<DragFloatReactor>(__instance);
            bait.RemoveComponent<Rigidbody>(__instance);
            bait.RemoveComponent<KeepUpright>(__instance);
            bait.RemoveComponent<DontGoThroughThings>(__instance);
            bait.RemoveComponent<SECTR_PointSource>(__instance);
            bait.RemoveComponent<RegionMember>(__instance);
            bait.RemoveComponent<ChickenRandomMove>(__instance);
            bait.RemoveComponent<PlaySoundOnHit>(__instance);
            bait.RemoveComponent<ResourceCycle>(__instance);
            bait.RemoveComponent<Reproduce>(__instance);
            bait.RemoveComponent<SlimeEmotions>(__instance);
            bait.RemoveComponent<SlimeFaceAnimator>(__instance);
            bait.RemoveComponent<SlimeEat>(__instance);
            bait.RemoveComponent<SlimeEatAsh>(__instance);
            bait.RemoveComponent<SlimeEatWater>(__instance);
            bait.RemoveComponent<SlimeEatTrigger>(__instance);
            bait.RemoveComponent<SlimeSubbehaviourPlexer>(__instance);
            bait.RemoveComponents<SlimeSubbehaviour>(__instance);
            Animator animator = __instance.Bait.GetComponentInChildren<Animator>();
            if (animator)
            {
                animator.SetBool(Grounded, true);
            }
            return false;
        }
        return true;
    }

    [HarmonyPatch(nameof(OnTriggerEnter)), HarmonyPrefix]
    public static bool OnTriggerEnter(GordoSnare __instance, Collider col)
    {
        Identifiable component = col.GetComponent<Identifiable>();
        if (!col.isTrigger && __instance.Bait == null && !__instance.HasSnaredGordo())
        {
            Damage ??= new Damage()
            {
                DamageSource = Resources.FindObjectsOfTypeAll<DamageSourceDefinition>().First(),
            };
            if (!component)
            {
                return true;
            }
            if (component.identType.TryCast<SlimeDefinition>()|| EntryPoint.CustomResources.Contains(component.identType))
            {
                // MelonLogger.Msg("Test: TryCast<SlimeDefinition>");
                __instance.AttachBait(component.identType);
                DeathHandler.Kill(component.gameObject, Damage);
                return false;
                // return AttachBait(col, __instance);

            }
            // if ()
            // {
            //     __instance.AttachBait(component.identType);
            //     DeathHandler.Kill(component.gameObject, Damage);
            //     return false;
            // }
        }
        return true;
    }

    public static Damage Damage;
    
    private static readonly int Grounded = Animator.StringToHash("grounded");
    
}