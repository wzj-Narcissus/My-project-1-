using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D birdCol;
    Collider2D edge;


    PlayerManager playerManager;

    public bool flag;
    public float hasGetDamageTime;
    public Vector2 direction;
    public float rushSpeed;
    public float hasRushTime;
    public float rushTime;
    Rigidbody2D theRB;
    public float skillTime;
    public float hasSkillTime;
    CatMove birdMove;
    public float attackDistance;
    public float healthTime;
    private bool flag2;

    public Transform target; // ��ҵ�Transform���
    public float attackRange = 5.0f; // ���˵Ĺ�����Χ

    public float attackCooldown = 2.0f; // ������ȴʱ��
    //private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��

    public float Hp;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        flag = false;
        
        birdMove = GetComponent<CatMove>();

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        //if (birdMove == null) Debug.Log("Bird");

        birdCol = GetComponent<Collider2D>();//������ײ��
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(birdCol, playerCol, true);
        theRB = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(birdCol, edge, true);
        Hp *= playerManager.monsterHealth;
    }
    private void Update()
    {
        if (healthTime > 0)
        {
            healthTime -= Time.deltaTime;
        }
        if (Hp <= 0) Destroy(gameObject);
        if (playerManager.hasAttackTime <= 0 && hasRushTime <= 0)
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }


        if (hasSkillTime <= 0&&flag2==false)
        {
            if (birdMove.distance < attackDistance)
            {
                flag = true;
                hasGetDamageTime = 0.3f;
                //hasSkillTime = skillTime;
                hasSkillTime = 0.5f;
                flag2 = true;
            }
        }
        if (flag2 == true && hasSkillTime <= 0)
        {
            flag = true;
            hasGetDamageTime = 0.3f;
            hasSkillTime = skillTime;
            //hasSkillTime = 0.3f
                flag2 = false;
        }

        else
        {
            hasSkillTime -= Time.deltaTime;
        }

        if (flag == true)
        {
            if (hasGetDamageTime > 0)
            {
                hasGetDamageTime -= Time.deltaTime;
            }

            else
            {
                hasRushTime = rushTime;
                direction = new Vector2(playerManager.transform.position.x - transform.position.x, playerManager.transform.position.y - transform.position.y);
                Physics2D.IgnoreCollision(birdCol, playerCol, false);
                theRB.velocity = direction.normalized * rushSpeed;
                flag = false;

                //if (Vector3.Distance(transform.position, target.position) <= attackRange)
                //{
                //    // ����Ƿ��Ѿ�������ȴʱ��
                //    if (Time.time >= nextAttackTime)
                //    {
                //        AttackPlayer();
                //        // �����´ι���ʱ��
                //        nextAttackTime = Time.time + attackCooldown;
                //    }
                //}
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, false);
        }
    }

    //private void AttackPlayer()
    //{
    //    // ����ʵ�ֹ����߼������磺
    //    // - ���ö���ϵͳ���Ź�������
    //    // - ���������˺�
    //    //Debug.Log("���˽�ս������ң�");
    //    playerManager.GetDamaged(1);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && hasRushTime > 0)
        {
            if (healthTime > 0)
            {

            }
            else
            {
                playerManager.GetDamaged(1f + playerManager.inthurt);
                healthTime = 1f;
                //Debug.Log("11");
            }
        }
        else if (collision.gameObject.tag == "player" && hasRushTime <= 0 && hasGetDamageTime <= 0)
        {
            GetDamaged();
            //flag = true;
            //hasGetDamageTime = 0.5f;
        }
        else if (collision.gameObject.tag == "player")
        {

            GetDamaged();
            GetDamaged();
        }
    }

    private void GetDamaged()
    {
        if (Random.Range(0, 100) > playerManager.monsterMissRate)
        {
            if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
            {
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti;
            }
            else
            {
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti * 2)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti * 2;
            }
            if (Random.Range(0, 100) < playerManager.getMoneyRate)
            {
                playerManager.money++;
            }
        }


    }
}
