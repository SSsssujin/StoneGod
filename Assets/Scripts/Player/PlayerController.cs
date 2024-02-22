using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput),typeof(PlayerMovement))]
public class PlayerController : Singleton<PlayerController>
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;

    protected override void _Initialize()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void Start()
    {
        _playerInput.Start();
        _playerMovement.Start();
    }

    public void InvokePlayerMovementEvent(Vector2 movement)
    {
        OnPlayerInputDetected?.Invoke(movement);
    }
    
    public Action<Vector2> OnPlayerInputDetected;
}
