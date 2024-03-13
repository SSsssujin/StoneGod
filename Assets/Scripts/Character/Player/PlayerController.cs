using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerCharacter), typeof(PlayerInput),typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerCharacter _playerCharacters;
    
    // Player party
    [SerializeField]
    private List<PlayerCharacterData> _playerCharacterParty;
    private PlayerCharacterData _curPlayerCharacterData;
    private int _curPlayerIndex;

    public void Initialize()
    {
        _instance = GetComponent<PlayerController>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        
        _Start();
    }
    
    private void _Start()
    {
        _playerInput.Start();
        _playerMovement.Start();

        _UpdatePlayerParty();
        _UpdatePlayerCharacter(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _UpdatePlayerCharacter(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            _UpdatePlayerCharacter(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            _UpdatePlayerCharacter(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            _UpdatePlayerCharacter(4);
    }

    private void _UpdatePlayerParty()
    {
        foreach(var character in _playerCharacterParty)
            character.Start();
    }

    private void _UpdatePlayerCharacter(int pressedNum)
    {
        _curPlayerCharacterData?.Deactivate(); //Exit();
        
        int index = pressedNum - 1;
        PlayerCharacterData selectedPlayer = _playerCharacterParty[index];
        selectedPlayer.Activate();
        _curPlayerCharacterData = selectedPlayer;

        OnPlayerCharacterChanged?.Invoke();
    }
    
    public void InvokePlayerMovementEvent(Vector2 movement)
    {
        OnPlayerInputDetected?.Invoke(movement);
    }

    public Action OnPlayerCharacterChanged;
    public Action<List<PlayerCharacterData>> OnPlayerPartyUpdated;
    public Action<Vector2> OnPlayerInputDetected;
}
