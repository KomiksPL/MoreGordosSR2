using System.Reflection;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.Damage;
using Il2CppMonomiPark.SlimeRancher.Script.Util;
using MelonLoader;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using Object = UnityEngine.Object;

[assembly: MelonInfo(typeof(MoreGordosMod.EntryPoint), "MoreGordos", "1.0.4", "KomiksPL", "https://www.nexusmods.com/slimerancher2/mods/4")]
namespace MoreGordosMod;
public class EntryPoint : MelonMod
{
	public static List<IdentifiableType> CustomResources = new List<IdentifiableType>();
	public static IdentifiableType LuckyGordo;
	public static IdentifiableType FireGordo;
	public static IdentifiableType YolkyGordo;
	public static IdentifiableType TarrGordo;
	public static IdentifiableType PuddleGordo;
	public static SlimeDefinition FireDef;
	public static SlimeDefinition YolkyDef;
	public static SlimeDefinition PinkDef;



	
	public static Assembly execAssembly = Assembly.GetExecutingAssembly();


    public override void OnInitializeMelon()
    {
        SystemContext.IsModded = true;
        LuckyGordo = CreateIdentifiableGordo("LuckyGordo", Color.white, null);
        FireGordo = CreateIdentifiableGordo("FireGordo", Color.white, null);
        YolkyGordo = CreateIdentifiableGordo("YolkyGordo", Color.white, null);
        TarrGordo = CreateIdentifiableGordo("TarrGordo", Color.white, null);
        PuddleGordo = CreateIdentifiableGordo("PuddleGordo", Color.white, null);


    }
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        
	    if (!sceneName.Equals("GameCore") || activated)
		    return;
	    activated = true;
	    EntryPoint.CustomResources.Add(SRLookup.Get<IdentifiableType>("StrangeDiamondCraft"));
	    EntryPoint.CustomResources.Add(SRLookup.Get<IdentifiableType>("DeepBrineCraft"));
	    EntryPoint.CustomResources.Add(SRLookup.Get<IdentifiableType>("LavaDustCraft"));
	    EntryPoint.CustomResources.Add(SRLookup.Get<IdentifiableType>("SunSapCraft"));
	    StringTable stringTable = SRSingleton<SystemContext>.Instance.LocalizationDirector.Tables["UI"];
	    SRLookup.Get<IdentifiableTypeGroup>("EdibleSlimeGroup").localizedName = new LocalizedString(stringTable.SharedData.TableCollectionNameGuid, stringTable.GetEntry("m.foodgroup.tarr").SharedEntry.Id);
	    IdentifiableType pinkGordo = SRLookup.Get<IdentifiableType>("PinkGordo");
	    
	    SlimeDefinition luckyDef = SRLookup.Get<SlimeDefinition>("Lucky");
	    SlimeDefinition puddleDef = SRLookup.Get<SlimeDefinition>("Puddle");
	    
	    SlimeDefinition tarrDef = SRLookup.Get<SlimeDefinition>("Tarr");
	    FireDef = SRLookup.Get<SlimeDefinition>("Fire"); 
	    YolkyDef = SRLookup.Get<SlimeDefinition>("Yolky");
	    PinkDef = SRLookup.Get<SlimeDefinition>("Yolky");



	    var slimeFire = SRLookup.Get<GameObject>("slimeFire");
	    LookupDirector lookupDirector = SRSingleton<GameContext>.Instance.LookupDirector;
	    GameObject gordoLucky = SRLookup.CopyPrefab(SRLookup.Get<GameObject>("gordoTangle"));
	    gordoLucky.name = "gordoLucky";
	    gordoLucky.transform.Find("Vibrating/slime_gordo").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = luckyDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
	    gordoLucky.GetComponent<GordoFaceComponents>().HappyMouth = SRLookup.Get<IdentifiableType>("TabbyGordo").prefab.GetComponent<GordoFaceComponents>().HappyMouth;

