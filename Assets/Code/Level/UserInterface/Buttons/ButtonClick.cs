﻿using UnityEngine;
using UnityEngine.UI;

namespace Level.UserInterface.Buttons
{
    public abstract class ButtonClick : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        public void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        protected abstract void OnButtonClick();
    }
}