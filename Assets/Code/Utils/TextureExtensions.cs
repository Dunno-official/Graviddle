using UnityEngine;

namespace Utils
{
    public static class TextureExtensions
    {
        public static float Ratio(this Texture2D texture2D)
        {
            return (float)texture2D.width / texture2D.height;
        }
        
        public static byte[] SaveAsPng(this RenderTexture rt)
        {
            if (rt == null || !rt.IsCreated()) return null;

            // Allocate
            var sRgbRenderTex = RenderTexture.GetTemporary(rt.width, rt.height, 0, RenderTextureFormat.ARGB32,
                RenderTextureReadWrite.sRGB);
            var tex = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, mipChain: false, linear: false);
            
            // Linear to Gamma Conversion
            Graphics.Blit(rt, sRgbRenderTex);
        
            // Copy memory from RenderTexture
            var tmp = RenderTexture.active;
            RenderTexture.active = sRgbRenderTex;
            tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            tex.Apply();
            RenderTexture.active = tmp;
        
            // Get PNG bytes
            var bytes = tex.EncodeToPNG();
            
            // Destroy
            Object.Destroy(tex);
            RenderTexture.ReleaseTemporary(sRgbRenderTex);

            return bytes;
        }
    }
}