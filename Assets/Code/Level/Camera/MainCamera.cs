using Level.Camera.Animations;
using Level.Camera.Clamping;
using Level.Camera.Clamping.Data;
using MonoBehaviourWrapper;
using UnityEngine;

namespace Level.Camera
{
    public class MainCamera : MonoBehaviourWrapper.MonoBehaviourWrapper
    {
        [SerializeField] private UnityEngine.Camera _camera;

        public void Initialize(CameraData data)
        {
            CameraClampingSettingsFactory cameraClampingSettingsFactory = new(data.Borders, _camera);
            CameraClampingSettings settings = cameraClampingSettingsFactory.Create();
            CameraBordersWithOrientation borders = new(settings, data.SwipeHandler);
            CharacterCapture characterCapture = new(data.Character, transform, borders);
            CameraZoom cameraZoom = new(data, _camera, characterCapture);
        
            SetDependencies(new IUnityCallback[]
            {
                borders,
                characterCapture,
                cameraZoom,
                new CameraRotation(transform, data.RotationData, data.SwipeHandler, this),
            });
        }
    }
}