using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrelAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    private bool isRight = true;
    private bool isUp = false;
    public Transform target; // 目标物体的Transform组件
    public float horizontalDifference; //判断与玩家的水平位置差
    public float verticalDifference; //判断与玩家的水平位置差
    public float interval = 4f; // 攻击间隔
    public float Attime;//攻击时间

    private void Awake()
    {
        target = GameObject.Find("Player").transform; //获取玩家位置，注意大小写
    }

    // Update is called once per frame
    void Update()
    {
        //执行发射
        Shoot();
    }
    void Shoot()
    {
        // 冷却时间满后进行攻击
        if ((Time.time - Attime) >= interval)
        {
            //创建子弹预制体
            GameObject bulletObj = Instantiate(BulletPrefab);
            bulletObj.transform.position = transform.position;
            Attime = Time.time;
            //设置子弹方向，获取玩家方位
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            CheckRelativePosition();
            if (horizontalDifference* horizontalDifference < verticalDifference* verticalDifference)
            {
                if (isUp)
                    bullet.SetDirection(Vector2.down);
                else bullet.SetDirection(Vector2.up);
            }
            else
            {
                if (isRight)
                    bullet.SetDirection(Vector2.left);
                else bullet.SetDirection(Vector2.right);
            }

        }
    }
    void CheckRelativePosition()
    {
        // 获取两个物体的世界位置
        Vector3 thisPosition = transform.position;
        Vector3 targetPosition = target.position;

        // 计算两个物体之间的相对位置
        horizontalDifference = thisPosition.x - targetPosition.x;
        verticalDifference = thisPosition.y - targetPosition.y;

        // 根据相对位置更新isRight和isUp的值
        isRight = horizontalDifference > 0;
        isUp = verticalDifference > 0;
    }
}
