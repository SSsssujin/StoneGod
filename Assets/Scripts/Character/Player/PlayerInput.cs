using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _movement;
    
    private bool _isPlayerInputBlocked;
    private bool _isJumpInput;
    
    public void Start()
    {
        
    }
    
    private void Update()
    {
        _SetPlayerMoveVector();
        _isJumpInput = Input.GetButton("Jump");
    }

    private void _SetPlayerMoveVector()
    {
        _movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movement = _isPlayerInputBlocked ? Vector2.zero : _movement;
        GameManager.Player.InvokePlayerMovementEvent(_movement);
    }
    
    public bool JumpInput => _isJumpInput;
}
