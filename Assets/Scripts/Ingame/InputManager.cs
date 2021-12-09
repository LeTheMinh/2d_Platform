using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float speedMove;
    public static bool isJump;
    public static bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");//|0->1|
        speedMove = x;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;

        }
        else
        {
            isJump = false;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
    }
}
