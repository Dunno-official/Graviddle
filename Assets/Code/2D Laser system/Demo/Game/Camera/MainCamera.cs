using UnityEngine;

namespace _2D_Laser_system.Demo.Game.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _timeForChasing = 0.1f;
        [SerializeField] private LevelBorders _levelBorders;
        [SerializeField] private UFO.UFO _target;
        private CameraClamping _cameraClamping;
        private CameraFollowing _following;

        private void Start()
        {
            _following = new CameraFollowing(transform, _target);
            _cameraClamping = new CameraClamping(_levelBorders, GetComponent<UnityEngine.Camera>());
        }

        private void LateUpdate()
        {
            if (_target != null)
                _following.Update(_timeForChasing);
            
            transform.position = _cameraClamping.Clamp(transform.position);
        }
    }
}