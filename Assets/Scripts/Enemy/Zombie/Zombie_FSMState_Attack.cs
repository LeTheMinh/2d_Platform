using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Zombie_FSMState_Attack : FSMState
{
    [NonSerialized]
    public ZombieControl parent;
    public override void OnEnter()
    {
        parent.dataBinding.Attack = true;
        base.OnEnter();
    }
    public override void OnMidleAnimationEvent()
    {
        AttackPlayer();
        parent.GotoState(parent.idleState);
    }
    public void AttackPlayer()
    {
        RaycastHit2D hit2d = Physics2D.Raycast(parent.anchorCheck.position, Vector3.right * parent.SideMove, 0.3f, parent.detectLayer);
        if (hit2d.collider!=null)
        {
            hit2d.collider.GetComponent<CharacterControl>().Ondamage(4);
        }
    }
}
