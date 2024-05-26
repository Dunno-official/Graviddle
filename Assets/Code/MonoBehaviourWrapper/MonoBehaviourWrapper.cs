using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Level.Restart;
using UnityEngine;
using Utils.CoroutineHelpers;

namespace MonoBehaviourWrapper
{
    public abstract class MonoBehaviourWrapper : MonoBehaviour, IRestart, IAfterRestart, ICoroutineRunner
    {
        private IEnumerable<IAfterRestart> _afterRestartComponents;
        private IEnumerable<IRestart> _restartComponents;
        private IEnumerable<IFixedUpdate> _fixedUpdates;
        private IEnumerable<ISubscriber> _subscribers;
        private IEnumerable<ILateUpdate> _lateUpdates;
        private IEnumerable<IDisposable> _disposables;
        private IEnumerable<IUpdate> _updates;
        private IEnumerable<IGizmo> _gizmo;

        protected void SetDependencies(IUnityCallback[] dependencies)
        {
            dependencies.OfType<IInitializable>().ForEach(initializable => initializable.Initialize());
            _afterRestartComponents = dependencies.OfType<IAfterRestart>();
            _restartComponents = dependencies.OfType<IRestart>();
            _fixedUpdates = dependencies.OfType<IFixedUpdate>();
            _subscribers = dependencies.OfType<ISubscriber>();
            _lateUpdates = dependencies.OfType<ILateUpdate>();
            _disposables = dependencies.OfType<IDisposable>();
            _updates = dependencies.OfType<IUpdate>();
            _gizmo = dependencies.OfType<IGizmo>();
        }

        private void OnEnable() => _subscribers.SubscribeForEach();

        private void OnDisable() => _subscribers.UnsubscribeForEach();

        private void FixedUpdate() => _fixedUpdates.FixedUpdateForEach();

        private void Update() => _updates.UpdateForEach();

        private void LateUpdate() => _lateUpdates.LateUpdateForEach();
        
        private void OnDrawGizmos() => _gizmo.DrawForEach();

        void IRestart.Restart() => _restartComponents.RestartForEach();

        void IAfterRestart.Restart() => _afterRestartComponents.RestartForEach();

        private void OnDestroy() => _disposables.DisposeForEach();
    }
}