using Level.CharacterNM.CharacterStateMachine.States;
using Level.CharacterNM.CharacterStateMachine.StateTransitions;
using Level.Restart;
using MonoBehaviourWrapperNM;

namespace Level.CharacterNM
{
    public abstract class CharacterFallingEventsHandler : IRestart, ISubscriber
    {
        private readonly Transition _fallToIdleTransition;
        private readonly FallState _fallState;

        protected CharacterFallingEventsHandler(Transition fallToIdleTransition, FallState fallState)
        {
            _fallToIdleTransition = fallToIdleTransition;
            _fallState = fallState;
        }

        protected bool IsFalling { get; private set; }

        void ISubscriber.Subscribe()
        {
            _fallToIdleTransition.TransitionHappened += OnCharacterFell;
            _fallState.Entered += OnCharacterFalling;
        }

        void ISubscriber.Unsubscribe()
        {
            _fallToIdleTransition.TransitionHappened -= OnCharacterFell;
            _fallState.Entered -= OnCharacterFalling;
        }

        private void OnCharacterFalling()
        {
            IsFalling = true;
            OnStartFalling();
        }

        private void OnCharacterFell()
        {
            IsFalling = false;
            OnEndFalling();
        }

        protected virtual void OnStartFalling() {}
        protected virtual void OnEndFalling() {}

        void IRestart.Restart()
        {
            OnEndFalling();
        }
    }
}