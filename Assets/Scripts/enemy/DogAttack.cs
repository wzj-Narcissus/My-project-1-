using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    public Transform target; // 玩家的Transform组件
    public float attackRange = 5.0f; // 敌人的攻击范围
    public float attackCooldown = 2.0f; // 攻击冷却时间
    private float nextAttackTime = 0.0f; // 下次可以攻击的时间
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
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
    }

    private void AttackPlayer()
    {
        // 这里实现攻击逻辑，例如：
        // - 调用动画系统播放攻击动画
        // - 对玩家造成伤害
        Debug.Log("敌人近战攻击玩家！");
    }
}