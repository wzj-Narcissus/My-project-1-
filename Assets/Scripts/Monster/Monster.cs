using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    PlayerManager playerManager;

    //PolygonCollider2D thePC;

    public float Hp;
    // Start is called before the first frame update
    void Start()
    {
        //thePC = GetComponent<PolygonCollider2D>();
        playerManager= player.GetComponent<PlayerManager>();
    }
    Collider2D c1, c2;
    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
            playerManager.experience++;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "player" && playerManager.hasAttackTime > 0)
        {
            Hp -= playerManager.realDamage;
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider,true);
            c1=collision.collider;
            c2=collision.otherCollider;
            Invoke("ResetCollision", 0.1f);
        }
    }
    void ResetCollision()
    {
        Physics2D.IgnoreCollision(c1, c2, false);
    }
}
