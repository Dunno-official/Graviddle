﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;


public class LevelRestart : ISubscriber
{
    private readonly IEnumerable<IRestart> _restartComponents;
    private readonly IEnumerable<IAfterRestart> _afterRestartComponents;
    private readonly DieState _dieState;
    private const float _restartTime = 0.7f;


    public LevelRestart(IEnumerable<IRestart> restarts, IEnumerable<IAfterRestart> afterRestarts, DieState dieState)
    {
        _restartComponents = restarts;
        _afterRestartComponents = afterRestarts;
        _dieState = dieState;
    }


    void ISubscriber.Subscribe()
    {
        _dieState.CharacterDied += MakeRestart;
    }
    

    void ISubscriber.Unsubscribe()
    {
        _dieState.CharacterDied -= MakeRestart;
    }


    private async void MakeRestart()
    {
        var deathScreen = await LocalAssetLoader.Load<LoadingScreen>("LevelRestart");
        var backstage = new Backstage(deathScreen, RestartObjects);

        await backstage.MakeTransition();

        _afterRestartComponents.RestartForEach();
        
        LocalAssetLoader.Unload(deathScreen.gameObject);
    }


    private async UniTask RestartObjects()
    {
        _restartComponents.RestartForEach();

        await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
    }
}