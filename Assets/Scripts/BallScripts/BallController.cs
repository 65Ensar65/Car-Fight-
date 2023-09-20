using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : Base, IInteract
{
    public ObjectType BallType;
    public void GetBallScaleController()
    {
        Invoke(nameof(SetBallScale), 4);
    }

    void SetBallScale()
    {
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .3f);
    }

    public void Interact(ObjectType type, Transform transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                action.Invoke(BallType, transform);
                break;
            case ObjectType.Enemy1:
                action.Invoke(BallType, transform);
                break;
            case ObjectType.Enemy2:
                action.Invoke(BallType, transform);
                break;
            case ObjectType.Enemy3:
                action.Invoke(BallType, transform);
                break;
            case ObjectType.Enemy4:
                action.Invoke(BallType, transform);
                break;
            default:
                break;
        }
    }
}
