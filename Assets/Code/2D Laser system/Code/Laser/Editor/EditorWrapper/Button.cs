using UnityEngine;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public abstract class Button : IDrawable
    {
        private readonly string _name;

        protected Button(string name)
        {
            _name = name;
        }

        public void Draw()
        {
            if (GUILayout.Button(_name))
            {
                OnClicked();
            }
        }

        protected abstract void OnClicked();
    }
}