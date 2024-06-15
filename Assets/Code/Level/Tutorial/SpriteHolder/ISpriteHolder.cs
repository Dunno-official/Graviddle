using UnityEngine;

namespace Level.Tutorial.PointerAnimation
{
    public interface ISpriteHolder
    {
        Sprite Sprite { get; set; }
        Transform Transform { get; }
    }
}