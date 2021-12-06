﻿using UnityEngine;


public class CameraCapture : MonoBehaviour
{
    private readonly float _startCaptureTime = 0.3f;
    [SerializeField] private Rigidbody2D _targetRigidbody = null;
    private CameraBorders _cameraBorders;
    private Transform _mainCamera;
    private Vector3 _velocity;


    private void Start()
    {
        _cameraBorders = Camera.main.GetComponent<CameraBorders>();
        _mainCamera = _cameraBorders.transform;
    }


    private void LateUpdate()
    {
        float captureTime = _startCaptureTime;

        if (_targetRigidbody != null)
        {
            captureTime = EvaluateCaptureTimeFunction(_targetRigidbody.velocity.magnitude);
        }

        _mainCamera.position = Vector3.SmoothDamp(_mainCamera.position, GetNewPosition(), ref _velocity, captureTime);
    }


    private float EvaluateCaptureTimeFunction(float x)
    {
        return 1 / (0.15f * x  + 3.33f);
    }


    private Vector3 GetNewPosition()
    {
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.z = _mainCamera.transform.position.z;

        _cameraBorders.ClampCamera(ref newCameraPosition);

        return newCameraPosition;
    }


    public void ResetCameraTransform()
    {
        _mainCamera.position = GetNewPosition();
        _mainCamera.rotation = transform.rotation;
    }
}