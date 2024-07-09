using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public GameObject player;
    PlayerManager playerManager;
    //public float hasHurtTime;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(hasHurtTime> 0)
        //{
        //    hasHurtTime-= Time.deltaTime;
        //}
    }
    //Collider2D c1, c2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (hasHurtTime <= 0)
        //{
        //playerManager.health -= playerManager.hurtMulti;
        //playerManager.UpdateHp();
        //Physics2D.IgnoreCollision(collision.collider, collision.otherCollider, true);
        playerManager.health = 0;
            //c1 = collision.collider;
            //c2 = collision.otherCollider;
            //Invoke("ResetCollision", 1f);
        //}
    }
    //void ResetCollision()
    //{
    //    Physics2D.IgnoreCollision(c1, c2, false);
    //}
}
