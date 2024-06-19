using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _2D_Laser_system.Demo.Game.Restart
{
    public class LevelRestart : MonoBehaviour
    {
        private IEnumerable<IRestart> _restarts;
    
        private void Start()
        {
            _restarts = Code.Laser.Utils.Utils.FindObjects<MonoBehaviour>().OfType<IRestart>();
        }

        public void RestartForEach()
        {
            foreach (IRestart restartableObject in _restarts)
            {
                restartableObject.Restart();
            }
        }
    }
}