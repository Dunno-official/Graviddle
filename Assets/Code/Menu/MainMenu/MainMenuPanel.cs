﻿using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : AnimatedPanel
{
    [SerializeField] private VerticalLayoutGroup _group;
    
    public override async UniTask Initialize()
    {
        Enable();
        await UniTask.Yield();
        LayoutRebuilder.ForceRebuildLayoutImmediate(_group.transform as RectTransform);

        await base.Initialize();
    }
}