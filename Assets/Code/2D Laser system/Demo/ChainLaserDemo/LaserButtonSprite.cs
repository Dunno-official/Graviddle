using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Laser;
using _2D_Laser_system.Code.Laser.Laser.Components.Interaction;
using UnityEngine;

namespace _2D_Laser_system.Demo.ChainLaserDemo
{
    public class LaserButtonSprite : MonoBehaviour, ILaserEntered, ILaserExited
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private Sprite _enableSprite;

        public void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            _spriteRenderer.sprite = _enableSprite;
        }

        public void OnLaserExited(LaserBase laserBase)
        {
            if (_spriteRenderer != null)
                _spriteRenderer.sprite = _disableSprite;
        }
    }
}