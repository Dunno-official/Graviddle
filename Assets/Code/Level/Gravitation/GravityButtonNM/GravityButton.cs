using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    public class GravityButton : MonoBehaviourWrapper
    {
        [SerializeField] private GravityButtonOrientation _orientation;
        [SerializeField] private GravityButtonData _data;
        [SerializeField] private AudioSource _toggleSound;
        [SerializeField] private Rigidbody2D _buttonRigidbody2D;
        
        public GravityButtonEvents Events { get; private set; }
        public GravityButtonState State { get; private set; }
        
        public void Initialize()
        {
            SetDependencies(new IUnityCallback[]
            {
                Events = new GravityButtonEvents(_data, _buttonRigidbody2D.transform), 
                State = new GravityButtonState(Events),
                new GravityButtonRigidbodyConstraints(_buttonRigidbody2D, _orientation),
                new GravityButtonPressFeedback(Events, _toggleSound),
                new GravityButtonLiftForce(Events, _data, _buttonRigidbody2D),
                new GravityButtonClamping(_data, _buttonRigidbody2D.transform, _buttonRigidbody2D),
            });
        }
    }
}