using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level.Restart
{
    public class RestartableComponents
    {
        public readonly IEnumerable<IRestart> RestartComponents;
        public readonly IEnumerable<IAfterRestart> AfterRestartComponents;

        public RestartableComponents()
        {
            MonoBehaviour[] monoBehaviours = Object.FindObjectsOfType<MonoBehaviour>(true);
            RestartComponents = monoBehaviours.OfType<IRestart>();
            AfterRestartComponents = monoBehaviours.OfType<IAfterRestart>();
        }
    }
}