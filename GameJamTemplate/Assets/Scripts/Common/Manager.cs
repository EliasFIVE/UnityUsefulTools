using UnityEngine;

/// <summary>
/// Manager singleton class template
/// Sets instance to DontDestroyOnLoad when apply
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
        set
        {
            if (instance == null)
            {
                instance = value;
                DontDestroyOnLoad(instance.gameObject);
            }
            else if (instance != value)
            {
                Destroy(value.gameObject);
            } 
        }
    }

    protected virtual void Awake()
    {
        Instance = this as T;
    }
}
