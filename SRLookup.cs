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
        Object.DontDestroyOnLoad(RuntimePrefab);

        RuntimePrefab.SetActive(false);
    }
    public static T Get<T>(string name) where T : UnityEngine.Object
    {
        return Resources.FindObjectsOfTypeAll<T>().First(x => x.name == name);
    }

    public static GameObject CopyPrefab(GameObject obj)
    {
        GameObject gameObject = Object.Instantiate<GameObject>(obj, RuntimePrefab.transform);
        return gameObject;
    }
}