using UnityEngine;

namespace Level.Tutorial.SpriteHolder
{
    public interface ISpriteHolder
    {
        Sprite Sprite { get; set; }
        Transform Transform { get; }
    }
}