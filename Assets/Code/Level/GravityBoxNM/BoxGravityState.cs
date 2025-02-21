﻿using System;
using Level.CharacterNM.Helpers;
using Level.Gravitation;
using Level.Gravitation.SwipeHandlerNM;
using UnityEngine;

namespace Level.GravityBoxNM
{
    public class BoxGravityState : IGravityState
    {
        private readonly OrientationHandler _orientation = new(0.75f);
        private readonly GravityDirection _initialDirection;
        private readonly Transform _transform;
        private readonly Camera _camera;

        public BoxGravityState(Transform transform, GravityDirection gravityDirection)
        {
            _initialDirection = gravityDirection;
            Direction = gravityDirection;
            _transform = transform;
            _camera = Camera.main;
        }

        public event Action DirectionChanged;
        public bool IsDirectionChanged { get; private set; }
        public GravityDirection Direction { get; private set; }
        public GravityDirection TargetGlobalDirection => _orientation.LocalDirection;

        public void UpdateDirection()
        {
            Direction = _orientation.LocalDirection;
            DirectionChanged?.Invoke();
        }

        public void Update()
        {
            Vector2 delta = GetDelta();
            _orientation.TryChangeDirection(delta);
            IsDirectionChanged = delta.magnitude > _orientation.Sensitivity;
        }

        private Vector2 GetDelta()
        {
            Vector2 worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            return worldPoint - (Vector2)_transform.position;
        }

        public void Reset()
        {
            Direction = _initialDirection;        
        }
    }
}