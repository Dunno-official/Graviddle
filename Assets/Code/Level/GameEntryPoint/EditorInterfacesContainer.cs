using System.Collections.Generic;
using System.Linq;
using Level.Gravitation;
using Level.Restart;
using UnityEngine;


// buffer between editor and playmode
namespace Level.GameEntryPoint
{
    public class EditorInterfacesContainer : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _restartable;
        [SerializeField] private List<MonoBehaviour> _afterRestartable;
        [SerializeField] private List<RestartableTransform> _restartableTransforms;
        [SerializeField] private List<TransformWithGravityRotation> _transformWithGravityRotations;


        public void FillContainers()
        {
            MonoBehaviour[] allMonoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            _afterRestartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IAfterRestart).ToList();
            _restartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IRestart).ToList();
            _restartableTransforms = allMonoBehaviours.OfType<RestartableTransform>().ToList();
            _transformWithGravityRotations = allMonoBehaviours.OfType<TransformWithGravityRotation>().ToList();
        }


        public RestartableComponents GetRestartableComponents()
        {
            IEnumerable<IRestart> restartComponents = _restartable.Cast<IRestart>();
            IEnumerable<IAfterRestart> afterRestartComponents = _afterRestartable.Cast<IAfterRestart>();

            return new RestartableComponents(restartComponents, afterRestartComponents, _restartableTransforms);
        }


        public IEnumerable<TransformWithGravityRotation> GetTransformsWithGravityRotation()
        {
            return _transformWithGravityRotations;
        }
    }
}