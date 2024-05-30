using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    public class GravityButton : MonoBehaviourWrapper
    {
        [SerializeField] private GravityButtonOrientation _orientation;
        [SerializeField] private GravityButtonData _data;
        [SerializeField] private AudioSource _toggleSound;
        [SerializeField] private Rigidbody2D _button;
        public readonly GravityButtonEvents Events = new();
        
        private void Awake()
        {
            Events.Initialize(_data, _button.transform);
            
            SetDependencies(new IUnityCallback[]
            {
                Events,
                new GravityButtonRigidbodyConstraints(_button, _orientation),
                new GravityButtonPressFeedback(Events, _toggleSound),
                new GravityButtonLiftForce(Events, _data, _button),
                new GravityButtonClamping(_data, _button.transform),
            });
        }
    }
}