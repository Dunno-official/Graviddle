using UnityEditor;
using UnityEngine;

namespace Code._2D_Laser_system.Code.Laser.Editor.Editors
{
    public static class EditorUtils
    {
        public static Vector3 GetSceneWorldMousePosition()
        {
            Vector3 worldPosition = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
            worldPosition.z = 0;

            return worldPosition;
        }
    }
}