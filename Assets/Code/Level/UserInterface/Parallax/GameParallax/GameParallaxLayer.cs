using Level.CharacterNM.Helpers;
using Level.Gravitation.SwipeHandlerNM;
using UnityEngine;

namespace Level.UserInterface.Parallax.GameParallax
{
    public class GameParallaxLayer : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float _parallaxEffect;
        [SerializeField] private SwipeHandler _swipeHandler;
        [SerializeField] private RectTransform _layer;
        private ParallaxCameraPosition _parallaxCameraPosition;
        private ParallaxLayerClamping _parallaxLayerClamping;
        private GravityDirection _gravityDirection;
        private float _lastCameraPosition;

        private void Start()
        {
            _parallaxLayerClamping = new ParallaxLayerClamping();
            _parallaxCameraPosition = new ParallaxCameraPosition(Camera.main!.transform);
        }

        private void OnEnable()
        {
            _swipeHandler.GravityChanged += OnGravityChanged;
        }

        private void OnDisable()
        {
            _swipeHandler.GravityChanged -= OnGravityChanged;
        }

        private void Update()
        {
            float newCameraPosition = _parallaxCameraPosition.GetCameraPosition(_gravityDirection);

            _layer.anchoredPosition = GetParallaxLayerPosition(newCameraPosition);

            _lastCameraPosition = newCameraPosition;
        }

        private Vector2 GetParallaxLayerPosition(float newCameraPosition)
        {
            const float parallaxSpeed = 60f;
            float cameraDiffPosition = newCameraPosition - _lastCameraPosition;
            float targetXParallaxPosition = cameraDiffPosition * _parallaxEffect * parallaxSpeed;
            targetXParallaxPosition = _layer.anchoredPosition.x - targetXParallaxPosition;

            _parallaxLayerClamping.ClampParallaxLayerPosition(ref targetXParallaxPosition);

            return new Vector2(targetXParallaxPosition, _layer.anchoredPosition.y);
        }

        private void OnGravityChanged(GravityDirection gravityDirection)
        {
            _gravityDirection = gravityDirection;
            _lastCameraPosition = _parallaxCameraPosition.GetCameraPosition(gravityDirection);
        }
    }
}