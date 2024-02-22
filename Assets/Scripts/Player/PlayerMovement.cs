using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float MaxForwardSpeed = 5f;
    public float Gravity = 10f;
    public float JumpSpeed;
    
    // Components
    private CharacterController _characterController;
    
    private Vector2 _moveDirection;
    private Vector3 _newPosition;
    
    private bool _isGrounded;
    private bool _isJumpable;
    
    private float _forwardSpeed;
    private float _verticalSpeed;
    private float _desiredForwardSpeed;
    
    private const float _groundedRayDistance = 1.5f;
    private const float _stickingGravityProportion = 0.3f;
    private const float _jumpAbortSpeed = 10f;
    
    // 나중에 리팩토링
    private PlayerInput _playerInput;
    
    private bool IsMoveInput => !Mathf.Approximately(_moveDirection.sqrMagnitude, 0f);

    public void Start()
    {
        _characterController = GetComponent<CharacterController>();
        PlayerController.Instance.OnPlayerInputDetected += _UpdatePlayerDirection;
        
        //
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnDestroy()
    {
        PlayerController.Instance.OnPlayerInputDetected -= _UpdatePlayerDirection;
    }

    private void _UpdatePlayerDirection(Vector2 direction)
    {
        //Debug.Log(direction);
        _moveDirection = direction;
    }

    private void FixedUpdate()
    {
        _CalculateMovement();
        _MoveCharacter();
    }
    
    private void _CalculateMovement()
    {
        // Forward movement
        Vector2 moveInput = _moveDirection;
        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput.Normalize();
        }

        _desiredForwardSpeed = moveInput.magnitude * MaxForwardSpeed;
        float acceleration = IsMoveInput ? 20 : 25;
        _forwardSpeed = Mathf.MoveTowards(_forwardSpeed, _desiredForwardSpeed, acceleration * Time.deltaTime);
        
        // Vertical movement
        if (_isGrounded)
        {
            _verticalSpeed = -Gravity * _stickingGravityProportion;
            
            if (_playerInput.JumpInput && _isJumpable)
            {
                _verticalSpeed = JumpSpeed;
                _isGrounded = false;
                _isJumpable = false;
            }
        }
        else // Airborne
        {
            if (!_playerInput.JumpInput && _verticalSpeed > 0.0f)
            {
                _verticalSpeed -= _jumpAbortSpeed * Time.deltaTime;
            }
            
            if (Mathf.Approximately(_verticalSpeed, 0f))
            {
                _verticalSpeed = 0f;
            }

            // Apply gravity
            _verticalSpeed -= Gravity * Time.deltaTime;
        }
    }

    
    private void _MoveCharacter()
    {
        Vector3 position = transform.position;
        
        _newPosition.Set(_moveDirection.x, 0, _moveDirection.y);
        _newPosition *= MoveSpeed;
        
        if (_isGrounded)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up * (_groundedRayDistance * 0.5f), -Vector3.up);
            if (Physics.Raycast(ray, out hit, _groundedRayDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                Debug.Log("Ground");
                position = Vector3.ProjectOnPlane(_forwardSpeed * _newPosition * Time.deltaTime, hit.normal);
            }
            else
            {
                position = _newPosition * _forwardSpeed * Time.deltaTime;
            }
        }
        else
        {
            position = _newPosition * (_forwardSpeed * Time.deltaTime);
        }
        
        position += Vector3.up * (_verticalSpeed * Time.deltaTime);
        
        _characterController.Move(position);

        _isGrounded = _characterController.isGrounded;
    }
}
