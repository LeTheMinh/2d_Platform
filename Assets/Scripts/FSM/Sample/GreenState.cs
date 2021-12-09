using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class GreenState : FSMState
{
    [NonSerialized]
    public TrafficLight parent;
    public float timeCout;
    public override void OnEnter()
    {
        timeCout = 0;
        parent.lightImage.color = Color.green;
        
    }
    public override void OnUpdate()
    {
        timeCout += Time.deltaTime;
        if(timeCout>5)
        {
            parent.GotoState(parent.redState,3f);
        }
    }
}
