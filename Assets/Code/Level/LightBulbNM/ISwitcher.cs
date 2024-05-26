using System;

namespace Level.LightBulbNM
{
    public interface ISwitcher
    {
        event Action<bool> Toggled;
    }
}