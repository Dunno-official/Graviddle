using UnityEngine;

namespace Utils
{
    public static class TextureExtensions
    {
        public static float Ratio(this Texture2D texture2D)
        {
            return (float)texture2D.width / texture2D.height;
        }
    }
}