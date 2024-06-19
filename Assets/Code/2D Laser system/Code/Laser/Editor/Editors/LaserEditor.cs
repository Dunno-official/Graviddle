using Code._2D_Laser_system.Code.Laser.Editor.EditorFactories;
using Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper;
using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.Editors
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(global::_2D_Laser_system.Code.Laser.Laser.Laser))]
    public class LaserEditor : GenericEditor<global::_2D_Laser_system.Code.Laser.Laser.Laser>
    {
        protected override IEditorFactory<global::_2D_Laser_system.Code.Laser.Laser.Laser> EditorFactory { get; } = new LaserEditorFactory();
    }
}