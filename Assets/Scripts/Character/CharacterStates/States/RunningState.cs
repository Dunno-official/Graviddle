﻿using UnityEngine;


public class RunningState : CharacterState
{
    private readonly Transform _transform;
    private readonly CharacterMovement _characterMovement;
    private readonly float _movementSpeed = 3f;


    public RunningState(Character character) : base(character)
    {
        _characterMovement = character.GetComponent<CharacterMovement>();
        _transform = character.transform;
    }


    public override void EnterState()
    {
        _animator.Play("Run");
    }


    public override CharacterState Update()
    {   
        if (_characterMovement.MoveDirection == Vector2.zero)
        {
            return CharacterStates.IdleState;
        }

        var direction = (Vector2)_transform.position + _characterMovement.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);

        return this;
    }
}
