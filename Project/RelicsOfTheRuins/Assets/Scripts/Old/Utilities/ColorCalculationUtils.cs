using UnityEngine;

namespace RelicsOfTheRuins.Utilities
{
    public static class ColorCalculationUtils
    {
        public static void CalculateVitalityColor(ref Color refColor, int vitalPoint, float maxVitalPointHalf)
        {
            if (vitalPoint >= maxVitalPointHalf)
            {
                refColor.r = Mathf.Lerp(1, 0, (vitalPoint - maxVitalPointHalf) / maxVitalPointHalf);
            }

            if (vitalPoint <= maxVitalPointHalf)
            {
                refColor.g = Mathf.Lerp(0, 1, vitalPoint / maxVitalPointHalf);
            }
        }
    }
}