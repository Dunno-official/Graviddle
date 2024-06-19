using UnityEngine;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public class ReadOnlyElement : IDrawable
    {
        private readonly IDrawable _drawable;

        public ReadOnlyElement(IDrawable drawable)
        {
            _drawable = drawable;
        }
        
        public void Draw()
        {
            GUI.enabled = false;
            _drawable.Draw();
            GUI.enabled = true;
        }
    }   
}