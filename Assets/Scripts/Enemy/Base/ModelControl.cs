using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelControl : MonoBehaviour
{
    private FSMSystem fSMSystem;
    // Start is called before the first frame update
    void Start()
    {
        fSMSystem = gameObject.GetComponentInParent<FSMSystem>();   
    }

    public void OnMidleAnimationEvent()
    {
        fSMSystem.OnMidleAnimationEvent();
    }
}
