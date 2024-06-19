using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Laser;
using _2D_Laser_system.Code.Laser.Laser.Components.Interaction;
using _2D_Laser_system.Demo.Game.Restart;
using UnityEngine;

namespace _2D_Laser_system.Demo.Game
{
    public class LaserButton : MonoBehaviour, ILaserEntered, IRestart
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Laser _laser;

        private void Start()
        {
            _laser.Enable();
        }

        public void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            _spriteRenderer.sprite = _enableSprite;
            _laser.Disable();
        }

        public void Restart()
        {
            _spriteRenderer.sprite = _disableSprite;
            _laser.Enable();
        }
    }
}