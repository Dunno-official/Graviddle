using System;
using Level.CharacterNM.Helpers;

namespace Level.Gravitation
{
    public interface IGravityState
    {
        GravityDirection Direction { get; }
        event Action DirectionChanged;
        public GravityData Data => GravityDataPresenter.GravityData[Direction];
    }
}