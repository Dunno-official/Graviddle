﻿using System;
using System.Collections;
using Level.LightBulb;
using UnityEngine;
using Utils;

namespace Level.Obstacles.Laser
{
    public class LaserSwitcher : MonoBehaviour, ISwitcher
    {
        [SerializeField] private LaserParticlesSwitcher _laserParticlesSwitcher;
        [SerializeField] private LaserLineSwitcher _laserLineSwitcher;
        private InvocationWithDelay _particlesTogglingWithDelay;
        private InvocationWithDelay _laserTogglingEventWithDelay;
    
        public event Action<bool> Toggled;

        public void Initialize(bool startOnAwake)
        {
            _laserTogglingEventWithDelay = new InvocationWithDelay(0.5f, 2f, activate => Toggled?.Invoke(activate));
            _particlesTogglingWithDelay = new InvocationWithDelay(0.7f, 1f, _laserParticlesSwitcher.ToggleParticles);

            _laserLineSwitcher.Initialize();
            Restart(startOnAwake);
        }

        public IEnumerator ToggleLaser(bool activateLaser)
        {
            StartCoroutine(_laserTogglingEventWithDelay.Invoke(activateLaser));
            StartCoroutine(_particlesTogglingWithDelay.Invoke(activateLaser));
            yield return StartCoroutine(_laserLineSwitcher.ToggleLaserLine(activateLaser));
        }

        public void Restart(bool startOnAwake)
        {
            StopAllCoroutines();
            Toggled?.Invoke(startOnAwake);
            _laserLineSwitcher.Restart(startOnAwake);
            _laserParticlesSwitcher.ToggleParticles(startOnAwake);
        }

        public void StopAnimation()
        {
            StopAllCoroutines();
            _laserLineSwitcher.StopAnimation();
        }
    }
}