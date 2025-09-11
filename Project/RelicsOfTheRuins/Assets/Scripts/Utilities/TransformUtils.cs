using UnityEngine;

namespace RelicsOfTheRuins.Utilities
{
    public static class TransformUtils
    {
        public static void CalculateStretchTo(int value, float maxValue, out float outLengthResult, ref float refPosResult, in float inMinLength, in float inMaxLength, float originalLength,bool flipDirection)
        {
            outLengthResult = Mathf.Lerp(inMinLength, inMaxLength, value / maxValue);
            refPosResult += (outLengthResult - originalLength)/2 * (flipDirection ? -1 : 1);
        }
    }
}