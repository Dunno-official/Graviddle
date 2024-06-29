using Cysharp.Threading.Tasks;
using Level.UserInterface;
using Level.UserInterface.Panels;
using Menu.MainMenu;
using SaveSystem;
using UnityEngine;

namespace Menu
{
    public class MenuRouter : Panel
    {
        [SerializeField] private UI _ui;

        public override async UniTask Initialize()
        {
            if (new UserName().Exists())
            {
                await _ui.Show<MainMenuPanel>();
            }
            else
            {
                await _ui.Show<EnterYourNamePanel>();
            }
        }
    }
}