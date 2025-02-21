using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Level.UserInterface.Panels.WinPanel
{
    [Serializable]
    public class WinEffects 
    {
        [SerializeField] private ParticleSystem[] _starsParticles;
        [SerializeField] private ParticleSystem _sunEffect;
        [SerializeField] private ParticleSystem _confetti;
        private float _starsCoolDown;
        private Reward _reward;

        public void Initialize(Reward reward)
        {
            _reward = reward;
            const float coolDown = 0.5f;
            _starsCoolDown = _starsParticles.First().main.duration + coolDown;
        }
    
        public async UniTask ActivateEffects()
        {
            int collectedStars = _reward.CollectedStars;
        
            for (int starIndex = 0; starIndex < collectedStars; ++starIndex)
            {
                await ActivateStar(starIndex);
            }

            if (_reward.IsMaxStars)
            {
                _confetti.gameObject.SetActive(true);
            }
        }

        private async UniTask ActivateStar(int starIndex)
        {
            _starsParticles[starIndex].gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(_starsCoolDown));
            _sunEffect.gameObject.SetActive(true);
        }
    }
}