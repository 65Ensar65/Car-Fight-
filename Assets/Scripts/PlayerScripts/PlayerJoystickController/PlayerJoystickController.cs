using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : IPlayerJoystickable
{
    private Joystick _joystick;
    private Rigidbody _playerRigidbody;
    private Transform _playerTransform;
    private float _moveSpeed;
    public void SetJoystickParameters(Transform playerTransform, Rigidbody playerRigidbody, Joystick joystick, float rotateSmooth)
    {
        _joystick = joystick;
        _playerRigidbody = playerRigidbody;
        _playerTransform = playerTransform;
        _moveSpeed = rotateSmooth;
    }
    public void GetJoystickController(float moveSpeed)
    {
        _moveSpeed = moveSpeed;

        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;
        if (horizontal != 0 || vertical != 0)
        {
            _playerRigidbody.isKinematic = false;

            Vector3 directionVector = (Vector3.right * horizontal) + (Vector3.forward * vertical);
            _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, Quaternion.LookRotation(directionVector),0.05f);

            Vector3 moveVector = _playerTransform.forward * directionVector.magnitude * _moveSpeed;
            _playerRigidbody.velocity = moveVector;
            _playerRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
        }

        else
        {
            _playerRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
        }
    }
}
