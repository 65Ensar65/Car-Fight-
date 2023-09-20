using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForceHitController : IEnemyHitForceable
{
    public void GetHitForceController(float jumpForce, float returnForce, EnemyController enemyController, Rigidbody rigidbody,
                                      Transform ballTransform, Transform enemyTransform, EnemyActiveController enemyActive, float moveSpeed, float minJump, float maxJump, float minReturn, float maxReturn)
    {
        if (ballTransform != enemyTransform.GetChild(1).GetComponent<EnemyActiveController>().EnemyBall)
        {
            moveSpeed = 0;
            Debug.Log(ballTransform);

            // Rastgele jumpForce ve returnForce seç
            jumpForce = Random.Range(minJump, maxJump);
            returnForce = Random.Range(minReturn, maxReturn);

            // Yukarýya doðru zýplama kuvvetini uygula
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Geri hareketi doðru yönde uygula
            Vector3 impactDirection = (ballTransform.position - enemyTransform.position).normalized;
            rigidbody.AddForce(-impactDirection * returnForce, ForceMode.Impulse);

            // Diðer iþlemleri buraya ekleyin

            GameManager.Instance.GetPlayerControllerActive();
            enemyActive.GetActiveEnemyCar();
            enemyController.enabled = false;
        }
    }
}
