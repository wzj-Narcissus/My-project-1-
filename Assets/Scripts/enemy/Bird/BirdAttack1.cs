using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack1 : MonoBehaviour
{

    Collider2D playerCol;
    Collider2D birdCol;
    Collider2D edge;
    private Animator _Animator;


    PlayerManager playerManager;

    public bool flag;
    public float hasGetDamageTime;
    public Vector2 direction;
    public float rushSpeed;
    public float hasRushTime;
    public float rushTime;
    Rigidbody2D theRB;
    public float skillTime;
    public float hasSkillTime;
    BirdMove birdMove;
    public float attackDistance;
    public float healthTime;


    public Transform target; // 玩家的Transform组件
    public float attackRange = 5.0f; // 敌人的攻击范围

    public float attackCooldown = 2.0f; // 攻击冷却时间
    //private float nextAttackTime = 0.0f; // 下次可以攻击的时间

    public float Hp;

    private void Awake()
    {
        _Animator = GetComponent<Animator>();

        target = GameObject.Find("Player").transform;
        flag = false;
        birdMove=GetComponent<BirdMove>();

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();


        birdCol = GetComponent<Collider2D>();//怪物碰撞体
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(birdCol, playerCol, true);
        theRB = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(birdCol, edge, true);
        Hp *= playerManager.monsterHealth;
    }
    public void SetAFalse()//将攻击动画关闭函数
    {
        _Animator.SetBool("isAttacking", false);
    }
    public void SetHFalse()//将受击动画关闭函数
    {
        _Animator.SetBool("isHited", false);
    }
    private void Update()
    {
        if(healthTime>0)
        {
            healthTime-= Time.deltaTime;
        }
        if (Hp <= 0) Destroy(gameObject);
        if (playerManager.hasAttackTime <= 0 && hasRushTime <= 0)
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }


        if (hasSkillTime <= 0)
        {
            if (birdMove.distance < attackDistance)
            {
                flag = true;
                hasGetDamageTime = 0.5f;
                hasSkillTime = skillTime;
            }
        }

        else
        {
            hasSkillTime -= Time.deltaTime;
        }
        
        if (flag == true)
        {
            if (hasGetDamageTime > 0)
            {
                hasGetDamageTime -= Time.deltaTime;
            }

            else
            {
                hasRushTime = rushTime;
                direction = new Vector2(playerManager.transform.position.x - transform.position.x, playerManager.transform.position.y - transform.position.y);
                Physics2D.IgnoreCollision(birdCol, playerCol, false);
                theRB.velocity = direction.normalized * rushSpeed;
                flag = false;
                _Animator.SetBool("isAttacking", true);
                Invoke("SetAFalse", 0.3f);

                //if (Vector3.Distance(transform.position, target.position) <= attackRange)
                //{
                //    // 检查是否已经过了冷却时间
                //    if (Time.time >= nextAttackTime)
                //    {
                //        AttackPlayer();
                //        // 重置下次攻击时间
                //        nextAttackTime = Time.time + attackCooldown;
                //    }
                //}
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, false);
        }
    }

    //private void AttackPlayer()
    //{
    //    // 这里实现攻击逻辑，例如：
    //    // - 调用动画系统播放攻击动画
    //    // - 对玩家造成伤害
    //    //Debug.Log("敌人近战攻击玩家！");
    //    playerManager.GetDamaged(1);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && hasRushTime > 0)
        {
            if (healthTime > 0)
            {

            }
            else
            {
                playerManager.GetDamaged(1+ playerManager.inthurt);
                healthTime = 0.5f;
                //Debug.Log("11");
            }
        }
        else if (collision.gameObject.tag == "player" && hasRushTime <= 0 && hasGetDamageTime <= 0)
        {
            GetDamaged();
            //flag = true;
            //hasGetDamageTime = 0.5f;
        }
        else if (collision.gameObject.tag == "player")
        {

            GetDamaged();
            GetDamaged();
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
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti;
            }
            else
            {
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti * 2)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti * 2;
            }
            if (Random.Range(0, 100) < playerManager.getMoneyRate)
            {
                playerManager.money++;
            }
        }


    }
}
