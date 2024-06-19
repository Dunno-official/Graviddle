using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public class Property : IDrawable
    {
        private readonly SerializedProperty _property;

        public Property(SerializedProperty property)
        {
            _property = property;
        }

        public void Draw()
        {
            EditorGUILayout.PropertyField(_property);
        }
    }
}