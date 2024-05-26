using UnityEngine;

namespace Utils.Physics
{
    public readonly struct HitResult<T> where T : MonoBehaviour
    {
        public readonly RaycastHit2D Hit;
        public readonly bool Success;
        public readonly T Component;

        public HitResult(RaycastHit2D hit, bool success, T component)
        {
            Hit = hit;
            Success = success;
            Component = component;
        }
    }
}