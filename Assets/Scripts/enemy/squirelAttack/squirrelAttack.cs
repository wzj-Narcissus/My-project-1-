using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrelAttack : MonoBehaviour
{

    Collider2D playerCol;
    Collider2D squirrelCol;
    Collider2D edge;
    PlayerManager playerManager;
    private Animator _Animator;




    public float Hp;




    public GameObject BulletPrefab;
    private bool isRight = true;
    private bool isUp = false;
    public Transform target; // 目标物体的Transform组件
    public float horizontalDifference; //判断与玩家的水平位置差
    public float verticalDifference; //判断与玩家的水平位置差
    public float interval = 4f; // 攻击间隔
    public float Attime;//攻击时间

    public Vector2 direction;


    private void Awake()
    {

        _Animator = GetComponent<Animator>();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        squirrelCol = GetComponent<Collider2D>();//怪物碰撞体
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
        Physics2D.IgnoreCollision(squirrelCol, edge, true);



        Hp = Hp *playerManager.monsterHealth;


        target = GameObject.Find("Player").transform; //获取玩家位置，注意大小写
    }
    public void SetAFalse()//将攻击动画关闭函数
    {
        _Animator.SetBool("isAttacking", false);
    }
    public void SetHFalse()//将受击动画关闭函数
    {
        _Animator.SetBool("isHited", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.hasAttackTime <= 0 )
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, false);
        }




        if(Hp<=0)Destroy(gameObject);


        //执行发射
        Shoot();
    }
    void Shoot()
    {
        // 冷却时间满后进行攻击
        if ((Time.time - Attime) >= interval)
        {
            _Animator.SetBool("isAttacking", true);
            Invoke("SetAFalse", 0.1f);
            //创建子弹预制体
            GameObject bulletObj = Instantiate(BulletPrefab);
            bulletObj.transform.position = transform.position;
            Attime = Time.time;
            //设置子弹方向，获取玩家方位
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            //CheckRelativePosition();
            //if (horizontalDifference* horizontalDifference < verticalDifference* verticalDifference)
            //{
            //    if (isUp)
            //        bullet.SetDirection(Vector2.down);
            //    else bullet.SetDirection(Vector2.up);
            //}
            //else
            //{
            //    if (isRight)
            //        bullet.SetDirection(Vector2.left);
            //    else bullet.SetDirection(Vector2.right);
            //}
            direction=target.position-gameObject.transform.position;
            bullet.SetDirection(direction);


        }
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="player") 
        {
            GetDamaged();
            _Animator.SetBool("isHited", true);
            Invoke("SetHFalse", 0.2f);
        }
    }
    private void GetDamaged()
    {
        if (Random.Range(0, 100) > playerManager.monsterMissRate)
        {
            if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
            {
                if(playerManager.intMonsterShield< playerManager.damage * playerManager.damageMulti)
                Hp = Hp+ playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti;
            }
            else
            {
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti*2)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti*2;
            }
            if (Random.Range(0, 100) < playerManager.getMoneyRate)
            {
                playerManager.money++;
            }
        }


    }




    //void CheckRelativePosition()
    //{
    //    // 获取两个物体的世界位置
    //    Vector3 thisPosition = transform.position;
    //    Vector3 targetPosition = target.position;

    //    // 计算两个物体之间的相对位置
    //    horizontalDifference = thisPosition.x - targetPosition.x;
    //    verticalDifference = thisPosition.y - targetPosition.y;

    //    // 根据相对位置更新isRight和isUp的值
    //    isRight = horizontalDifference > 0;
    //    isUp = verticalDifference > 0;
    //}
}
