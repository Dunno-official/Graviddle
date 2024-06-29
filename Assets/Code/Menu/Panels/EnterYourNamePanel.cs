using Level.UserInterface;
using Menu.MainMenu;
using Menu.MainMenu.AnimatedPanel;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class EnterYourNamePanel : AnimatedPanel
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private UI _ui;

        public async void Submit()
        {
            new UserName().Save(_inputField.text);
            await _ui.Show<MainMenuPanel>();
        }
    }
}
