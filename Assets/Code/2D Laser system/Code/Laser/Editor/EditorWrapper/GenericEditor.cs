using UnityEngine;

namespace Code._2D_Laser_system.Code.Laser.Editor.EditorWrapper
{
    public abstract class GenericEditor<T> : UnityEditor.Editor where T : Object
    {
        private IDrawable _editor;

        private void OnEnable()
        {
            _editor = EditorFactory.Create(serializedObject, (T)target);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            _editor.Draw();

            serializedObject.ApplyModifiedProperties();
        }

        protected abstract IEditorFactory<T> EditorFactory { get; }
    }
}