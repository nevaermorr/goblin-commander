using UnityEngine;

public static class SpriteOrderingService
{
    public static float PixelCountToMaxShortModifier
    {
        get {
            if (pixelCountToMaxShortModifier == 0f)
            {
                CalculatePixelCountToMaxShortModifier();
            }
            return pixelCountToMaxShortModifier;
        }
    }
    private static float pixelCountToMaxShortModifier;
    private static void CalculatePixelCountToMaxShortModifier()
    {
        int pixelCount = Screen.width * Screen.height;
        if (pixelCount > short.MaxValue)
        {
            pixelCountToMaxShortModifier = short.MaxValue / (float)pixelCount; 
        }
        else {
            pixelCountToMaxShortModifier = 1;
        }
    }
}