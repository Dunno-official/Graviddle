using UnityEngine.EventSystems;

namespace Level.UserInterface.Panels.GameplayPanel.MovementButtons
{
    public class InputButton : UIElement, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsTouching { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsTouching = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnDisable();
        }
    
        private void OnDisable()
        {
            IsTouching = false;
        }
    }
}