	    GameObject flowerObj = gordoLucky.transform.Find("Vibrating/bone_root/bone_slime/bone_core/bone_jiggle_top/bone_skin_top/Flower").gameObject;
	    flowerObj.SetActive(false);
	    Object.DestroyImmediate(flowerObj.GetComponent<BoxCollider>());
	    Object.DestroyImmediate(flowerObj.GetComponent<MeshCollider>());
	    
	    GameObject luckycat_coin = gordoLucky.transform.Find("Vibrating/bone_root/bone_slime/luckycat_coin_LOD1").gameObject;
	    luckycat_coin.GetComponent<MeshFilter>().sharedMesh = SRLookup.Get<Mesh>("luckycat_coin_LOD0");
	    luckycat_coin.GetComponent<MeshRenderer>().sharedMaterial = luckyDef.AppearancesDefault[0].Structures[2].DefaultMaterials[0];
	    luckycat_coin.transform.position = new Vector3(0f, 3.8f, 1f);
	    luckycat_coin.SetActive(true);
	    GameObject ears_n_tail_LOD0 = gordoLucky.transform.Find("Vibrating/ears_n_tail_LOD0").gameObject;
	    ears_n_tail_LOD0.GetComponent<SkinnedMeshRenderer>().sharedMaterial = luckyDef.AppearancesDefault[0].Structures[1].DefaultMaterials[0];
	    ears_n_tail_LOD0.SetActive(true);
	    LuckyGordo.prefab = gordoLucky;
	    LuckyGordo.prefab.GetComponent<GordoEat>().SlimeDefinition = luckyDef;
	    LuckyGordo.groupType = luckyDef.groupType;
	    LuckyGordo.localizedName = LocalizationUtil.CreateByKey("Pedia", "t.lucky_gordo");
	    LuckyGordo.prefab.GetComponent<GordoIdentifiable>().identType = LuckyGordo;
	    LuckyGordo.prefab.hideFlags |= HideFlags.HideAndDontSave;
	    //lookupDirector.gordoDict.Add(LuckyGordo, LuckyGordo.prefab);
	    //lookupDirector.gordoEntries.items.Add(LuckyGordo.prefab);
	    
	    var gordoPuddle = SRLookup.CopyPrefab(pinkGordo.prefab);
	    gordoPuddle.name = "gordoPuddle";
	    gordoPuddle.transform.Find("Vibrating/slime_gordo").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = puddleDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
	    gordoPuddle.GetComponent<GordoFaceComponents>().SetGordoFaceComponents(puddleDef);

	    
	    PuddleGordo.prefab = gordoPuddle;
	    PuddleGordo.prefab.GetComponent<GordoEat>().SlimeDefinition = puddleDef;
	    PuddleGordo.localizedName = LocalizationUtil.CreateByKey("Pedia", "t.puddle_gordo", false);
	    PuddleGordo.prefab.GetComponent<GordoIdentifiable>().identType = PuddleGordo;
	    PuddleGordo.prefab.hideFlags |= HideFlags.HideAndDontSave;

	    lookupDirector.gordoDict.Add(PuddleGordo, gordoPuddle);
	    lookupDirector.gordoEntries.items.Add(gordoPuddle);
	    
	    
	    var gordoFire = SRLookup.CopyPrefab(pinkGordo.prefab);
	    gordoFire.name = "gordoFire";
	    gordoFire.transform.Find("Vibrating/slime_gordo").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = FireDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
	    gordoFire.GetComponent<GordoFaceComponents>().SetGordoFaceComponents(FireDef);
	    FireGordo.prefab = gordoFire;
	    var slimePink = SRLookup.Get<SlimeDefinition>("Pink");
	    FireGordo.prefab.GetComponent<GordoEat>().SlimeDefinition = slimePink;
	    FireGordo.localizedName = LocalizationUtil.CreateByKey("Pedia", "t.fire_gordo", false);
	    FireGordo.prefab.GetComponent<GordoIdentifiable>().identType = FireGordo;
	    FireGordo.prefab.hideFlags |= HideFlags.HideAndDontSave;

	    
	    
