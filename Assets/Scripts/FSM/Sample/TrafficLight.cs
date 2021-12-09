using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrafficLight : FSMSystem
{
    public Image lightImage;
    public GreenState greenState;
    public RedState redState;
    private void Start()
    {
        greenState.parent = this;
        redState.parent = this;
        GotoState(greenState);
    }
}
