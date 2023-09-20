using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHitForceable
{
    void GetHitForceController(float jumpForce, float returnForce, EnemyController enemyController, Rigidbody rigidbody, Transform ballTransform,
                               Transform enemyTransform, EnemyActiveController enemyActive, float moveSpeed, float minJump, float maxJump, float minReturn, float maxReturn);
}

public interface IEnemyPatrolable
{
    void GetPatrolController(float enemySpeed, ref int pointIndex, bool isPatrol);
    void SetPatrolParameters(List<Transform> patrolPoint, Transform enemyTransfom, float enemyMagnitude);
}

public interface IEnemyOverlapable
{
    void GetOverlapController(Vector3 overlapScale, LayerMask enemyLayer, ref bool inside, Transform carPos, float enemyMoveSpeed, ref bool isPatrol);
    void SetOverlapParameters(Transform enemyCar, float rotateSpeed);
}
