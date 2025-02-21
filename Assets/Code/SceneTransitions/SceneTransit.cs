﻿using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneTransitions
{
    public class SceneTransit : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public async UniTask MakeTransition(int scene)
        {
            Backstage backstage = new(_loadingScreen, ()=> LoadScene(scene));
        
            await backstage.MakeTransition();
        }

        private async UniTask LoadScene(int scene)
        {
            await SceneManager.LoadSceneAsync(scene).ToUniTask();
        }
    }
}