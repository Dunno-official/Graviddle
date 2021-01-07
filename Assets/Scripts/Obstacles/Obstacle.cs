﻿using System.Collections;
using UnityEngine;
public class Obstacle : RestartableObject
{
    private static bool _enabled = true;
    protected Vector3 _restartPosition = Vector3.zero;


    private void Start()
    {
        _enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character && _enabled)
            StartCoroutine(character.Die());
    }


    public static IEnumerator SwitchOff() // персонаж неуязвим во время респауна
    {
        _enabled = false;
        yield return new WaitForSeconds(3f);
        _enabled = true;
    }
}
