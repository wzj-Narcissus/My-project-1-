using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D squirrelCol;
    Collider2D edge;
    PlayerManager playerManager;
    Giant Giant;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();
        Giant =GameObject.Find("Giant").GetComponent<Giant>();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        squirrelCol = GetComponent<Collider2D>();//¹ÖÎïÅö×²Ìå
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
        Physics2D.IgnoreCollision(squirrelCol, edge, true);

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        if (playerManager.hasAttackTime <= 0)
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Giant.GetDamaged();
        }
    }


    //void Start()
    //{
    //    playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("player"))
    //    {
    //        playerManager.GetDamaged(1f + playerManager.inthurt);

    //    }
    //    //if (other.gameObject.CompareTag("Env"))
    //    //{
    //    //    Destroy(gameObject);
    //    //}
    //}
}
