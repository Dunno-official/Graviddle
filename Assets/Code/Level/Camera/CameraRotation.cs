using System.Collections;
using Level.Camera;
using UnityEngine;
using Utils.CoroutineHelpers;

public class CameraRotation : ISubscriber
{
    private readonly CameraRotationData _rotationData;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly SwipeHandler _swipeHandler;
    private readonly Transform _transform;
    private Coroutine _animation;
    
    public CameraRotation(Transform transform, CameraRotationData rotationData, SwipeHandler swipeHandler, ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
        _rotationData = rotationData;
        _swipeHandler = swipeHandler;
        _transform = transform;
    }

    public void Subscribe()
    {
        _swipeHandler.GravityChanged += InvokeRotationAnimation;
    }

    public void Unsubscribe()
    {
        _swipeHandler.GravityChanged -= InvokeRotationAnimation;
    }

    private void InvokeRotationAnimation(GravityDirection gravityDirection)
    {
        _animation.TryStop(_coroutineRunner);
        _animation = _coroutineRunner.StartCoroutine(PlayAnimationAnimation(gravityDirection));
    }

    private IEnumerator PlayAnimationAnimation(GravityDirection gravityDirection)
    {
        float time = 0;
        Quaternion initialRotation = _transform.rotation;
        Quaternion targetRotation = GravityDataPresenter.GravityData[gravityDirection].Rotation;
        
        while (time < _rotationData.Time)
        {
            time += Time.deltaTime;
            float timelineLerp = time / _rotationData.Time;
            float lerp = _rotationData.Curve.Evaluate(timelineLerp);
            _transform.rotation = Quaternion.LerpUnclamped(initialRotation, targetRotation, lerp);
            
            yield return null;
        }
    }
}