using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    public class GravityButtonRigidbodyConstraints : IInitializable
    {
        private readonly GravityButtonOrientation _orientation;
        private readonly Rigidbody2D _button;

        public GravityButtonRigidbodyConstraints(Rigidbody2D button, GravityButtonOrientation orientation)
        {
            _orientation = orientation;
            _button = button;
        }

        public void Initialize()
        {
            _button.constraints = _orientation == GravityButtonOrientation.Horizontal
                ? RigidbodyConstraints2D.FreezePositionY
                : RigidbodyConstraints2D.FreezePositionX;

            _button.constraints |= RigidbodyConstraints2D.FreezeRotation;
        }
    }
}