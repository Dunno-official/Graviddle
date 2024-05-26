using System;
using UnityEngine;

[Serializable]
public class TwistingAnimationData
{
    [SerializeField] private float _brightenDuration = 2f;
    [SerializeField] private float _fadeDuration = 5f;
    [SerializeField] private float _waitTime = 1f;
    [SerializeField] private AnimationCurve _fadeCurve;
    [SerializeField] private AnimationCurve _fadeScaleCurve;
    [SerializeField] private AnimationCurve _fadeRotationCurve;
    
    public readonly int HSV = Shader.PropertyToID("_HsvShift");
    public readonly int Rotation = Shader.PropertyToID("_RotateUvAmount");
    public readonly int Twist = Shader.PropertyToID("_TwistUvAmount");
    public readonly int Alpha = Shader.PropertyToID("_Alpha");
    public readonly int WaveStrength = Shader.PropertyToID("_RoundWaveStrength");
    public readonly int WaveSpeed = Shader.PropertyToID("_RoundWaveSpeed");

    public float BrightenDuration => _brightenDuration;
    public float FadeDuration => _fadeDuration;
    public float WaitTime => _waitTime;
    public AnimationCurve FadeCurve => _fadeCurve;
    public AnimationCurve FadeScaleCurve => _fadeScaleCurve;
    public AnimationCurve FadeRotationCurve => _fadeRotationCurve;
}