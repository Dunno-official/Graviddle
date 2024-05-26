using SceneTransitions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Utils;

namespace Level.UI.Buttons
{
    public class SceneTransitButton : ButtonClick
    {
        [SerializeField] private int _sceneIndex;
        [SerializeField] private AssetReference _transitReference;

        protected override async void OnButtonClick()
        {
            SceneTransit sceneTransit = await LocalAssetLoader.Load<SceneTransit>(_transitReference);
        
            await sceneTransit.MakeTransition(_sceneIndex);
        
            LocalAssetLoader.Unload(sceneTransit.gameObject);
        }
    }
}
