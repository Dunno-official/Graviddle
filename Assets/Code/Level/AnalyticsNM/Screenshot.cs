using Cysharp.Threading.Tasks;
using UnityEngine;
using Utils;

namespace Level.AnalyticsNM
{
    public class Screenshot 
    {
        private readonly Vector2Int _size;

        public Screenshot(Vector2Int size)
        {
            _size = size;
        }

        public async UniTask<byte[]> MakeScreenshot()
        {
            await UniTask.WaitForEndOfFrame();

            RenderTexture renderTexture = new(_size.x, _size.y, 1);
            ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);
            
            return renderTexture.SaveAsPng();
        }
    }
}