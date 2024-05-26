using UnityEngine;

public class ButtonLiftForce : MonoBehaviour, IRestart
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private GravityButton _gravityButton;
    private bool _isLifting;
    
    private void OnEnable()
    {
        _gravityButton.Toggled += OnGravityButtonToggled;
    }

    private void OnDisable()
    {
        _gravityButton.Toggled -= OnGravityButtonToggled;
    }
    
    private void Update()
    {
        if (_isLifting)
        {
            _rigidbody.velocity += (Vector2) transform.up * (_speed * Time.deltaTime);
        }
    }

    private void ResetLiftForce(bool enableLiftForce)
    {
        _isLifting = enableLiftForce;
        _rigidbody.velocity = Vector2.zero;
    }
    
    private void OnGravityButtonToggled(bool isButtonTurnedOn)
    {
        ResetLiftForce(isButtonTurnedOn);
    }

    void IRestart.Restart()
    {
        ResetLiftForce(false);
    }
}