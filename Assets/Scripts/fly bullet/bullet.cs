using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;  // 子弹的移动速度
    public float livetime = 5;
    private Vector2 direction; // 子弹的飞行方向
    private float haslivetime=0;

    void Update()
    {
        haslivetime += Time.deltaTime;
        if (haslivetime > livetime)
        {
            Destroy(gameObject);
        }
        else
        {
            // 子弹沿着设定的飞行方向移动
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // 设置新的飞行方向，并确保是单位向量
    }

}
