using _2D_Laser_system.Code.Laser.Laser.ChainLaser;
using _2D_Laser_system.Code.Laser.Utils;
using UnityEngine;

namespace _2D_Laser_system.Demo.ChainLaserDemo
{
    public class PointsGeneration : MonoBehaviour
    {
        [SerializeField] private AutomaticLaser _automaticLaser;
        [SerializeField] private Transform[] _keyPoints;
        [SerializeField] private ChainLaser _chainLaser;

        private void OnEnable()
        {
            _automaticLaser.LaserEnable += _keyPoints.Shuffle;
        }

        private void OnDisable()
        {
            _automaticLaser.LaserEnable -= _keyPoints.Shuffle;
        }

        private void Update()
        {
            _chainLaser.KeyPoints.Clear();
                
            foreach (Transform point in _keyPoints)
            {
                _chainLaser.KeyPoints.Add(point.position);
            }
                
            _chainLaser.KeyPoints.Add(_keyPoints[0].position);
        }
    }
}