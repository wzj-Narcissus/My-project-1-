using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class hedgehogAttack : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D birdCol;
    Collider2D edge;
    private Animator _Animator;


    PlayerManager playerManager;

    GameObject player;

    public float wantDistance;
    public float distance;
    public Vector2 direction;

    public bool flag;
    public float relaxTime;
    public float Hp;

    Rigidbody2D theRB;
    //public float AlarmTime;
    //public float alertRange;
    //public bool MoveOrNot;
    //private bool isAlert; // 是否处于戒备状态
    //private bool isRelax; // 是否处于放松状态
    //private float alertTimer; // 警戒计时器
    //public float alertDuration; // 警惕状态持续时间
    //private float relaxTimer; // 放松计时器
    //public float relaxDuration; // 放松状态持续时间
    private void Awake()
    {

        _Animator = GetComponent<Animator>();

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();


        birdCol = GetComponent<Collider2D>();//怪物碰撞体
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(birdCol, playerCol, true);

        Physics2D.IgnoreCollision(birdCol, edge, true);

        player = GameObject.Find("Player");
        theRB= GetComponent<Rigidbody2D>(); 
        


        //relaxDuration = 3.0f;
        //relaxTimer = 0;
        //isAlert = false;
        //isRelax = false;
        //alertTimer = 0;
        //alertDuration = 1.0f;
        //alertRange = 3.0f; // 警戒范围为3
        //MoveOrNot = true; // 设置本体可以移动
        //player = GameObject.Find("Player").transform;
    }
    public void SetHFalse()//将受击动画关闭函数
    {
        _Animator.SetBool("isHited", false);
    }
    private void Update()
    {
        if (playerManager.hasAttackTime <= 0 )
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, false);
        }

        direction = player.transform.position - transform.position;
        distance = direction.magnitude;
        if(distance< wantDistance&&relaxTime<=0)
        {
            GetAlarm();
        }
        if(distance> wantDistance&& relaxTime <= 0&&flag==true)
        {
            flag = false;
            _Animator.SetBool("isAttacking", false);
            relaxTime = 5;
        }
        if(relaxTime>0)relaxTime-=Time.deltaTime;
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
        //CheckPlayerProximity();
        //HandleState();
    }
    void GetAlarm()
    {
        flag = true;
        _Animator.SetBool("isAttacking", true);
    }

    //private void CheckPlayerProximity()
    //{
    //    // 检测玩家是否在警戒范围内，任何碰撞体与这个圆重合都会返回True
    //    if (Vector3.Distance(transform.position, player.position) <= alertRange)
    //    {
    //        // 如果玩家在范围内，设置戒备状态
    //        isAlert = true;
    //    }
    //    else
    //    {
    //        // 如果玩家不在范围内，设置放松状态
    //        isAlert = false;
    //    }
    //}

    //private void AlertState()
    //{
    //    //重新计时3s
    //    alertTimer = 0;
    //    MoveOrNot = false; // 对本体施加禁止移动
    //    // 进入戒备状态
    //    // 这里可以添加免疫伤害和反弹碰撞伤害的逻辑
    //    Debug.Log("hedgehog is now alert!");
    //}

    //private void RelaxState()
    //{
    //    MoveOrNot = true;// 对本体解除禁止移动
    //    Debug.Log("hedgehog is now relax!");
    //    // 这里可以添加豪猪可以受到伤害的逻辑，且受到伤害加1
    //}

    //private void HandleState()
    //{
    //    if (isAlert && !isRelax)
    //    {
    //        relaxTimer = 0;
    //        MoveOrNot = false;
    //        AlertState();// 进入警戒状态

    //    }
    //    else
    //    {
    //        alertTimer += Time.deltaTime; //警戒状态持续时间
    //        if (alertTimer >= alertDuration)
    //        {
    //            //警戒一段时间后放松，并在一定时间内不会警戒
    //            RelaxState();
    //            isRelax = true;
    //            relaxTimer += Time.deltaTime; //放松状态持续时间
    //            if (relaxTimer >= relaxDuration)
    //            {
    //                isRelax = false;// 放松时间结束，随时警戒！
    //            }
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flag == false&&relaxTime>0)
        {
            GetDamaged();
        }
        else if (relaxTime <= 0 && flag == true)
        {
            playerManager.GetDamaged(playerManager.damage);
        }
    }
    private void GetDamaged()
    {
        _Animator.SetBool("isHited", true);
        Invoke("SetHFalse", 0.3f);
        if (Random.Range(0, 100) > playerManager.monsterMissRate)
        {
            if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
            {
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti+1)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti-1;
            }
            else
            {
                if (playerManager.intMonsterShield < (playerManager.damage * playerManager.damageMulti+1) * 2)
                    Hp = Hp + playerManager.intMonsterShield - (playerManager.damage * playerManager.damageMulti+1) * 2;
            }
            if (Random.Range(0, 100) < playerManager.getMoneyRate)
            {
                playerManager.money++;
            }
        }


    }
}
