using Sirenix.OdinInspector;
using UnityEngine;

public class TargetFPS : MonoBehaviour
{
    [SerializeField] private int _target = 60;

    [Button]
    private void SetFps()
    {
        Application.targetFrameRate = _target;
    }
}