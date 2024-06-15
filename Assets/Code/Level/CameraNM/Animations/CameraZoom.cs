using System;
using Level.Gravitation;
using MonoBehaviourWrapperNM;
using UnityEngine;
using UnityEngine.UI;

namespace Level.CameraNM.Animations
{
    public class CameraZoom : ISubscriber, IDisposable
    {
        private readonly IGravityState _gravityState;
        private readonly CameraAnimation _animation;
        private readonly CharacterCapture _capture;
        private readonly Button _zoomOutButton;
        private readonly Button _zoomInButton;

        public CameraZoom(CameraData data, Camera camera, CharacterCapture capture)
        {
            CameraMovingToCentreAnimation movingToCentreAnimation = new(data.Borders, camera);
            LevelZoomCalculator zoomCalculator = new(camera, data.Borders, data.CharacterGravityState);
            CameraZoomAnimation zoomAnimation = new(camera, zoomCalculator);
        
            _animation = new CameraAnimation(movingToCentreAnimation, zoomAnimation);
            _gravityState = data.CharacterGravityState;
            _zoomOutButton = data.ZoomOutButton;
            _zoomInButton = data.ZoomInButton;
            _capture = capture;
        }

        void ISubscriber.Subscribe()
        {
            _zoomInButton.onClick.AddListener(ZoomIn);
            _zoomOutButton.onClick.AddListener(ZoomOut);
            _gravityState.DirectionChanged += TryRecalculateZoom;
        }

        void ISubscriber.Unsubscribe()
        {
            _zoomInButton.onClick.RemoveListener(ZoomIn);
            _zoomOutButton.onClick.RemoveListener(ZoomOut);
            _gravityState.DirectionChanged -= TryRecalculateZoom;
        }

        private void ZoomIn()
        {
            _animation.ZoomIn();
            _capture.IsActive = true;
        }

        private void ZoomOut()
        {
            _animation.ZoomOut();
            _capture.IsActive = false;
        }

        private void TryRecalculateZoom()
        {
            if (_capture.IsActive == false)
            {
                ZoomOut();
            }
        }

        public void Dispose()
        {
            _animation.Kill();
        }
    }
}