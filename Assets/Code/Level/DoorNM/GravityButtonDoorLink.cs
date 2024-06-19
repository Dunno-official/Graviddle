using Level.Gravitation.GravityButtonNM.Link;
using UnityEngine;

namespace Level.DoorNM
{
    public class GravityButtonDoorLink : GravityButtonLink
    {
        [SerializeField] private Door _door;

        protected override void Enable()
        {
            _door.Open();
        }

        protected override void Disable()
        {
            _door.Close();
        }
    }
}