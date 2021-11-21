using System.Collections.Generic;
using UnityEngine;

public class SystemPrefabsSetter : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject[] SystemPrefabs;          //System prefabs conteining common for all scenes functionality, like UIManager, SoundManager etc

    List<GameObject> _instancedSystemPrefabs;

    private void Start()
    {
        _instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();
    }

    protected void OnDestroy()
    {
        CleatInstantiatedSystemPrefabs();
    }

    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    void CleatInstantiatedSystemPrefabs()
    {
        if (_instancedSystemPrefabs == null)
            return;

        for (int i = 0; i < _instancedSystemPrefabs.Count; ++i)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }
}
