using DG.Tweening;
using Level.CharacterNM.CharacterStateMachine.States;
using Level.Gravitation;
using MonoBehaviourWrapperNM;
using UnityEngine;
using Utils.Physics;

namespace Level.Portals
{
    public class CharacterToPortalPulling : ISubscriber
    {
        private readonly float _animationDuration = 1.25f;
        private readonly GravityRotation _gravityRotation;
        private readonly CollisionsList _collisions;
        private readonly Transform _character;
        private readonly WinState _winState;

        public CharacterToPortalPulling(WinState winState, Transform character, CollisionsList collisions, GravityRotation gravityRotation)
        {
            _gravityRotation = gravityRotation;
            _collisions = collisions;
            _character = character;
            _winState = winState;
        }

        public void Subscribe()
        {
            _winState.Entered += PullToPortal;
        }

        public void Unsubscribe()
        {
            _winState.Entered -= PullToPortal;
        }

        private void PullToPortal()
        {
            _gravityRotation.IsActive = false;

            FinishPortal finishPortal = _collisions.GetComponentFromList<FinishPortal>();
        
            _character.DOMove(finishPortal.PullingPoint.position, _animationDuration);
            _character.DORotate(finishPortal.PullingPoint.eulerAngles, _animationDuration);
        }
    }
}