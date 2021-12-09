using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Zombie_FSMState_Hurt : FSMState
{
    [NonSerialized]
    public ZombieControl parent;
    public override void OnEnter()
    {
        parent.dataBinding.Hurt = true;
        base.OnEnter();
    }
    public override void OnEnter(object data)
    {
        base.OnEnter(data);
    }
    public override void OnMidleAnimationEvent()
    {
        parent.GotoState(parent.idleState);
    }
}

