using Level.Gravitation.GravityButton;
using UnityEngine;

public class GravityButtonIndicator : MonoBehaviour
{
    [SerializeField] private GravityButton _gravityButton;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _enabledSprite;
    [SerializeField] private Sprite _disabledSprite;

    private void OnEnable()
    {
        _gravityButton.Events.Toggled += ChangeState;
    }
    
    private void OnDisable()
    {
        _gravityButton.Events.Toggled -= ChangeState;
    }

    private void ChangeState(bool isActive)
    {
        _spriteRenderer.sprite = isActive ? _enabledSprite : _disabledSprite;
    }
}