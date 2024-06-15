using UnityEngine;

namespace Utils.CoroutineHelpers
{
    public static class CoroutineExtensions
    {
        public static void TryStop(this Coroutine coroutine, ICoroutineRunner coroutineRunner)
        {
            if (coroutine != null)
            {
                coroutineRunner.StopCoroutine(coroutine);
            }
        }
    }
}