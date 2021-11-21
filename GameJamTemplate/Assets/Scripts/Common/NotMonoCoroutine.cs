using System.Collections;
using UnityEngine;

public sealed class NotMonoCoroutine : Singleton<NotMonoCoroutine>
{
    public static Coroutine StartNotMonoCoroutine(IEnumerator routine)
    {
        return Instance.StartCoroutine(routine);
    }

    public static void StopNotMonoCoroutine(Coroutine coroutine)
    {
        Instance.StopCoroutine(coroutine);
    }
}

