﻿using UnityEngine;

///<summary>
///Singleton class template
///Controls instantiation of a single instance of class
///</summaty>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
            Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class.");
        else
            instance = (T) this;
    }

    public virtual void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}