using Cysharp.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Level.AnalyticsNM
{
    public class Screenshot
    {
        private readonly RenderTexture _texture;
        private readonly RenderTexture _source;

        public Screenshot(float scale)
        {
            _source = new RenderTexture(Screen.width, Screen.height, 0);
            _texture = new RenderTexture((int)(_source.width * scale), (int)(_source.height * scale), 0);
        }

        public async UniTask<NativeArray<byte>> MakeScreenshotPNG()
        {
            await UniTask.WaitForEndOfFrame();
            Graphics.Blit(Camera.main.activeTexture, _source);
            Graphics.Blit(_source, _texture);

            AsyncGPUReadbackRequest request = await AsyncGPUReadback.RequestAsync(_texture, 0, TextureFormat.RGBA32);

            return ImageConversion.EncodeNativeArrayToPNG(
                request.GetData<byte>(),
                _texture.graphicsFormat, 
                (uint)_texture.width,
                (uint)_texture.height);
        }
    }
}