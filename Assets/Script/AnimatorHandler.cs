using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public bool IsAnimationPlaying(string animationName)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName);
    }

    public void Jump(bool jump)
    {
        _animator.SetBool("Jump", jump);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");        
    }
    public void Dead()
    {
        _animator.SetTrigger("Dead");
    }
    public void Move(float direction, bool move)
    {
        Flip(direction);
        _animator.SetBool("Move", move);
    }

    private void Flip(float direction)
    {
        Vector3 scala = transform.localScale;
        if (
            (direction < 0 && scala.x > 0) || (direction > 0 && scala.x < 0)
            )
        {
            scala.x *= -1;
        }    

        transform.localScale = scala;
    }
}

