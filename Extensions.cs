using Il2Cpp;
using MelonLoader;

namespace MoreGordosMod;

public static class Extensions
{
    public static void SetGordoFaceComponents(this GordoFaceComponents gordoFaceComponents, SlimeDefinition slimeDef)
    {
        gordoFaceComponents.blinkEyes = slimeDef.AppearancesDefault[0].Face.GetExpressionFace(SlimeFace.SlimeExpression.Blink).Eyes;
        gordoFaceComponents.strainEyes = slimeDef.AppearancesDefault[0].Face.GetExpressionFace(SlimeFace.SlimeExpression.Scared).Eyes;
        gordoFaceComponents.chompOpenMouth = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
        gordoFaceComponents.happyMouth = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
        gordoFaceComponents.strainMouth = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
    }
}