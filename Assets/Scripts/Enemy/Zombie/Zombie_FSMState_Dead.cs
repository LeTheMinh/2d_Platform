using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Zombie_FSMState_Dead : FSMState
{
    [NonSerialized]
    public ZombieControl parent;
    public override void OnEnter()
    {
        parent.dataBinding.Dead = true;
        base.OnEnter();
    }
    public override void OnMidleAnimationEvent()
    {
        parent.OnDead();
        base.OnMidleAnimationEvent();
    }
}
