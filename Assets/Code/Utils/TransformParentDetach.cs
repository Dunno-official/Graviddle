using System;
using UnityEngine;

namespace Utils
{
    public class TransformParentDetach : MonoBehaviour
    {
        [SerializeField] private Transform _targetParent;
        [SerializeField] private Vector2 _localPosition;

        private void Start()
        {
            transform.parent = _targetParent;
            transform.localPosition = _localPosition;
        }
    }
}