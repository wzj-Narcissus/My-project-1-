using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt : MonoBehaviour
{
    PlayerManager playerManager;

    public float speed = 10f;  // 子弹的移动速度
    public float livetime = 5;
    private Vector2 direction; // 子弹的飞行方向
    private float haslivetime = 0;
    private void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    void Update()
    {
        haslivetime += Time.deltaTime;
        if (haslivetime > livetime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player")&&haslivetime>0.5f)
        {
            playerManager.GetDamaged(1f + playerManager.inthurt);

        }
        //if (other.gameObject.CompareTag("Env"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
