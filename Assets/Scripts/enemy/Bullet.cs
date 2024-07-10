using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerManager playerManager;
    public float Speed = 3f;
    public float LiveTime = 5f;
    
    private Vector2 _Direction;
    private float _HasLiveTime = 0;
    private void Awake()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    private void Update()
    {
        _HasLiveTime += Time.deltaTime;
        if (_HasLiveTime > LiveTime)
        {
            Destroy(gameObject);
        }
        
        transform.Translate(_Direction.normalized * (Speed * Time.deltaTime));
    }

    public void SetDirection(Vector2 dir)
    {
        _Direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            playerManager.GetDamaged(1.5f);
        }
        //if (other.gameObject.CompareTag("Env"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
