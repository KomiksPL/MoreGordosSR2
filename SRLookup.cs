using UnityEngine;
using Object = UnityEngine.Object;

namespace MoreGordosMod;

public static class SRLookup
{
    public static GameObject RuntimePrefab;
    static SRLookup()
    {
        RuntimePrefab = new GameObject(nameof(RuntimePrefab));
        RuntimePrefab.hideFlags |= HideFlags.HideAndDontSave;
        RuntimePrefab.SetActive(false);
    }
    public static T Get<T>(string name) where T : UnityEngine.Object
    {
        return Resources.FindObjectsOfTypeAll<T>().First((T x) => x.name == name);
    }
    public static GameObject InstantiateInactive(GameObject obj)
    {
        GameObject gameObject = Object.Instantiate<GameObject>(obj, RuntimePrefab.transform);
        gameObject.SetActive(false);
        gameObject.transform.SetParent(null);
        gameObject.hideFlags = obj.hideFlags;
        return gameObject;
    }
    public static GameObject CopyPrefab(GameObject obj)
    {
        GameObject gameObject = Object.Instantiate<GameObject>(obj, RuntimePrefab.transform);
        return gameObject;
    }
}