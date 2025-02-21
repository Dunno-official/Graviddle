using Level.CharacterNM.Helpers;
using Level.Gravitation;
using Level.Gravitation.SwipeHandlerNM;
using MonoBehaviourWrapperNM;
using UnityEngine;
using Utils;
using Utils.Physics;

namespace Level.GravityBoxNM
{
    public class GravityBox : MonoBehaviourWrapper
    {
        [SerializeField] private GravityDirection _gravityDirection;
        [SerializeField] private ConstantForce2D _constantForce2D;
        [SerializeField] private BoxGravitySelection _selection;
        [SerializeField] private SpriteRenderer _outline;
        [SerializeField] private SpriteRenderer _arrow;
        [SerializeField] private Vector2 _outlineScale;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Canvas _canvas;

        public PhysicsInputTrigger PhysicsInputTrigger { get; private set; }
        
        public void Initialize(SwipeHandler swipeHandler)
        {
            PhysicsInputTrigger = new PhysicsInputTrigger(_collider);
            Gravity gravity = new(_constantForce2D, 50f, _gravityDirection);
            BoxGravityState boxGravityState = new(transform, _gravityDirection);
            BoxGravityHandler gravityHandler = new(gravity, _selection, boxGravityState);
            GravityRotation rotation = new(boxGravityState, _arrow.transform, 180, 6);
            BoxMediator boxMediator = new(PhysicsInputTrigger, swipeHandler, gravityHandler, new IToggleable[]
            {
                new ScalePopup(_canvas.transform, 0.5f, 0, new Vector2(1.25f, 1.25f)),
                new ScalePopup(_outline.transform, 0.5f, 1, _outlineScale)
            });

            SetDependencies(new IUnityCallback[]
            {
                gravity,
                rotation,
                _selection,
                boxMediator,
                gravityHandler,
                PhysicsInputTrigger,
            });
        }
    }
}
