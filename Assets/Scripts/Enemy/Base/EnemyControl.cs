using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyDataSetup
{

}
public class EnemyGetHitData
{
    public int damage;
}
public class EnemyControl : FSMSystem
{
    [NonSerialized]
    public Transform trans;
    private int currentHP_;
    public int CurrentHP
    {
        set
        {
            currentHP_ = value;
            if(currentHP_<=0)
            {
                isAlive = false;
            }
            else
            {
                isAlive = true;
            }
        }
        get
        {
            return currentHP_;
        }
    }
    private bool isAlive;
    public bool IsAlive
    {
        get
        {
            return  isAlive;
        }
    }
    private void Start()
    {
        trans = transform;
        Setup(null);
    }
    public virtual void Setup(EnemyDataSetup enemyDataSetup)
    {
        CurrentHP = 10;
    }
    public virtual void OnDamage(EnemyGetHitData data)
    {

    }

    public void OnDead()
    {
        Destroy(gameObject);
    }
}
