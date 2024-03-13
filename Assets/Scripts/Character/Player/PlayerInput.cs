using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Vector2 _movement;
    
    private bool _isPlayerInputBlocked;
    private bool _isJumpInput;

    private PlayerController _player;
    
    public void DoStart()
    {
        _player = GameManager.Player;
    }
    
    private void Update()
    {
        if (_isPlayerInputBlocked) return;
        
        _SetPlayerMoveVector();
        _isJumpInput = Input.GetButton("Jump");
        
        // Refactoring
        for (int i = 1; i <= 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i)) {
                AlphaNumInput?.Invoke((int)(KeyCode.Alpha0 + i));
                break;
            }
        }
    }

    private void _SetPlayerMoveVector()
    {
        _movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movement = _isPlayerInputBlocked ? Vector2.zero : _movement;
        _player?.OnPlayerInputDetected?.Invoke(_movement);
    }

    public void BlockPlayerInput()
    {
        
    }
    
    public bool JumpInput => _isJumpInput;

    public event Action<int> AlphaNumInput;
}
