
using MonoBehaviourWrapper;

namespace Level.Restart
{
    public interface IRestart : IUnityCallback
    {
        void Restart();
    }
}