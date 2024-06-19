using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public class Space : IDrawable
    {
        private readonly int _space;

        public Space(int space)
        {
            _space = space;
        }

        public void Draw()
        {
            EditorGUILayout.Space(_space);
        }
    }
}