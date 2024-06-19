using System;
using UnityEngine;
using UnityEngine.UI;

namespace Level.Tutorial.SpriteHolder
{
    [Serializable]
    public class ImageSpriteHolder : ISpriteHolder
    {
        [SerializeField] private Image _image;

        public Sprite Sprite
        {
            get => _image.sprite;
            set => _image.sprite = value;
        }

        public Transform Transform => _image.transform;
    }
}