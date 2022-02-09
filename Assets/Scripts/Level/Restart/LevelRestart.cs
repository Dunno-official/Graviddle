﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;


public class LevelRestart 
{
    private readonly IEnumerable<IRestart> _restartableComponents;
    private readonly IEnumerable<IAfterRestart> _afterRestartComponents;
    private const float _restartTime = 0.7f;


    public LevelRestart(IEnumerable<IRestart> restarts, IEnumerable<IAfterRestart> afterRestarts)
    {
        _restartableComponents = restarts;
        _afterRestartComponents = afterRestarts;
    }


    public async void MakeRestart()
    {
        var deathScreen = await LocalAssetLoader.Load<LoadingScreen>("LevelRestart");
        var backstage = new Backstage(deathScreen, RestartObjects);

        await backstage.MakeTransition();

        _afterRestartComponents.ForEach(component => component.Restart());
        
        LocalAssetLoader.Unload(deathScreen.gameObject);
    }


    private async UniTask RestartObjects()
    {
        _restartableComponents.ForEach(component => component.Restart());

        await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
    }
}