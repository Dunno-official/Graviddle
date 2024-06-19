using Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper;
using Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper.Extensions;
using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorFactories
{
    public class ChainLaserEditorFactory : BaseLaserEditorFactory
    {
        protected override IDrawable CreateFirstElement()
        {
            SerializedProperty keyPoints = SerializedObject
                .FindProperty("_keyPointsProvider")
                .FindPropertyRelative("_keyPoints", "_list");

            return new Section("Key points", Space, new DrawableComposite(new IDrawable[]
            {
                new Property(keyPoints),
                new Property(SerializedObject.FindProperty("_gizmoRadius")),
                new Property(FindPropertyInData("_raycastData", "_shootingSpeed"))
            }));
        }
    }
}