using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Transform model;
    public CharacterDataBinding dataBiding;
    private float g = -9.81f;
    private float a = -5f;
    private float velocity_Y = 0;
    private float velocity_X = 0;
    public float forceJump = 3.5f;
    public float speedMove = 2;
    private Transform trans;
    public Transform anchorFootDown;
    public Transform sideCheck;
    public bool isGround_;
    private float timeDelayJump;
    private float side = 1;
    public LayerMask bg_Layer;
    public LayerMask enemy_Layer;
    public Vector3 dirMove;
    public AnimatorOverrideController[] animatorOverrideControllers;
    // Start is called before the first frame update
    public void Awake()
    {
        
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            dataBiding.SwitchAnimatorControler(animatorOverrideControllers[0]);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            dataBiding.SwitchAnimatorControler(animatorOverrideControllers[1]);
        }
        
        isGround_ = isGround();
        if(InputManager.isAttack&&isGround_)
        {
            AttackEnemy();
            return;
        }
        float speed = InputManager.speedMove;

        Flip(speed);
        //move...
        //x=x0 + v0*t+0.5f* a*t*t
        //v=v0+ a*t
        
        float t = Time.deltaTime;
        timeDelayJump += t;
        //horizontal
        if(Mathf.Abs(speed)>0)
        {
            velocity_X = 1.5f;
        }
        Vector3 pos = transform.position;
        float posx = pos.x;
        if (!isGround_)
        {
            posx = pos.x + (velocity_X * t + a * t * t * 0.5f)*side;
        }
        else
        {
            posx = pos.x + speed * t * speedMove;
        }
        if (!IsSide(posx))
        {
            pos.x = posx;
        }

        velocity_X = velocity_X + a * t;
        if(velocity_X<0)
        {
            velocity_X = 0;
        }
        //vertical
        
        if(!isGround_)
        {
            pos.y = pos.y + velocity_Y * t + g * t * t * 0.5f;
            velocity_Y = velocity_Y + g * t;
        }
        
        trans.position = pos;
        if (InputManager.isJump&&isGround_)
        {
            timeDelayJump = 0;
            velocity_Y = forceJump;
        }
        //anim
        dataBiding.Speed = speed;
        dataBiding.Jump = velocity_Y;
        dataBiding.IsGround = isGround_;
    }
    private bool isGround()
    {
        if(timeDelayJump < 0.2f)
        {
            return false;
        }
        if(velocity_Y<=0)
        {
            //RaycastHit2D hit2d = Physics2D.Raycast(anchorFootDown.position, Vector2.down, 0.1f, bg_Layer);
            Collider2D col = Physics2D.OverlapCircle(anchorFootDown.position, 0.05f,bg_Layer);
            if (col != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
        
    }
    private bool IsSide(float Posx)
    {
        Vector3 posMove = new Vector3(Posx, sideCheck.position.y, sideCheck.position.z);
        dirMove = posMove - sideCheck.position;
        dirMove.Normalize();
        
        RaycastHit2D hit2D = Physics2D.Raycast(sideCheck.position, dirMove, 0.1f,bg_Layer);
        
        if (hit2D.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Flip(float speed)
    {
        if(Mathf.Abs(speed)>0)
        {
            side = speed > 0 ? 1 : -1;
            model.localScale = new Vector3(side, 1, 1);
        }
        
    }
    private void AttackEnemy()
    {
        dataBiding.Attack = true;
        dirMove = sideCheck.position - anchorFootDown.position;
        RaycastHit2D hit2D = Physics2D.Raycast(sideCheck.position, dirMove, 0.5f, enemy_Layer);
        if (hit2D.collider != null)
        {
            //hit2D.collider.GetComponent<EnemyControl>().OnDamage(new EnemyGetHitData { damage = 5 });
            EnemyGetHitData dataHit = new EnemyGetHitData();
            dataHit.damage = 5;
            hit2D.collider.GetComponent<EnemyControl>().OnDamage(dataHit);
        }
        
    }
    public void Ondamage(int damage)
    {
        Debug.LogError(" damage : " + damage);
    }
}
