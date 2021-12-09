using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : EnemyControl
{
    public ZombieDataBinding dataBinding;
    public Zombie_FSMState_Attack attackState;
    public Zombie_FSMState_Dead deadState;
    public Zombie_FSMState_Hurt hurtState;
    public Zombie_FSMState_Idle idleState;
    public Zombie_FSMState_Walk walkState;
    private  float sideMove;
    public LayerMask detectLayer;
    public Transform anchorCheck;

    public float SideMove
    {
        set
        {
            model.localScale = new Vector3(-value, 1, 1);
            sideMove = value;
        }
        get
        {
            return sideMove;
        }
        
    }
    [SerializeField]
    public Transform model;
    public override void Setup(EnemyDataSetup enemyDataSetup)
    {
        base.Setup(enemyDataSetup);
        attackState.parent = this;
        deadState.parent = this;
        hurtState.parent = this;
        idleState.parent = this;
        walkState.parent = this;
        SideMove = 1;
        GotoState(idleState);
    }
    public override void OnSystemFixedUpdate()
    {
        if(currentState==walkState||currentState==idleState)
        {
            RaycastHit2D hit2d = Physics2D.Raycast(anchorCheck.position, Vector3.right * SideMove, 0.3f, detectLayer);
            if (hit2d.collider != null)
            {
                GotoState(attackState);
            }
        }
        
    }
    public override void OnDamage(EnemyGetHitData data)
    {
        if(!IsAlive)
        {
            return;
        }
        CurrentHP -= data.damage;
        if(CurrentHP<=0)
        {
            GotoState(deadState);
        }
        else
        {
            if(currentState!=hurtState)
            {
                GotoState(hurtState);
            }
            else
            {
                GotoState(hurtState, 0);
            }
        }
    }
}
