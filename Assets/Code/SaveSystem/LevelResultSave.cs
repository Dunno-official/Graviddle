using DefaultNamespace;
using Level.CharacterNM.CharacterStateMachine.States;
using Level.UserInterface.Panels.WinPanel;
using MonoBehaviourWrapperNM;

namespace SaveSystem
{
    public class LevelResultSave : ISubscriber, IInitializable
    {
        private readonly PlayerProgress _playerProgress = new();
        private readonly WinState _characterWinState;
        private readonly Reward _reward;

        public LevelResultSave(WinState characterWinState, Reward reward)
        {
            _characterWinState = characterWinState;
            _reward = reward;
        }

        public void Initialize()
        {
            _playerProgress.Initialize();
        }

        public void Subscribe()
        {
            _characterWinState.Entered += SaveLevelResult;
        }

        public void Unsubscribe()
        {
            _characterWinState.Entered -= SaveLevelResult;
        }

        private void SaveLevelResult()
        {
            _playerProgress.SetStarsForCurrentScene(_reward.CollectedStars);
        }
    }
}
