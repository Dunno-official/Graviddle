using Level.CameraNM.Clamping.Data;
using UnityEngine;

namespace Level.CharacterNM
{
    public class DeathFromLevelBorders : IDeathCondition
    {
        private readonly Transform _transform;
        private readonly LevelBorders _borders;

        public DeathFromLevelBorders(LevelBorders borders, Transform transform)
        {
            _transform = transform;
            _borders = borders;
        }

        public bool IsDead(out string reason)
        {
            reason = "Out of level borders";
            return _borders.CheckIfPositionNotWithinTheLevel(_transform.position);
        }
    }
}