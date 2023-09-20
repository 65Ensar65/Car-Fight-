using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolController : IEnemyPatrolable
{
    private List<Transform> _patrolPoint;
    private Transform _enemyTransform;
    private float _enemyMagnitude;
    private int _currentIndex;

    public void GetPatrolController(float enemySpeed, ref int pointIndex, bool isPatrol)
    {
        if (isPatrol)
        {
            if (enemySpeed != 0 && _patrolPoint.Count > 0)
            {
                Vector3 targetPosition = _patrolPoint[_currentIndex].position;
                float distance = Vector3.Distance(_enemyTransform.position, targetPosition);

                if (distance > _enemyMagnitude)
                {
                    _enemyTransform.position = Vector3.Lerp(_enemyTransform.position, targetPosition, enemySpeed / distance);
                    _enemyTransform.DOLookAt(targetPosition, 1f);
                }
                else
                {
                    _currentIndex = (_currentIndex + 1) % _patrolPoint.Count;
                }
            }
        }
    }

    public void SetPatrolParameters(List<Transform> patrolPoint, Transform enemyTransform, float enemyMagnitude)
    {
        _patrolPoint = patrolPoint;
        _enemyTransform = enemyTransform;
        _enemyMagnitude = enemyMagnitude;
        _currentIndex = 0;
    }
}
