using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ExecutionOrder 설정하면 좋을듯
public class GameManager : Singleton<GameManager>
{
    // Managers
    private readonly ResourceManager _resource = new();
    
    // Objects
    private PlayerController _playerController;

    protected override void _InitializeOnAwake()
    {
        // Caching
        _playerController = FindFirstObjectByType<PlayerController>();
    }

    private void Start()
    {
        _resource.Initialize();
        _playerController.Initialize();
    }

    // Public property
    public static ResourceManager Resource => Instance._resource;
    public static PlayerController Player => Instance._playerController;
}
