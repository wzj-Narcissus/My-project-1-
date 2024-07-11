using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private SpriteRenderer _Sr;//设置渲染器变量
    DogAttack attack;
    public float distance;
    Rigidbody2D theRB;
    public Transform target;// 要接近的目标物体的Transform组件
    public float speed = 0.01f; // 接近目标的速度
    private void Awake()
    {
        _Sr = GetComponent<SpriteRenderer>();//获取渲染器图片
        target = GameObject.Find("Player").transform;
        attack = GetComponent<DogAttack>();
        theRB = GetComponent<Rigidbody2D>();
    }
    void Flip(float x)//用于反转图片
    {
        if (x > 0)
        {
            _Sr.flipX = true;
        }

        if (x < 0)
        {
            _Sr.flipX = false;
        }
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
                Flip(direction.x);//随时反转图片




                // 如果距离小于一定值，则停止移动
                //if (distance < 0.1f)
                //{
                //    return;
                //}

                //// 计算移动方向
                Vector3 moveDirection = direction.normalized;
                theRB.velocity = moveDirection * speed;
                //// 根据速度和时间更新位置
                //transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
    }
}
