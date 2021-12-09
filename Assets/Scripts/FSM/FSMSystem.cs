using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    public FSMState currentState;
    public void GotoState(FSMState newState)
    {
        if(currentState!=null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }

    public void GotoState(FSMState newState,object data)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter(data);
    }

    private void Update()
    {
        if(currentState!=null)
        {
            currentState.OnUpdate();
        }
        OnSystemUpdate();
    }
    private void LateUpdate()
    {
        if(currentState!=null)
        {
            currentState.OnLateUpdate();
        }
        OnSystemLateUpdate();
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.OnFixedUpdate();
        }
        OnSystemFixedUpdate();
    }
    public virtual void OnSystemUpdate() { }
    public virtual void OnSystemLateUpdate() { }
    public virtual void OnSystemFixedUpdate() { }
    public void OnMidleAnimationEvent()
    {
        currentState?.OnMidleAnimationEvent();
    }
}
