﻿
using Level.Character.CharacterStateMachine;
using Level.UI.Panels.GameplayPanel;
using Level.UI.Panels.WinPanel;
using MonoBehaviourWrapper;

namespace Level.UI
{
    public class UIHandler : ISubscriber
    {
        private readonly CharacterStatesPresenter _states;
        private readonly Character.Character _character;
        private readonly UI _ui;

        public UIHandler(CharacterStatesPresenter states, Character.Character character, UI ui)
        {
            _character = character;
            _states = states;
            _ui = ui;
        }

        void ISubscriber.Subscribe()
        {
            _states.DieState.Entered += OnDied;
            _states.WinState.Entered += OnWon;
            _character.Respawned += OnRespawned;
        }

        void ISubscriber.Unsubscribe()
        {
            _states.DieState.Entered -= OnDied;
            _states.WinState.Entered -= OnWon;
            _character.Respawned -= OnRespawned;
        }

        private async void OnRespawned()
        {
            await _ui.Show<GameplayPanel>();
        }

        private async void OnWon()
        {
            await _ui.Show<WinPanel>();
        }

        private void OnDied()
        {
            _ui.DisableAll();
        }
    }
}