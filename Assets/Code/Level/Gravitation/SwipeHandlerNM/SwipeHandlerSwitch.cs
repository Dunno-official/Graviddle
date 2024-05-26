using Level.CharacterNM;
using Level.CharacterNM.CharacterStateMachine.States;
using Level.CharacterNM.CharacterStateMachine.StateTransitions;

namespace Level.Gravitation.SwipeHandlerNM
{
    public class SwipeHandlerSwitch : CharacterFallingEventsHandler
    {
        private readonly SwipeHandler _swipeHandler;
    
        public SwipeHandlerSwitch(SwipeHandler swipeHandler, Transition fallToIdleTransition, FallState fallState) 
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