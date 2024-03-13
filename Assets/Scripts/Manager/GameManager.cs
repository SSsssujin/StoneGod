using UnityEngine;

[DefaultExecutionOrder(-10)]
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
