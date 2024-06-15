using Level.GravityBoxNM;
using MonoBehaviourWrapperNM;

namespace Level.UserInterface
{
    public class UIGravityBoxCover : ISubscriber
    {
        private readonly UIElement[] _elements;
        private readonly GravityBox[] _boxes;

        public UIGravityBoxCover(GravityBox[] boxes, params UIElement[] elements)
        {
            _elements = elements;
            _boxes = boxes;
        }

        public void Subscribe()
        {
            foreach (GravityBox gravityBox in _boxes)
            {
                gravityBox.PhysicsInputTrigger.Entered += HideButtons;
                gravityBox.PhysicsInputTrigger.Exited += ShowButtons;
            }
        }

        public void Unsubscribe()
        {
            foreach (GravityBox gravityBox in _boxes)
            {
                gravityBox.PhysicsInputTrigger.Entered -= HideButtons;
                gravityBox.PhysicsInputTrigger.Exited -= ShowButtons;
            }
        }

        private void ShowButtons()
        {
            foreach (UIElement element in _elements)
            {
                element.Enable();
            }
        }

        private void HideButtons()
        {
            foreach (UIElement element in _elements)
            {
                element.Disable();
            }
        }
    }
}