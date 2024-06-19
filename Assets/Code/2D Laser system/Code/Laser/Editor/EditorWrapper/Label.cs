using UnityEditor;
using UnityEngine;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public class Label : IDrawable
    {
        private readonly string _name;
        private readonly GUIStyle _style;
        
        public Label(string name)
        {
            _name = name;
            _style = new GUIStyle
            {
                fontSize = 15,
                fontStyle = FontStyle.Bold
            };
        }

        public void Draw()
        {
            GUIStyle style = EditorStyles.boldLabel;
            style.fontSize = 13;
            
            EditorGUILayout.LabelField(_name, style);
        }
    }
}