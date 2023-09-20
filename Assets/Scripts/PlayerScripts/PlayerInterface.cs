using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerJoystickable
{
    void SetJoystickParameters(Transform playerTransform, Rigidbody playerRigidbody, Joystick joystick, float rotateSmooth);
    void GetJoystickController(float moveSpeed);
}

public interface IPlayerHitForceable
{
    void GetHitForceController(float jumpForce, float returnForce, PlayerController playerController, Rigidbody rigidbody, Transform ballTransform, Transform playerTransform,
                               float minJump, float maxJump, float minReturn, float maxReturn);
}

public interface ICarTurretable
{
    void SetTurretParameters(GameObject carTurret, float turretActiveSpeed, Transform carBall);
    void GetTurretController();
    void GetCarBallController();
    void GetCarPassiveScaleController();
}

public interface ICarDeadable
{
    void GetDeadController(GameObject carObj, GameObject carSolver, GameObject carSphere);
}

public interface IUIPlayerLookable
{
    void GetLookController(Camera gameCamera, Transform lookUI);
}

public interface IInteract
{
    void Interact(ObjectType type, Transform transform, Action<ObjectType, Transform> action);  
}
