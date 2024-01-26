using Il2Cpp;

namespace MoreGordosMod;

public static class Extensions
{
    public static void SetGordoFaceComponents(this GordoFaceComponents gordoFaceComponents, SlimeDefinition slimeDef)
    {
        gordoFaceComponents.BlinkEyes = slimeDef.AppearancesDefault[0].Face.GetExpressionFace(SlimeFace.SlimeExpression.BLINK).Eyes;
        gordoFaceComponents.StrainEyes = slimeDef.AppearancesDefault[0].Face.GetExpressionFace(SlimeFace.SlimeExpression.SCARED).Eyes;
        gordoFaceComponents.ChompOpenMouth = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
        gordoFaceComponents.HappyMouth = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
        gordoFaceComponents.StrainMouth = slimeDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
    }
}