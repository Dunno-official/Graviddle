﻿using System;
using Cysharp.Threading.Tasks;
using Extensions;
using Level.CharacterNM.CharacterStateMachineNM.States;
using MonoBehaviourWrapperNM;
using SceneTransitions;
using Utils;

namespace Level.Restart
{
    public class LevelRestart : ISubscriber
    {
        private readonly RestartableComponents _restartableComponents = new();
        private readonly Action _restartEvent;
        private readonly DieState _dieState;
        private const float _restartTime = 0.7f;

        public LevelRestart(Action restartEvent, DieState dieState)
        {
            _restartEvent = restartEvent;
            _dieState = dieState;
        }

        void ISubscriber.Subscribe()
        {
            _dieState.Entered += MakeRestart;
        }

        void ISubscriber.Unsubscribe()
        {
            _dieState.Entered -= MakeRestart;
        }

        private async void MakeRestart()
        {
            LoadingScreen deathScreen = await LocalAssetLoader.Load<LoadingScreen>("LevelRestart");
            Backstage backstage = new(deathScreen, RestartObjects);

            await backstage.MakeTransition();

            _restartableComponents.AfterRestartComponents.RestartForEach();
        
            LocalAssetLoader.Unload(deathScreen.gameObject);
        }

        private async UniTask RestartObjects()
        {
            _restartableComponents.RestartComponents.RestartForEach();
            _restartEvent();

            await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
        }
    }
}