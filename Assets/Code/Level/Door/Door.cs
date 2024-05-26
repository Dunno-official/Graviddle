using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class Door : MonoBehaviour, IRestart
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _wall;
    [SerializeField] private AnimationCurve _closeCurve;
    [SerializeField] private AnimationCurve _openCurve;
    [SerializeField] private float _duration;
    [SerializeField] private bool _isOpenAtStart;
    private Tween _animation;

    private void Start()
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        _wall.position = _isOpenAtStart ? _start.position : _end.position;
    }

    [Button]
    public void Open()
    {
        MoveWall(_start.position, _openCurve);
    }

    [Button]
    public void Close()
    {
        MoveWall(_end.position, _closeCurve);
    }

    private void MoveWall(Vector2 targetPosition, AnimationCurve curve)
    {
        _animation?.Kill();
        _animation = _wall.DOMove(targetPosition, _duration)
            .SetEase(curve)
            .SetLink(gameObject);
    }

    public void Restart()
    {
        ResetPosition();
    }
}