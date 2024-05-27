
namespace MonoBehaviourWrapperNM
{
    public interface ISubscriber : IUnityCallback
    {
        void Subscribe();
        void Unsubscribe();
    }
}