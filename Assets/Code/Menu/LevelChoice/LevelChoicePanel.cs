using Cysharp.Threading.Tasks;

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