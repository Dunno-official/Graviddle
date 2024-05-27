
using MonoBehaviourWrapperNM;

namespace Level.Restart
{
    public interface IAfterRestart : IUnityCallback
    {
        void Restart();
    }
}