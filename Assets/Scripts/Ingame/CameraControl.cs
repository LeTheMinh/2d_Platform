using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform target;
    private Transform trans;
    public float SpeedMove = 3;
    public Transform Limit_Min_X;
    public Transform Limit_Max_X;
    public Transform Limit_Min_Y;
    public Transform Limit_Max_Y;
    public float margin_X;
    public float margin_Y;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        trans = transform;
    }

    private bool IsMarginX()
    {
        if (trans.position.x + margin_X < target.position.x || trans.position.x - margin_X > target.position.x)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool IsMarginY()
    {
        if (trans.position.y + margin_Y < target.position.y || trans.position.y - margin_Y > target.position.y)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void LateUpdate()
    {
        Vector3 posMove = trans.position;
        Vector3 pos = target.position;
        pos.z = trans.position.z;
        if (!IsMarginX())
        {
            posMove.x = pos.x;
        }
        if (!IsMarginY())
        {
            posMove.y = pos.y;
        }
        posMove.x = Mathf.Clamp(posMove.x, Limit_Min_X.position.x, Limit_Max_X.position.x);
        posMove.y = Mathf.Clamp(posMove.y, Limit_Min_Y.position.y, Limit_Max_Y.position.y);
        trans.position = Vector3.Lerp(trans.position, posMove, Time.deltaTime * SpeedMove);
    }
}
