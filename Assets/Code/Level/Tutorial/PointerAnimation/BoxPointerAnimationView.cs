using Level.Restart;
using UnityEngine;
using Utils.Physics;

namespace Level.Tutorial.PointerAnimation
{
    public class BoxPointerAnimationView : MonoBehaviour, IRestart
    {
        [SerializeField] private StoryTelling _storyTelling;
        [SerializeField] private PointerAnimationData _data;
        [SerializeField] private Collider2D _trigger;
        private PhysicsInputTrigger _physicsInputTrigger;
        private PointerAnimation _animation;
    
        private void Awake()
        {
            _physicsInputTrigger = new PhysicsInputTrigger(_trigger);
            _animation = new PointerAnimation(_data);
        }

        private void Update()
        {
            _physicsInputTrigger.Update();
        }

        private void OnEnable()
        {
            _physicsInputTrigger.Entered += _animation.Kill;
            _storyTelling.StoryEnded += _animation.Play;
        }

        private void OnDisable()
        {
            _physicsInputTrigger.Entered -= _animation.Kill;
            _storyTelling.StoryEnded -= _animation.Play;
        }

        public void Restart()
        {
            _animation.Kill();
        }
    }
}