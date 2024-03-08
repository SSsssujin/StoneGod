using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourceManager
{
    private List<GameObject> _instantiatedGameObjects;

    public void Initialize()
    {
        _instantiatedGameObjects = new();
    }

    public GameObject Instantiate(GameObject gameObject, Transform parent = null)
    {
        return Object.Instantiate(gameObject, parent);
    }

    public GameObject Instantiate(string key, Transform parent = null, bool isPooling = false)
    {
        GameObject gameObject = Addressables.InstantiateAsync(key).WaitForCompletion();
        if (parent != null) gameObject.transform.SetParent(parent);
        _instantiatedGameObjects.Add(gameObject);
        return gameObject;
    }

    public void Destroy(GameObject instance)
    {
        if (_instantiatedGameObjects.Contains(instance))
            Addressables.ReleaseInstance(instance);
        else
            Object.Destroy(instance);
    }
}