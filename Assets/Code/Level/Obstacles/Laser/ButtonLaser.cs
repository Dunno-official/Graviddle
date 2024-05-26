using UnityEngine;

public class ButtonLaser : MonoBehaviour
{
    [SerializeField] private LaserSwitcher _laserSwitcher;
    [SerializeField] private GravityButton _gravityButton;
    
    private void Start()
    {
        _laserSwitcher.Initialize(true);
    }
    
    private void OnEnable()
    {
        _gravityButton.Toggled += ToggleLaser;
    }
    
    private void OnDisable()
    {
        _gravityButton.Toggled -= ToggleLaser;
    }

    private void ToggleLaser(bool isButtonPressed)
    {
        StopAllCoroutines();
        _laserSwitcher.StopAnimation();
        StartCoroutine(_laserSwitcher.ToggleLaser(isButtonPressed == false));
    }
}
