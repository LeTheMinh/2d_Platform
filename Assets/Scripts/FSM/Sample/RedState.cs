using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class RedState : FSMState
{
    [NonSerialized]
    public TrafficLight parent;
    public float timeCout;
    public float timeLife = 0;
    public override void OnEnter(object data)
    {
        timeLife = (float)data;
        timeCout = 0;
        parent.lightImage.color = Color.red;

    }
    public override void OnUpdate()
    {
        timeCout += Time.deltaTime;
        if (timeCout > timeLife)
        {
            parent.GotoState(parent.greenState);
        }
    }
}


