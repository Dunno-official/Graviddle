﻿

using UnityEngine;

public class IdleState : CharacterState
{
    private readonly CharacterMovement _characterMovement;


    public IdleState(Character character) : base(character)
    {
        _characterMovement = character.GetComponent<CharacterMovement>();
    }


    public override void EnterState()
    {
        _animator.Play("Idle");
    }


    public override CharacterState Update()
    {
        if (_characterMovement.MoveDirection != Vector2.zero)
        {
            return CharacterStates.RunningState;
        }

        return this;
    }
}