using System;
using Cinemachine;
using UnityEngine;

public class PlayerCameraSettings : MonoBehaviour
{
    [Serializable]
    public struct InvertSettings
    {
        public bool invertX;
        public bool invertY;
    }
    
    // 수정
    public Transform _target;
    public CinemachineFreeLook _cinemachineCamera;
    public InvertSettings _invertSettings;
    
    private void Update()
    {
        _cinemachineCamera.Follow = _target;
        _cinemachineCamera.LookAt = _target;
        _cinemachineCamera.m_XAxis.m_InvertInput = _invertSettings.invertX;
        _cinemachineCamera.m_YAxis.m_InvertInput = _invertSettings.invertY;
    }
}
