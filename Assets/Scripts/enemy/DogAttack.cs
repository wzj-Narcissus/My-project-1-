using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D dogCol;
    


    PlayerManager playerManager;


    public Transform target; // 玩家的Transform组件
    public float attackRange = 5.0f; // 敌人的攻击范围

    public float attackCooldown = 2.0f; // 攻击冷却时间
    private float nextAttackTime = 0.0f; // 下次可以攻击的时间

    public float Hp;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;


        playerManager=GameObject.Find("Player").GetComponent<PlayerManager>();


        dogCol = GetComponent<Collider2D>();//怪物碰撞体
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(dogCol, playerCol, true);


    }
    private void Update()
    {
        if(Hp<=0)Destroy(gameObject);
        if (playerManager.hasAttackTime <= 0)
        {
            Physics2D.IgnoreCollision(dogCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        // 检查玩家是否在攻击范围内
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            // 检查是否已经过了冷却时间
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                // 重置下次攻击时间
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            Physics2D.IgnoreCollision(dogCol, playerCol, false);
        }
    }

    private void AttackPlayer()
    {
        // 这里实现攻击逻辑，例如：
        // - 调用动画系统播放攻击动画
        // - 对玩家造成伤害
        //Debug.Log("敌人近战攻击玩家！");
        playerManager.GetDamaged(1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GetDamaged();
        }
    }

    private void GetDamaged()
    {
        if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
        {
            Hp -= playerManager.damage * playerManager.damageMulti;
        }
        else {
            Hp -= playerManager.damage * playerManager.damageMulti*2;
        }


    }
}