using PathCreation;
using UnityEngine;

public class PathFollower : MonoBehaviour, IRestart
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private EndOfPathInstruction _pathInstruction;
    [SerializeField] private float _speed = 3f;
    private float _distance;

    private void Update()
    {
        _distance += _speed * Time.deltaTime;
        transform.position = (Vector2)_pathCreator.path.GetPointAtDistance(_distance, _pathInstruction);
    }
    
    void IRestart.Restart()
    {
        _distance = 0;
    }
}
