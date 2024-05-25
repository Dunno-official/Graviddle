using System;

namespace Level.LightBulb
{
    public interface ISwitcher
    {
        event Action<bool> Toggled;
    }
}