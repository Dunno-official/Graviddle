using System;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.CharacterStateMachineNM.Conditions;
using Level.CharacterNM.CharacterStateMachineNM.StateTransitions;
using Level.Portals;
using Level.UserInterface.Buttons;
using UnityEngine;
using LevelBorders = Level.CameraNM.Clamping.Data.LevelBorders;

namespace Level.CharacterNM.CharacterStateMachineNM
{
    [Serializable]
    public class TransitionsConditionsFactory
    {
        [SerializeField] private CharacterCollisions _characterCollisions;
        [SerializeField] private RestartButton _restartButton;

        public TransitionsConditions Create(Character character, LevelBorders borders, CharacterInput input, ICondition restartEvent)
        {
            CollisionCondition<Ground> isGroundedCondition = new(_characterCollisions.Feet);
            IsRunning isRunningCondition = new(input);
            
            return new TransitionsConditions
            {
                Win = new CollisionCondition<FinishPortal>(_characterCollisions.All),
                IsNotRunning = new Not(isRunningCondition),
                IsFalling = new Not(isGroundedCondition),
                IsGrounded = isGroundedCondition,
                IsRunning = isRunningCondition,
                Resurrected = restartEvent,
                Death = new CharacterDeathConditions(new IDeathCondition[]
                {
                    _restartButton,
                    character.GetComponent<CharacterLaserDeath>(),
                    new CharacterObstacleDeath(_characterCollisions.All),
                    new DeathFromLevelBorders(borders, character.transform),
                }),
            };
        }
    }
}