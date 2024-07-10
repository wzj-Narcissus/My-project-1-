using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedgehogAttack : MonoBehaviour
{
    public float alertRange;
    public bool MoveOrNot;
    private bool isAlert; // 是否处于戒备状态
    private bool isRelax; // 是否处于放松状态
    private float alertTimer; // 警戒计时器
    public float alertDuration; // 警惕状态持续时间
    private float relaxTimer; // 放松计时器
    public float relaxDuration; // 放松状态持续时间
    Transform player;
    private void Awake()
    {
        relaxDuration = 3.0f;
        relaxTimer = 0;
        isAlert = false;
        isRelax = false;
        alertTimer = 0;
        alertDuration = 1.0f;
        alertRange = 3.0f; // 警戒范围为3
        MoveOrNot = true; // 设置本体可以移动
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        CheckPlayerProximity();
        HandleState();
}

    private void CheckPlayerProximity()
    {
        // 检测玩家是否在警戒范围内，任何碰撞体与这个圆重合都会返回True
        if (Vector3.Distance(transform.position, player.position) <= alertRange)
        {
            // 如果玩家在范围内，设置戒备状态
            isAlert = true;
        }
        else
        {
            // 如果玩家不在范围内，设置放松状态
            isAlert = false;
        }
    }

    private void AlertState()
    {
        //重新计时3s
        alertTimer = 0;
        MoveOrNot = false; // 对本体施加禁止移动
        // 进入戒备状态
        // 这里可以添加免疫伤害和反弹碰撞伤害的逻辑
        Debug.Log("hedgehog is now alert!");
    }

    private void RelaxState()
    {
        MoveOrNot = true;// 对本体解除禁止移动
        Debug.Log("hedgehog is now relax!");
        // 这里可以添加豪猪可以受到伤害的逻辑，且受到伤害加1
    }

    private void HandleState()
    {
        if (isAlert && !isRelax)
        {
            relaxTimer = 0;
            MoveOrNot = false;
            AlertState();// 进入警戒状态

        }
        else
        {
            alertTimer += Time.deltaTime; //警戒状态持续时间
            if (alertTimer >= alertDuration)
            {
                //警戒一段时间后放松，并在一定时间内不会警戒
                RelaxState();
                isRelax = true;
                relaxTimer += Time.deltaTime; //放松状态持续时间
                if (relaxTimer >= relaxDuration)
                {
                    isRelax = false;// 放松时间结束，随时警戒！
                }
            }
        }
    }

}
