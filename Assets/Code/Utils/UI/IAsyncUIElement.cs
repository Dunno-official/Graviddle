using Cysharp.Threading.Tasks;

namespace Level.UserInterface
{
    public interface IAsyncUIElement
    {
        void Initialize() {}
        UniTask Show();
        UniTask Hide();
    }
}