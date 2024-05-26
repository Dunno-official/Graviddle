﻿
namespace Menu.LevelChoice
{
    public class LevelButtonsPresenter
    {
        private readonly LevelButton[] _buttons;
        private readonly UIBlocker _blocker;

        public LevelButtonsPresenter(LevelButton[] buttons, UIBlocker blocker)
        {
            _buttons = buttons;
            _blocker = blocker;
        }

        public void Initialize()
        {
            foreach (LevelButton levelButton in _buttons)
            {
                levelButton.Initialize(_blocker);
            }
        }
    }
}