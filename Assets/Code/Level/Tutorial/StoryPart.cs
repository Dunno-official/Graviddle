using System;
using UnityEngine;

namespace Level.Tutorial
{
    [Serializable]
    class StoryPart
    {
        [field: SerializeField] public float WaitTime { get; private set; } = 2f;
        [field: SerializeField] public WoodPointer Pointer { get; private set; }
    }
}