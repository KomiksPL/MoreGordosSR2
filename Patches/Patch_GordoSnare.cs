using HarmonyLib;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.Regions;
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
    public static void AttachBait(GordoSnare __instance, IdentifiableType id)
    {
        if (id.TryCast<SlimeDefinition>())
        {
            GameObject bait = __instance.Bait;
            RemoveComponents<Collider>(bait, __instance);
            RemoveComponent<DragFloatReactor>(bait, __instance);
            RemoveComponent<Rigidbody>(bait, __instance);
            RemoveComponent<KeepUpright>(bait, __instance);
            RemoveComponent<DontGoThroughThings>(bait, __instance);
            RemoveComponent<SECTR_PointSource>(bait, __instance);
            RemoveComponent<RegionMember>(bait, __instance);
            RemoveComponent<ChickenRandomMove>(bait, __instance);
            RemoveComponent<PlaySoundOnHit>(bait, __instance);
            RemoveComponent<ResourceCycle>(bait, __instance);
            RemoveComponent<Reproduce>(bait, __instance);
            RemoveComponent<SlimeEmotions>(bait, __instance);
            RemoveComponent<SlimeFaceAnimator>(bait, __instance);
            RemoveComponent<SlimeEat>(bait, __instance);
            RemoveComponent<SlimeEatAsh>(bait, __instance);
            RemoveComponent<SlimeEatWater>(bait, __instance);
            RemoveComponent<SlimeEatTrigger>(bait, __instance);
            RemoveComponent<SlimeSubbehaviourPlexer>(bait, __instance);
            RemoveComponents<SlimeSubbehaviour>(bait, __instance);
            Animator animator = bait.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.SetBool(Grounded, true);
            }
        }
    }

    [HarmonyPatch(nameof(OnTriggerEnter)), HarmonyPrefix]
    public static bool OnTriggerEnter(GordoSnare __instance, Collider col)
    {
        Identifiable component = col.GetComponent<Identifiable>();
        if (!col.isTrigger && __instance.Bait == null && !__instance.HasSnaredGordo())
        {
            if (component == null)
            {
                return true;
            }
            if (component.identType.TryCast<SlimeDefinition>())
            {
                return AttachBait(col, __instance);
                
            }
            if (EntryPoint.CustomResources.Contains(component.identType))
            {
                return AttachBait(col, __instance);
            }
        }
        return true;
    }
    private static bool AttachBait(Collider col, GordoSnare gordoSnare)
    {
        Identifiable component = col.GetComponent<Identifiable>();
        bool flag = gordoSnare.BaitAttachedFx != null;
        if (flag)
        {
            SRBehaviour.SpawnAndPlayFX(gordoSnare.BaitAttachedFx, gordoSnare.gameObject);
        }
        Destroyer.DestroyActor(col.gameObject, "GordoSnare.OnTriggerEnter", false);
        gordoSnare.AttachBait(component.identType);
        return false;
    }
    
    private static readonly int Grounded = Animator.StringToHash("grounded");
    
}