using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitForceController : IPlayerHitForceable
{
    public void GetHitForceController(float jumpForce, float returnForce, PlayerController playerController, Rigidbody rigidbody, Transform ballTransform, Transform playerTransform,
                                      float minJump, float maxJump, float minReturn, float maxReturn)
    {
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
        jumpForce = Random.Range(minJump, maxJump);
        returnForce = Random.Range(minReturn, maxReturn);

        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        Vector3 impactDirection = (playerTransform.position - ballTransform.position).normalized;  
        rigidbody.AddForce(impactDirection * returnForce, ForceMode.Impulse);
        GameManager.Instance.GetPlayerControllerActive();
        playerController.enabled = false;
    }

}
