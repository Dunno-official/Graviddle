﻿using System;
using Level.CameraNM.Clamping.Data;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.Obstacles;
using Level.Portals;
using Level.UserInterface.Buttons;
using UnityEngine;
using Utils.Physics;

namespace Level.CharacterNM.CharacterStateMachineNM.StateTransitions
{
    [Serializable]
    public class TransitionsConditions
    {
        [SerializeField] private RestartButton _restartButton;
        [SerializeField] private CollisionsList _allCollisions;
        [SerializeField] private CollisionsList _characterFeet;
        private CharacterLaserDeath _laserDeath;
        private Func<bool> _restartCondition;
        private LevelBorders _levelBorders;
        private Character _character;
        private CharacterInput _input;

        public void Initialize(CharacterInput input, Character character, LevelBorders borders, Func<bool> restartCondition)
        {
            _laserDeath = character.GetComponent<CharacterLaserDeath>();
            _restartCondition = restartCondition;
            _levelBorders = borders;
            _character = character;
            _input = input;
        }
    
        public bool CheckDeathByLevelBorders() => _levelBorders.CheckIfPositionNotWithinTheLevel(_character.transform.position);

        public bool CheckDeathFromObstacle() => _allCollisions.CheckCollision<Obstacle>() || _laserDeath.GetState();

        public bool CheckIfGrounded() => _characterFeet.CheckCollision<Ground>();
    
        public bool CheckWin() => _allCollisions.CheckCollision<FinishPortal>();

        public bool CheckIfResurrected() => _restartCondition();
    
        public bool CheckIfRun() => _input.GetDirection() != Vector2.zero;

        public bool CheckIfRestart() => _restartButton.CheckIfPressed();

        public bool CheckIfFall() => CheckIfGrounded() == false;

        public bool CheckIfNotRun() => CheckIfRun() == false;
    }
}