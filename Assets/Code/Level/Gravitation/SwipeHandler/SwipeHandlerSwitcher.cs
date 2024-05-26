
using Level.Character;
using Level.Character.CharacterStateMachine.States;
using Level.Character.CharacterStateMachine.StateTransitions;

namespace Level.Gravitation.SwipeHandler
{
    public class SwipeHandlerSwitcher : CharacterFallingEventsHandler
    {
        private readonly SwipeHandler _swipeHandler;
    
        public SwipeHandlerSwitcher(SwipeHandler swipeHandler, Transition fallToIdleTransition, FallState fallState) 
            : base(fallToIdleTransition, fallState)
        {
            _swipeHandler = swipeHandler;
        }

        protected override void OnStartFalling()
        {
            _swipeHandler.IsActive = false;
        }

        protected override void OnEndFalling()
        {
            _swipeHandler.IsActive = true;
        }
    }
}