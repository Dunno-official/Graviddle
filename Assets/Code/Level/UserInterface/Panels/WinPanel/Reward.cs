using System.Collections.Generic;
using Extensions;
using Level.LevelStarNM;
using Level.Restart;
using MonoBehaviourWrapperNM;

namespace Level.UserInterface.Panels.WinPanel
{
    public class Reward : ISubscriber, IRestart
    {
        private readonly IReadOnlyCollection<LevelStar> _levelStars;

        public Reward(IReadOnlyCollection<LevelStar> levelStars)
        {
            _levelStars = levelStars;
        }

        public int CollectedStars { get; private set; }
        public bool IsMaxStars => CollectedStars == _levelStars.Count;

        public void Subscribe()
        {
            _levelStars.ForEach(levelStar => levelStar.StarCollected += OnStarCollected);
        }

        public void Unsubscribe()
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
