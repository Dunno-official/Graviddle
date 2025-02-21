﻿using System.Collections.Generic;
using Extensions;
using Level.CameraNM.Clamping.Data;
using Level.Restart;
using UnityEngine;

namespace Level.Obstacles.ArrowTrap
{
    public class ArrowSpawner : MonoBehaviour, IRestart
    {
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private LevelBorders _levelBorders;
        private readonly Stack<Arrow> _arrowsPull = new();
        private readonly Queue<Arrow> _updatingArrows = new();

        public void SpawnArrow()
        {
            Arrow arrow = SpawnOrPopArrow();
            arrow.transform.SetPositionAndRotation(_spawnPoint);
            arrow.gameObject.SetActive(true);
            _updatingArrows.Enqueue(arrow);
        }

        private void Update()
        {
            if (_updatingArrows.IsEmpty() == false)
            {
                if (_levelBorders.CheckIfPositionNotWithinTheLevel(_updatingArrows.Peek().transform.position))
                {
                    _arrowsPull.Push(_updatingArrows.Dequeue());
                }
            }
        }

        private Arrow SpawnOrPopArrow()
        {
            return _arrowsPull.IsEmpty() ? Instantiate(_arrowPrefab) : _arrowsPull.Pop();
        }

        void IRestart.Restart()
        {
            _updatingArrows.ForEach(updatingArrow => updatingArrow.gameObject.SetActive(false));
        
            for (int i = 0; i < _updatingArrows.Count; ++i)
            {
                _arrowsPull.Push(_updatingArrows.Dequeue());
            }
        }
    }
}