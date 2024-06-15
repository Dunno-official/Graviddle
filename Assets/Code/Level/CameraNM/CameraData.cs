using System;
using Level.CameraNM.Clamping.Data;
using Level.CharacterNM;
using Level.Gravitation;
using UnityEngine;
using UnityEngine.UI;

namespace Level.CameraNM
{
    [Serializable]
    public class CameraData
    {
        [SerializeField] private Button _zoomInButton;
        [SerializeField] private Button _zoomOutButton;
        [SerializeField] private CurveAnimationData _rotationData;
    
        public LevelBorders Borders { get; private set; }
        public IGravityState CharacterGravityState { get; private set; }
        public Rigidbody2D Character { get; private set; }
        public Button ZoomInButton => _zoomInButton;
        public Button ZoomOutButton => _zoomOutButton;
        public CurveAnimationData RotationData => _rotationData;

        public void Initialize(LevelBorders levelBorders, IGravityState characterState, Character character)
        {
            Character = character.GetComponent<Rigidbody2D>();
            CharacterGravityState = characterState;
            Borders = levelBorders;
        }
    }
}