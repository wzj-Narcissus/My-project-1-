using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack1 : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    public float attackRange = 5.0f; // 攻击范围
    public float chargeTime = 0.5f; // 蓄力时间
    public float attackSpeed = 5.0f; // 冲刺速度
    public float attackDuration = 1.0f; // 冲刺持续时间
    public float cooldownTime = 5.0f; // 技能冷却时间
    private float nextAttackTime; // 下次可以攻击的时间
    private float attackStartTime;
    private Vector3 direction;
    public float MoveSpeed;  //控制蓄力时禁止移动
    private bool isCharging = false; // 是否正在蓄力
    private bool isAttacking = false; // 是否正在攻击
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        // 检查是否到了可以再次使用技能的时间
        if (Time.time >= nextAttackTime)
        {
            // 检测玩家是否在攻击范围内
            if (Vector3.Distance(transform.position, player.position) <= attackRange &&
                !isCharging &&
                !isAttacking)
            {
                StartCharging();
            }
        }

        // 检查蓄力是否完成并开始攻击
        if (isCharging && (Time.time - attackStartTime) >= chargeTime)
        {
            PerformAttack();
        }

        // 如果正在攻击，检查攻击是否结束
        if (isAttacking && (Time.time - nextAttackTime) >= attackDuration)
        {
            EndAttack();
        }
    }

    void StartCharging()
    {
        if (Time.time >= nextAttackTime) // 确保技能不在冷却中
        {
            
            isCharging = true;
            nextAttackTime = Time.time + cooldownTime; // 设置技能冷却时间
            attackStartTime = Time.time;
            // 可以在这里添加蓄力的动画和音效
            Debug.Log("鸟正在蓄力！"); 
            enemyMovement scriptB = GetComponent<enemyMovement>();
            MoveSpeed = scriptB.speed;
            scriptB.speed = 0;
        }
    }

    void PerformAttack()
    {
        isCharging = false;
        isAttacking = true;
        // 向玩家方向冲刺
        Vector3 direction = (player.position - transform.position).normalized;
        // 可以在这里添加冲刺的动画和音效
        // 这里可以添加移动逻辑，例如：
        StartCoroutine(MoveTowardsPlayer(direction)); 
        Debug.Log("鸟正在攻击！"); 
        enemyMovement scriptB = GetComponent<enemyMovement>();
        scriptB.speed = MoveSpeed;

    }

    IEnumerator MoveTowardsPlayer(Vector3 direction)
    {
        float travelTime = 0;
        while (travelTime < attackDuration)
        {
            transform.position += direction * attackSpeed * Time.deltaTime;
            travelTime += Time.deltaTime;
            yield return null;
        }
    }

    void EndAttack()
    {
        isAttacking = false;
        // 可以在这里添加攻击结束的动画和音效
    }

    void OnCollisionEnter(Collision collision)
    {
        // 检查是否在蓄力期间受到碰撞
        if (isCharging)
        {
            Die();
        }
    }

    void Die()
    {
        // 杀死怪物的逻辑，例如播放死亡动画，然后销毁
        Debug.Log("鸟在蓄力期间受到碰撞，死亡！");
        // 可以在这里添加死亡动画和音效
        Destroy(gameObject);
    }
}
