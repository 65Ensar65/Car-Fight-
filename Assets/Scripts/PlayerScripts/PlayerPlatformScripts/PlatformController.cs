using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : Base, IInteract
{
    public ObjectType PlatformType;
    public void Interact(ObjectType type, Transform transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                action.Invoke(PlatformType, transform);
                break;
            default:
                break;
        }
    }
}
