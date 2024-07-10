using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D squirrelCol;
    Collider2D edge;
    PlayerManager playerManager;




    public float Hp;





    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        squirrelCol = GetComponent<Collider2D>();//¹ÖÎïÅö×²Ìå
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
        Physics2D.IgnoreCollision(squirrelCol, edge, true);





        if (Hp <= 0) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.hasAttackTime <= 0)
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(squirrelCol, playerCol, false);
        }
        if (Hp <= 0) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GetDamaged();
        }
    }
    private void GetDamaged()
    {
        if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
        {
            Hp -= playerManager.damage * playerManager.damageMulti;
        }
        else
        {
            Hp -= playerManager.damage * playerManager.damageMulti * 2;
        }
        if (Random.Range(0, 100) > playerManager.getMoneyRate)
        {
            playerManager.money++;
        }


    }
}
