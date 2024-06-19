using _2D_Laser_system.Code.Laser.Laser.ChainLaser;
using Code._2D_Laser_system.Code.Laser.Editor.EditorFactories;
using Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper;
using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.Editors
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ChainLaser))]
    public class ChainLaserEditor : GenericEditor<ChainLaser>
    {
        protected override IEditorFactory<ChainLaser> EditorFactory { get; } = new ChainLaserEditorFactory();
    }
}