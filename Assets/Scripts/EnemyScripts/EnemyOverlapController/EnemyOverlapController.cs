using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOverlapController : IEnemyOverlapable
{
    private Transform _enemyCar;
    private float _rotateSpeed;

    public void GetOverlapController(Vector3 overlapScale, LayerMask enemyLayer, ref bool inside, Transform carPos, float enemyMoveSpeed, ref bool isPatrol)
    {
        Vector3 carPosition = carPos.position;

        bool isInside = Physics.CheckBox(carPosition, overlapScale, Quaternion.identity, enemyLayer);

        if (!inside && isInside)
        {
            carPos.GetComponent<EnemyController>().enabled = false;
            carPos.GetComponent<CarRotate>().enabled = true;
        }

        else if (inside && !isInside)
        {
            carPos.GetComponent<EnemyController>().enabled = true;
            carPos.GetComponent<CarRotate>().enabled = false;
        }

        inside = isInside;
    }

    public void SetOverlapParameters(Transform enemyCar, float rotateSpeed)
    {
        _enemyCar = enemyCar;
        _rotateSpeed = rotateSpeed;
    }
}

