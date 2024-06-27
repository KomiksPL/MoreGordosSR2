using UnityEngine;

namespace MoreGordosMod;

public static class TextureUtils
{
    public static Texture2D LoadImage(string name)
    {
        string text = "MoreGordosMod.Images." + name + ".png";
        Stream manifestResourceStream = EntryPoint.ExecAssembly.GetManifestResourceStream(text);
        if (manifestResourceStream == null)
            return null;

        byte[] array = new byte[manifestResourceStream.Length];
        _ = manifestResourceStream.Read(array, 0, array.Length);
        Texture2D texture2D2 = new Texture2D(1, 1);
        ImageConversion.LoadImage(texture2D2, array);
        texture2D2.name = name;
        return texture2D2;
    }
}