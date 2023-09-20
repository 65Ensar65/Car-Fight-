using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : Base,IInteract
{
    public float BulletSpeed;
    public ObjectType BulletType;

    public void Interact(ObjectType type, Transform transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.PlayerBall:
                GetActionController(action, transform);
                break;
            case ObjectType.EnemyBall1:
                GetActionController(action, transform);
                break;
            case ObjectType.EnemyBall2:
                GetActionController(action, transform);
                break;
            case ObjectType.EnemyBall3:
                GetActionController(action, transform);
                break;
            case ObjectType.EnemyBall4:
                GetActionController(action, transform);
                break;
            case ObjectType.Player:
                GetActionController(action, transform);
                break;
            case ObjectType.Enemy1:
                GetActionController(action, transform);
                break;
            case ObjectType.Enemy2:
                GetActionController(action, transform);
                break;
            case ObjectType.Enemy3:
                GetActionController(action, transform);
                break;
            case ObjectType.Enemy4:
                GetActionController(action, transform);
                break;
            case ObjectType.AirTurretDrop:
                GetActionController(action, transform);
                break;
            case ObjectType.AirBallDrop:
                GetActionController(action, transform);
                break;
            case ObjectType.FallWall:
                GetActionController(action, transform);
                break;
            case ObjectType.TurretBullet:
                GetActionController(action, transform);
                break;
            case ObjectType.Platform:
                GetActionController(action, transform);
                break;
            default:
                break;
        }
    }

    void GetActionController(Action<ObjectType,Transform> action, Transform transform)
    {
        action.Invoke(BulletType, transform);
        e_objectPool.ReturnPoolObject(ObjectTag.TurretBullet, this.gameObject);
    }
    void Update()
    {
        transform.Translate(transform.forward * BulletSpeed, Space.World);    
    }
}
