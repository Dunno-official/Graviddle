using Level.CameraNM.Animations;
using Level.CameraNM.Clamping;
using Level.CameraNM.Clamping.Data;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.CameraNM
{
    public class MainCamera : MonoBehaviourWrapper
    {
        [SerializeField] private Camera _camera;

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