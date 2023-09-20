using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationExtantion
{
    public static void PlayAnim(this Transform _transform, int _animstate)
    {
        Animator animator = _transform.GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetInteger("animState", _animstate);
        }
    }
}
public enum EnemyCarAnim
{
    IDLE,
    ROTATE
}


