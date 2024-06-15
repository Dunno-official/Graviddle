using System;
using UnityEngine;

namespace Level.Tutorial.PointerAnimation
{
    [Serializable]
    public class SpriteRendererSpriteHolder : ISpriteHolder
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public Sprite Sprite
        {
            get => _spriteRenderer.sprite;
            set => _spriteRenderer.sprite = value;
        }

        public Transform Transform => _spriteRenderer.transform;
    }
}