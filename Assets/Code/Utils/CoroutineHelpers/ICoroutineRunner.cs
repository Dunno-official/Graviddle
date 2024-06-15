using System.Collections;
using UnityEngine;

namespace Utils.CoroutineHelpers
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
    }
}