using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : Base,IInteract
{
    public ObjectType AirDropType;
    public void Interact(ObjectType type, Transform transform, System.Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                action.Invoke(AirDropType, transform);
                GetReturnController();
                break;
            case ObjectType.Enemy1:
                action.Invoke(AirDropType, transform);
                GetReturnController();
                break;
            case ObjectType.Enemy2:
                action.Invoke(AirDropType, transform);
                GetReturnController();
                break;
            case ObjectType.Enemy3:
                action.Invoke(AirDropType, transform);
                GetReturnController();
                break;
            case ObjectType.Enemy4:
                action.Invoke(AirDropType, transform);
                GetReturnController();
                break;
            default:
                break;
        }
    }

    void GetReturnController()
    {
        if (AirDropType == ObjectType.AirTurretDrop)
        {
            e_objectPool.ReturnPoolObject(ObjectTag.AirTurretDrops, gameObject);
        }

        else if (AirDropType == ObjectType.AirBallDrop)
        {
            e_objectPool.ReturnPoolObject(ObjectTag.AirBallDrops, gameObject);
        }
    }
}
