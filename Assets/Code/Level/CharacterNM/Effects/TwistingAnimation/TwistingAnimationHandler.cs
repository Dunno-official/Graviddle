using DG.Tweening;
using Level.CharacterNM.CharacterStateMachine.States;
using Level.Restart;
using MonoBehaviourWrapper;
using UnityEngine;

namespace Level.CharacterNM.Effects.TwistingAnimation
{
    public class TwistingAnimationHandler : ISubscriber, IInitializable, IRestart
    {
        private readonly TwistingAnimation _portalAnimation;
        private readonly TweenCallback _onRespawn;
        private readonly WinState _winState;

        public TwistingAnimationHandler(SpriteRenderer spriteRenderer, WinState winState, TwistingAnimationData data, TweenCallback onRespawn)
        {
            _portalAnimation = new TwistingAnimation(spriteRenderer, data);
            _onRespawn = onRespawn;
            _winState = winState;
        }
    
        void IInitializable.Initialize()
        {
            Restart();
        }

        public void Fade()
        {
            _portalAnimation.FadeOut();
        }
    
        void ISubscriber.Subscribe()
        {
            _winState.Entered += _portalAnimation.FadeOut;
        }

        void ISubscriber.Unsubscribe()
        {
            _winState.Entered -= _portalAnimation.FadeOut;
        }

        public void Restart()
        {
            _portalAnimation.FadeIn().OnComplete(_onRespawn);
        }
    }
}