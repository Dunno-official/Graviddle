using System;
using Level.CharacterNM.Helpers;
using Level.Restart;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Level.Gravitation.SwipeHandlerNM
{
    public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IRestart
    {
        private readonly OrientationHandler _router = new(sensitivity:5);
        public bool IsActive = true;

        public event Action<GravityDirection> GravityChanged;

        public void OnBeginDrag(PointerEventData eventData)
        {
            Vector2 swipeInput = new(eventData.delta.x, eventData.delta.y);

            if (IsActive && _router.TryChangeDirection(swipeInput))
            {
                GravityChanged?.Invoke(_router.GlobalDirection);
            }
        }

        void IRestart.Restart()
        {
            _router.Reset();
            GravityChanged?.Invoke(GravityDirection.Down);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }
    }
}