using Cysharp.Threading.Tasks;
using Menu.MainMenu.AnimatedPanel;

namespace Menu.LevelChoice
{
    public class LevelChoicePanel : AnimatedPanel
    {
        public override UniTask Initialize()
        {
            LevelButton[] buttons = GetComponentsInChildren<LevelButton>();
            LevelButtonsPresenter buttonsPresenter = new(buttons, UIBlocker);
        
            buttonsPresenter.Initialize();

            return base.Initialize();
        }
    }
}