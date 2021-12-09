using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBinding : MonoBehaviour
{
    public Animator animator;
    private int animKey_Speed;
    private int animKey_Jump;
    private int animKey_IsGround;
    private int animKey_Attack;
    private int animKey_Dead;
    private int animKey_Hurt;
    public float Speed
    {
        set
        {
            animator.SetFloat(animKey_Speed, Mathf.Abs(value));
        }
    }
    public float Jump
    {
        set
        {
            float jump = Mathf.Clamp(value,-3, 3);
            animator.SetFloat(animKey_Jump, jump);
        }
    }
    public bool IsGround
    {
        set
        {
            animator.SetBool(animKey_IsGround, value);
        }
    }
    public bool Attack
    {
        set
        {
            if(value)
            {
                animator.SetTrigger(animKey_Attack);

            }
        }
    }
    public bool Dead
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(animKey_Dead);

            }
        }
    }
    public bool Hurt
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(animKey_Hurt);

            }
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        animKey_Speed = Animator.StringToHash("Speed");//bien doi thanh kieu int lam giam hit performance
        animKey_Jump = Animator.StringToHash("Jump");
        animKey_IsGround = Animator.StringToHash("IsGround");
        animKey_Attack = Animator.StringToHash("Attack");
        animKey_Dead = Animator.StringToHash("Dead");
        animKey_Hurt = Animator.StringToHash("Hurt");
    }
    public void SwitchAnimatorControler(AnimatorOverrideController animatorOverrideController)
    {
        animator.runtimeAnimatorController = animatorOverrideController;
    }
}
