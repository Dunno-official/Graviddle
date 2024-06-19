using _2D_Laser_system.Code.Laser.Utils;
using Code._2D_Laser_system.Code.Laser.Editor.EditorFactories;
using Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper;
using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.Editors
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AutomaticLaser))]
    public class AutomaticLaserEditor : GenericEditor<AutomaticLaser>
    {
        protected override IEditorFactory<AutomaticLaser> EditorFactory { get; } = new AutomaticLaserEditorFactory();
    }
}