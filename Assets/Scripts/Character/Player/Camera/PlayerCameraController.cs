using System;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform Target;
    
    public Vector3 Distance;
    public Vector3 Rotation;

    private void Reset()
    {
        //Target = 
    }

    private void LateUpdate()
    {
        transform.position = Target.position + Distance;
        transform.rotation = Quaternion.Euler(Rotation);
    }
}
