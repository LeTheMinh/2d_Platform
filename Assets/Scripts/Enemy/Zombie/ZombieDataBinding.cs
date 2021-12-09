using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDataBinding : MonoBehaviour
{
    public Animator animator;
    public float Speed
    {
        set
        {
            animator.SetFloat(AnimKey_Speed, value);
        }
    }
    public bool Attack
    {
        set
        {
            if(value)
            {
                animator.SetTrigger(AnimKey_Attack);
            }
        }
    }
    public bool Dead
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(AnimKey_Dead);
            }
        }
    }
    public bool Hurt
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(AnimKey_Hurt);
            }
        }
    }
    private int AnimKey_Speed;
    private int AnimKey_Dead;
    private int AnimKey_Hurt;
    private int AnimKey_Attack;
    // Start is called before the first frame update
    void Start()
    {
        AnimKey_Speed = Animator.StringToHash("Speed");
        AnimKey_Dead = Animator.StringToHash("Dead");
        AnimKey_Hurt = Animator.StringToHash("Hurt");
        AnimKey_Attack = Animator.StringToHash("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
