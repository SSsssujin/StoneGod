using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _movement;
    
    private bool _isPlayerInputBlocked;

    public bool JumpInput;

    public void Start()
    {
        
    }
    
    private void Update()
    {
        _SetPlayerMoveVector();
    }

    private void _SetPlayerMoveVector()
    {
        _movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movement = _isPlayerInputBlocked ? Vector2.zero : _movement;
        PlayerController.Instance.InvokePlayerMovementEvent(_movement);
        
        JumpInput = Input.GetButton("Jump");
    }
}
