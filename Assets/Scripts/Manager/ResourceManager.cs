using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourceManager : Singleton<ResourceManager>
{
    protected override void _Initialize()
    {
        
    }

    public GameObject Instantiate(string key, Transform parent = null, bool isPooling = false)
    {
        GameObject gameObject = Addressables.InstantiateAsync(key).WaitForCompletion();
        if (transform != null) gameObject.transform.SetParent(parent);
        return gameObject;
    }
}
