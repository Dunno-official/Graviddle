using UnityEngine;

namespace Level.UserInterface.Parallax.GameParallax
{
    public class ParallaxLayerClamping
    {
        private readonly float _screenWidth;
    
        public ParallaxLayerClamping()
        {
            _screenWidth = Screen.width;
        }
    
        public void ClampParallaxLayerPosition(ref float targetParallaxLayerPosition)
        {
            if (targetParallaxLayerPosition > _screenWidth)
            {
                targetParallaxLayerPosition -= _screenWidth;
            }

            else if (targetParallaxLayerPosition < -_screenWidth)
            {
                targetParallaxLayerPosition += _screenWidth;
            }
        }
    }
}