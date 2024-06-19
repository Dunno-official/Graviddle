using System.Collections;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Utils
{
    public interface ICoroutineRunner
    {
        void StopAllCoroutines();
        Coroutine StartCoroutine(IEnumerator function);
        bool isActiveAndEnabled { get; }
    }
}