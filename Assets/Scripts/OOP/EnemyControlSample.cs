using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlSample : MonoBehaviour
{
    public string nameEnemy;
    private int hp;

    //dong goi
    public int Hp
    {
        get
        {
            return hp;
        }
        private set
        {
            hp = value;
        }
    }
    // Start is called before the first frame update
    public virtual void Setup(int hp)
    {
        Debug.Log("I am enemy");
    }
}
