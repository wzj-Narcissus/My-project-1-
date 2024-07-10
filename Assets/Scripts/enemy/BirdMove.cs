using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    BirdAttack1 attack;
    public float distance;
    public Transform target;// 要接近的目标物体的Transform组件
    public float speed = 0.01f; // 接近目标的速度
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        attack = GetComponent<BirdAttack1>();
    }

    private void Update()
    {
        if (attack.hasRushTime > 0)
        {
            attack.hasRushTime -= Time.deltaTime;
        }
        else
        {
            if (target != null)
            {
                // 计算当前物体与目标物体之间的距离
                Vector3 direction = target.position - transform.position;
                distance = direction.magnitude;

                // 如果距离小于一定值，则停止移动
                if (distance < 0.1f)
                {
                    return;
                }

                // 计算移动方向
                Vector3 moveDirection = direction.normalized;

                // 根据速度和时间更新位置
                transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
    }
}
