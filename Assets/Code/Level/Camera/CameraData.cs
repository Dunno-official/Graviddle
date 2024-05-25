﻿using System;
using Level.Camera;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CameraData
{
    [SerializeField] private Button _zoomInButton;
    [SerializeField] private Button _zoomOutButton;
    [SerializeField] private CameraRotationData _rotationData;
    
    public LevelBorders Borders { get; private set; }
    public SwipeHandler SwipeHandler { get; private set; }
    public IGravityState CharacterGravityState { get; private set; }
    public Character Character { get; private set; }
    public Button ZoomInButton => _zoomInButton;
    public Button ZoomOutButton => _zoomOutButton;
    public CameraRotationData RotationData => _rotationData;

    public void Initialize(SwipeHandler swipeHandler, LevelBorders levelBorders, IGravityState characterState, Character character)
    {
        CharacterGravityState = characterState;
        SwipeHandler = swipeHandler;
        Borders = levelBorders;
        Character = character;
    }
}