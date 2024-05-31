using Level.CharacterNM.CharacterStateMachineNM.StateTransitions;
using MonoBehaviourWrapperNM;

namespace Level.CharacterNM.CharacterStateMachineNM
{
    public class CharacterStateMachine : IUpdate, IGizmo
    {
        private readonly TransitionsPresenter _transitionsPresenter;
        private CharacterState _state;

        public CharacterStateMachine(TransitionsPresenter transitionsPresenter, CharacterState initialState)
        {
            _transitionsPresenter = transitionsPresenter;
            _state = initialState;
        }

        void IUpdate.Update()
        {
            _state.Update();
            TryTransit();
        }

        private void TryTransit()
        {
            CharacterState newState = _transitionsPresenter.Transit(_state);
        
            if (newState != _state)
            {
                SwitchState(newState);
            }
        }

        private void SwitchState(CharacterState newState)
        {
            _state?.Exit();
            _state = newState;
            _state.Enter();
        }

        public void DrawGizmo()
        {
            _state.DrawGizmo();
        }
    }
}