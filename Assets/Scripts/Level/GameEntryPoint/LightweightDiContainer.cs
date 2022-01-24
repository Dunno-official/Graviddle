﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public class LightweightDiContainer : MonoBehaviour
{
    private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
    [SerializeField] private List<MonoBehaviour> _objectsWithDependency;

    
    public void ResolveDependencies()
    {
        foreach (MonoBehaviour monoBehaviour in _objectsWithDependency)
        {
            foreach (FieldInfo fieldToInject in monoBehaviour.GetType().GetFieldsToInject())
            {
                fieldToInject.SetValue(monoBehaviour, _instances[fieldToInject.FieldType]);
            }
        }
    }


    public void RegisterTypeWithInstance(object instance)
    {
        _instances[instance.GetType()] = instance;
    }


    public void SetObjectsWithDependencies(List<MonoBehaviour> objectsWithDependency)
    {
        _objectsWithDependency = objectsWithDependency;
        EditorUtility.SetDirty(this);
        Logger.PrintWithGreen("DI container was filled");
    }
}