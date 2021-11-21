using UnityEngine.Events;

/// <summary>
/// Events templates definition
/// </summary>
public class Events
{
    [System.Serializable] public class EventIntegerEvent : UnityEvent<int> { }
    [System.Serializable] public class EventVoidEvent : UnityEvent { }
}


