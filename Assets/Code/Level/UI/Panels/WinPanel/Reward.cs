using System.Collections.Generic;
using Extensions;
using Level.Restart;
using UnityEngine;

namespace Level.UI.Panels.WinPanel
{
    public class Reward : MonoBehaviour, IRestart
    {
        private IReadOnlyCollection<LevelStar.LevelStar> _levelStars;
        private const int _maxStars = 3;

        public int CollectedStars { get; private set; }
        public bool IsMaxStars => CollectedStars == _maxStars;

        public void Initialize(IReadOnlyCollection<LevelStar.LevelStar> levelStars)
        {
            _levelStars = levelStars;
        }
    
        private void OnEnable()
        {
            _levelStars.ForEach(levelStar => levelStar.StarCollected += OnStarCollected);
        }

        private void OnDisable()
        {
            _levelStars.ForEach(levelStar => levelStar.StarCollected -= OnStarCollected);
        }

        private void OnStarCollected()
        {
            ++CollectedStars;
        }
    
        void IRestart.Restart()
        {
            CollectedStars = 0;
        }
    }
}
