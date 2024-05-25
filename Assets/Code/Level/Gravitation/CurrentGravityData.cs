

using Character.Helpers;
using Level.UnityCallbackWrappers;

namespace Level.Gravitation
{
    public class CurrentGravityData : ISubscriber 
    {
        private readonly SwipeHandler.SwipeHandler _swipeHandler;

        public CurrentGravityData(SwipeHandler.SwipeHandler swipeHandler)
        {
            _swipeHandler = swipeHandler;
            Data = GravityDataPresenter.GravityData[GravityDirection.Down];
        }

        public GravityData Data { get; private set; }


        void ISubscriber.Subscribe()
        {
            _swipeHandler.GravityChanged += OnGravityChanged;
        }

    
        void ISubscriber.Unsubscribe()
        {
            _swipeHandler.GravityChanged -= OnGravityChanged;
        }

    
        private void OnGravityChanged(GravityDirection gravityDirection)
        {
            Data = GravityDataPresenter.GravityData[gravityDirection];
        }
    }
}