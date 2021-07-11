﻿using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class ImageFading 
{
    [SerializeField] private float _fadingSpeed = 0;
    [SerializeField] private float _brightenSpeed = 0;


    public IEnumerator ChangeAlphaChannel(bool becomeOpaque , Action<float> callBack)
    {
        float alphaChannel = becomeOpaque ? 0 : 1;
        float fadingSpeed = becomeOpaque ? _brightenSpeed : -_fadingSpeed;

        while (becomeOpaque ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += fadingSpeed * Time.deltaTime;
            callBack(alphaChannel);
            yield return new WaitForFixedUpdate();
        }
    }
}