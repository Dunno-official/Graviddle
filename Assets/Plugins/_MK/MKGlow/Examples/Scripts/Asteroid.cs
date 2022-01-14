﻿//////////////////////////////////////////////////////
// MK Glow Asteroid                  				//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2017 All rights reserved.            //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Glow.Example
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField]
        private Texture2D[] _emissionTextures = new Texture2D[0];
        private readonly MinMaxRange _minMaxVelocity = new MinMaxRange(-1.0f, 1.0f);
        [SerializeField]
        private MinMaxRange _minMaxScale = new MinMaxRange(0.25f, 2f);
        [SerializeField]
        private MinMaxRange _emissionColorIntensity = new MinMaxRange(1.5f, 2.0f);
        private readonly MinMaxRange _colorChangeTime = new MinMaxRange(2f, 6f);
        private readonly MinMaxRange _colorIntensityChangeTime = new MinMaxRange(2f, 6f);

        private float _nextColorChangeTime;
        private float _nextColorIntensityChangeTime;
        private int _nextColorIndex;
        private float _nextColorIntensity;
        
        [SerializeField]
        private Color[] _colors = new Color[1];
        private Color _currentColor;
        private float _currentColorIntensity = 1;

        [SerializeField]
        private Material _baseMaterial;
        private Material _usedMaterial;

        private Rigidbody _rigidBody;
        private int _emissionColorId;
        private int _emissionTextureId;

        private void Awake()
        {
            _emissionColorId = Shader.PropertyToID("_EmissionColor");
            _emissionTextureId = Shader.PropertyToID("_EmissionMap");

            float scale = Random.Range(_minMaxScale.minValue, _minMaxScale.maxValue);
            transform.localScale = new Vector3(scale, scale, scale);
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.velocity = new Vector3(Random.Range(_minMaxVelocity.minValue, _minMaxVelocity.maxValue), Random.Range(_minMaxVelocity.minValue, _minMaxVelocity.maxValue), Random.Range(_minMaxVelocity.minValue, _minMaxVelocity.maxValue));
            _usedMaterial = new Material(_baseMaterial);
            GetComponent<Renderer>().material = _usedMaterial;
            _nextColorIndex = Random.Range(0, _colors.Length);
            _currentColor = _colors[_nextColorIndex];
            _currentColorIntensity = Random.Range(_emissionColorIntensity.minValue, _emissionColorIntensity.maxValue);
            _usedMaterial.SetColor(_emissionColorId, _currentColor * _currentColorIntensity);
            _usedMaterial.SetTexture(_emissionTextureId, _emissionTextures[Random.Range(0, _emissionTextures.Length - 1)]);
            _usedMaterial.SetTexture("_EmissiveColorMap", _emissionTextures[Random.Range(0, _emissionTextures.Length - 1)]);
        }

        private void Update()
        {
            if(Time.time > _nextColorChangeTime)
            {
                _nextColorChangeTime += Random.Range(_colorChangeTime.minValue, _colorChangeTime.maxValue);
                _nextColorIndex++;
                if(_nextColorIndex > _colors.Length - 1)
                    _nextColorIndex = 0;
            }
            if(Time.time > _nextColorIntensityChangeTime)
            {
                _nextColorIntensityChangeTime += Random.Range(_colorIntensityChangeTime.minValue, _colorIntensityChangeTime.maxValue);
                _nextColorIntensity = Random.Range(_emissionColorIntensity.minValue, _emissionColorIntensity.maxValue);
            }

            _currentColor = Color.Lerp(_currentColor, _colors[_nextColorIndex], Time.smoothDeltaTime);
            _currentColorIntensity = Mathf.Lerp(_currentColorIntensity, _nextColorIntensity, Time.smoothDeltaTime);
            _usedMaterial.SetColor(_emissionColorId, _currentColor * _currentColorIntensity);
            _usedMaterial.SetColor("_EmissiveColor", _currentColor * _currentColorIntensity);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 reflectedVelocity = Vector3.Reflect(_rigidBody.velocity, contact.normal).normalized;       
            _rigidBody.velocity = reflectedVelocity;
        }
    }
}
