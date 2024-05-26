
namespace MonoBehaviourWrapper
{
    public interface ISubscriber : IUnityCallback
    {
        void Subscribe();
        void Unsubscribe();
    }
}