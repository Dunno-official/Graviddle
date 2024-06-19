using UnityEditor;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public interface IEditorFactory<in T>
    {
        IDrawable Create(SerializedObject serializedObject, T target);
    }
}