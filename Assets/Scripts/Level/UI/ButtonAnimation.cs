﻿using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float _verticalOffset = 8f;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveButton(1);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        MoveButton(-1);
    }


    private void MoveButton(int sign)
    {
        transform.position = transform.position + sign * _verticalOffset * transform.up;
    }
}