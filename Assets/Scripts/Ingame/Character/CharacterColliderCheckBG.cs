using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColliderCheckBG : MonoBehaviour
{
    private CharacterControl characterControl;
    // Start is called before the first frame update
    void Awake()
    {
        characterControl = gameObject.GetComponentInParent<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        characterControl.isGround_ = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        characterControl.isGround_ = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        characterControl.isGround_ = false;
    }

}
