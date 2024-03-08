using UnityEngine;

public static class Extension
{
    public static bool IsValid(this MonoBehaviour bc)
    {
        return bc != null && bc.isActiveAndEnabled;
    }
    
    public static T DemandComponent<T>(this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static void ResetLocal(this Transform target)
    {
        target.localPosition = Vector3.zero;
        target.localRotation = Quaternion.identity;
        target.localScale = Vector3.one;
    }
}