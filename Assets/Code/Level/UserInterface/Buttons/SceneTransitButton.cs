using SceneTransitions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Utils;

namespace Level.UserInterface.Buttons
{
    public class SceneTransitButton : ButtonClick
    {
        [SerializeField] private AssetReference _transitReference;
        [SerializeField] private int _sceneIndex;

        protected override async void OnButtonClick()
        {
            SceneTransit sceneTransit = await LocalAssetLoader.Load<SceneTransit>(_transitReference);
        
            await sceneTransit.MakeTransition(_sceneIndex);
        
            LocalAssetLoader.Unload(sceneTransit.gameObject);
        }

        public void SetTransitSceneIndex(int levelIndex)
        {
            _sceneIndex = levelIndex;
        }
    }
}
