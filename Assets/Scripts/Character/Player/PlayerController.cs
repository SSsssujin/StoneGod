using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter), typeof(PlayerInput),typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerCharacter _playerCharacter;
    
    // Player party
    [SerializeField]
    private List<PlayerCharacterData> _playerCharacterParty;
    private PlayerCharacterData _curPlayerCharacterData;
    private int _curPlayerIndex;

    public void Initialize()
    {
        // Caching
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
        _playerCharacter = GetComponent<PlayerCharacter>();
        
        // Add listeners
        _playerInput.AlphaNumInput += _UpdatePlayerCharacter;
        //OnPlayerCharacterChanged += _UpdatePlayerCharacter;
        
        _Start();
    }
    
    private void _Start()
    {
        _playerMovement.DoStart();
        _playerInput.DoStart();
        _playerCharacter.Initialize();
    }

    private void _UpdatePlayerCharacter(int pressedNum)
    {
        Debug.LogError(pressedNum);
    }
    
    //public Action<int> OnPlayerCharacterChanged;
    public Action<Vector2> OnPlayerInputDetected;
}
