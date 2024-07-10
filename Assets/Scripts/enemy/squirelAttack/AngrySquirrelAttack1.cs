using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngrySquirrelAttack1 : MonoBehaviour
{
    public GameObject BulletPrefab;
    private bool isRight = true;
    private bool isUp = false;
    public Transform target; // 目标物体的Transform组件
    public float horizontalDifference; //判断与玩家的水平位置差
    public float verticalDifference; //判断与玩家的水平位置差
    public float interval = 4f; // 攻击间隔
    public float Attime;//攻击时间
    public Vector2 bulletDir;
    private int actionCount = 0;// 三段射击执行的次数
    private int totalActions = 3;// 总共需要执行的次数（连发几枚松果）
    public float emitInterval = 1f;// 连发时间间隔
    private void Awake()
    {
        target = GameObject.Find("Player").transform; //获取玩家位置，注意大小写
    }

    // Update is called once per frame
    void Update()
    {
        //执行发射
        Shoot3();
    }
    void Shoot3()
    {
        // 冷却时间结束执行发射
        if ((Time.time - Attime) >= interval)
        {
            Attime = Time.time;
            // 开始执行Coroutine，三连发
            StartCoroutine(PerformAction());
            actionCount = 0;
        }
    }
    //时间序列循环，每隔几秒发射一次
    IEnumerator PerformAction()
    {
        // 检查玩家位置，调整松果上下左右方向
        CheckRelativePosition();
        if (horizontalDifference * horizontalDifference < verticalDifference * verticalDifference)
        {
            if (isUp)
                bulletDir = Vector2.down;
            else bulletDir = Vector2.up;
        }
        else
        {
            if (isRight)
                bulletDir = Vector2.left;
            else bulletDir = Vector2.right;
        }
        // 在攻击总数限制下进行间隔时间攻击
        while (actionCount < totalActions)
        {
            
            GameObject bulletObj = Instantiate(BulletPrefab);
            bulletObj.transform.position = transform.position;
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.SetDirection(bulletDir);

            // 等待1秒
            yield return new WaitForSeconds(emitInterval);

            // 计数加一，表示动作已执行一次
            actionCount++;
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
