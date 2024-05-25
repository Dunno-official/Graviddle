﻿using System.Collections;
using UnityEngine;

namespace Obstacles.ArrowTrap
{
    public class ArrowTrap : ArrowTrapBase
    {
        [SerializeField] private ArrowSpawner _arrowSpawner;


        protected override IEnumerator OnShoot()
        {
            _arrowSpawner.SpawnArrow();

            yield return null;
        }
    }
}