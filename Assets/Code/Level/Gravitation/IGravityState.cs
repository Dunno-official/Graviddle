
using Level.Character.Helpers;

namespace Level.Gravitation
{
    public interface IGravityState
    {
        GravityDirection Direction { get; }
    
        public GravityData Data => GravityDataPresenter.GravityData[Direction];
    }
}