using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Zombie_FSMState_Walk : FSMState
{
    [NonSerialized]
    public ZombieControl parent;
    private float timeCount;
    private float timeLife;
    public float speedMove = 1.2f;
    public LayerMask bgLayer;
    public override void OnEnter()
    {
        parent.dataBinding.Speed = 1;
        timeCount = 0;
        timeLife = UnityEngine.Random.Range(1f, 5f);
        base.OnEnter();
    }
    public override void OnFixedUpdate()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= timeLife)
        {
            parent.GotoState(parent.idleState);
        }
    }
    public override void OnUpdate()
    {
        RaycastHit2D hit2d = Physics2D.Raycast(parent.anchorCheck.position, Vector3.right * parent.SideMove, 0.2f,bgLayer);
        if(hit2d.collider != null)
        {
            parent.SideMove = parent.SideMove * -1;
        }
        parent.trans.position = Vector3.Lerp(parent.trans.position, parent.trans.position + Vector3.right * parent.SideMove, Time.deltaTime*speedMove);
        base.OnUpdate();
    }
    public override void OnExit()
    {
        parent.dataBinding.Speed = 0;
        base.OnExit();
    }
}
