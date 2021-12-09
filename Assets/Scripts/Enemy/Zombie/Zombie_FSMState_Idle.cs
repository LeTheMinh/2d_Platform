using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Zombie_FSMState_Idle : FSMState
{
    [NonSerialized]
    public ZombieControl parent;
    private float timeCount;
    private float timeLife;
    public override void OnEnter()
    {
        timeCount = 0;
        timeLife = UnityEngine.Random.Range(1f, 5f);
        base.OnEnter();
    }
    public override void OnFixedUpdate()
    {
        timeCount += Time.deltaTime;
        if(timeCount>=timeLife)
        {
            parent.GotoState(parent.walkState);
        }
        
    }
}