	    lookupDirector.gordoDict.Add(FireGordo, gordoFire);
	    lookupDirector.gordoEntries.items.Add(gordoFire);


	    var gordoTarr = SRLookup.CopyPrefab(pinkGordo.prefab);
	    gordoTarr.name = "gordoTarr";
	    gordoTarr.AddComponent<DamagePlayerOnTouch>().DamageSource = SRLookup.Get<DamageSourceDefinition>("DamagePlayerOnTouch");
	    gordoTarr.GetComponent<GordoEat>().SlimeDefinition = tarrDef;
	    gordoTarr.transform.Find("Vibrating/slime_gordo").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = tarrDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
	    SlimeEyeComponents component3 = tarrDef.prefab.GetComponent<SlimeEyeComponents>();
	    SlimeMouthComponents component4 = tarrDef.prefab.GetComponent<SlimeMouthComponents>();
	    Material material = Object.Instantiate(component3.ChompClosedEyes);
	    Material material2 = Object.Instantiate(component4.ChompClosedMouth);
	    material.SetTexture("_FaceTexture", TextureUtils.LoadImage("eyeTarrmellow"));
	    material2.SetTexture("_FaceTexture", TextureUtils.LoadImage("mouthTarrmellow"));
	    var gordoFaceComponents = gordoTarr.GetComponent<GordoFaceComponents>();
	    gordoFaceComponents.BlinkEyes = component3.ChompClosedEyes;
	    gordoFaceComponents.StrainEyes = material;
	    gordoFaceComponents.ChompOpenMouth = component4.ChompClosedMouth;
	    gordoFaceComponents.HappyMouth = component4.ChompClosedMouth;
	    gordoFaceComponents.StrainMouth = material2;
	    
	    TarrGordo.prefab = gordoTarr;
	    TarrGordo.localizedName = LocalizationUtil.CreateByKey("Pedia", "t.tarr_gordo", false);
	    TarrGordo.prefab.GetComponent<GordoIdentifiable>().identType = TarrGordo;
	    TarrGordo.prefab.hideFlags |= HideFlags.HideAndDontSave;

	    lookupDirector.gordoDict.Add(TarrGordo, gordoTarr);
	    lookupDirector.gordoEntries.items.Add(gordoTarr);
	    
	    
	    var gordoYolky = SRLookup.CopyPrefab(pinkGordo.prefab);
	    gordoYolky.name = "gordoYolky";
	    gordoYolky.transform.Find("Vibrating/slime_gordo").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = YolkyDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
		gordoYolky.GetComponent<GordoFaceComponents>().SetGordoFaceComponents(YolkyDef);

	    YolkyGordo.prefab = gordoYolky;
	    YolkyGordo.prefab.GetComponent<GordoEat>().SlimeDefinition = YolkyDef;
	    YolkyGordo.localizedName = LocalizationUtil.CreateByKey("Pedia", "t.yolky_gordo", false);
	    YolkyGordo.prefab.GetComponent<GordoIdentifiable>().identType = YolkyGordo;
	    YolkyGordo.prefab.hideFlags |= HideFlags.HideAndDontSave;

	    SlimeDefinition tabbyDef = SRLookup.Get<SlimeDefinition>("Tabby");
	    YolkyGordo.groupType = tabbyDef.groupType;
	    YolkyGordo.prefab.GetComponent<GordoEat>().SlimeDefinition = tabbyDef;
	    lookupDirector.gordoDict.Add(YolkyGordo, gordoYolky);
	    lookupDirector.gordoEntries.items.Add(gordoYolky);
        
    }

    public static IdentifiableType CreateIdentifiableGordo(string gordoName, Color color, Sprite icon)
    {
        IdentifiableType identifiableType = ScriptableObject.CreateInstance<IdentifiableType>();
        identifiableType.name = gordoName;
        identifiableType.color = color;
        identifiableType.icon = icon;
        identifiableType.hideFlags |= HideFlags.HideAndDontSave;
        return identifiableType;
    }

   

    private static bool activated = false;

}