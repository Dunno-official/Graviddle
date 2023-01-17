﻿using UnityEngine;

public class CameraMediator : MonoBehaviour
{
    [SerializeField] private LevelBorders _levelBorders;
    [SerializeField] private CameraZoom _cameraZoom;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CameraBordersWithOrientation _bordersWithOrientation;
    [SerializeField] private LevelZoomCalculator _levelZoomCalculator;
    [SerializeField] private CameraAnimation _cameraAnimation;
    
    public void Init()
    {
        var cameraClampingSettingsFactory = new CameraClampingSettingsFactory(_levelBorders, _mainCamera);
        
        CameraClampingSettings settings = cameraClampingSettingsFactory.Create();

        _cameraAnimation.Init();
        _bordersWithOrientation.Init(settings);
        _levelZoomCalculator.Init(_mainCamera, _levelBorders);
        _cameraZoom.Init(_mainCamera, _levelZoomCalculator);
    }
}