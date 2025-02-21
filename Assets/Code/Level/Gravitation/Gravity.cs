﻿using Level.CharacterNM.Helpers;
using Level.Restart;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation
{
    public class Gravity : IRestart, IInitializable
    {
        private readonly GravityDirection _initialDirection;
        private readonly ConstantForce2D _constantForce2d;
        private readonly float _strength;

        public Gravity(ConstantForce2D constantForce2d, float strength, GravityDirection initialDirection)
        {
            _initialDirection = initialDirection;
            _constantForce2d = constantForce2d;
            _strength = strength;
        }

        void IInitializable.Initialize()
        {
            Restart();
        }

        public void SetDirection(GravityDirection direction)
        {
            Vector2 directionVector = GravityDataPresenter.GravityData[direction].GravityVector;
            _constantForce2d.force = directionVector.normalized * _strength;
        }

        public void Restart()
        {
            SetDirection(_initialDirection);
        }
    }
}