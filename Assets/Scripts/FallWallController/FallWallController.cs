using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWallController : Base, IInteract
{
    public ObjectType WallType;
    public void Interact(ObjectType type, Transform transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                GetActionController(type, transform, action);
                break;
            case ObjectType.Enemy1:
                GetActionController(type, transform, action);
                break;
            case ObjectType.Enemy2:
                GetActionController(type, transform, action);
                break;
            case ObjectType.Enemy3:
                GetActionController(type, transform, action);
                break;
            case ObjectType.Enemy4:
                GetActionController(type, transform, action);
                break;
            case ObjectType.TurretBullet:
                GetActionController(type, transform, action);
                break;
            default:
                break;
        }
    }

    void GetActionController(ObjectType type, Transform transform, Action<ObjectType,Transform> action)
    {
        action(WallType, transform);
    }
}
