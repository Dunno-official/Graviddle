using Level.CharacterNM;
using Level.CharacterNM.CharacterStateMachineNM.States;
using Level.UserInterface.Panels.WinPanel;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.AnalyticsNM
{
    public class Analytics : ISubscriber
    {
        private readonly DeathAnalytics _deathAnalytics;
        private readonly LevelAnalytics _levelAnalytics;
        private readonly WinState _winState;
        private readonly DieState _dieState;

        public Analytics(WinState winState, DieState dieState, Reward reward, CharacterDeathConditions conditions)
        {
            _deathAnalytics = new DeathAnalytics(conditions);
            _levelAnalytics = new LevelAnalytics(_deathAnalytics, reward, Time.time);
            _winState = winState;
            _dieState = dieState;
        }

        public void Subscribe()
        {
            _winState.Entered += _levelAnalytics.PostRecord;
            _dieState.Entered += _deathAnalytics.Update;
        }

        public void Unsubscribe()
        {
            _winState.Entered -= _levelAnalytics.PostRecord;
            _dieState.Entered -= _deathAnalytics.Update;
        }
    }
}