using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack1 : MonoBehaviour
{

    Collider2D playerCol;
    Collider2D birdCol;
    Collider2D edge;
    private Animator _Animator;


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
    BirdMove birdMove;
    public float attackDistance;
    public float healthTime;


    public Transform target; // ��ҵ�Transform���
    public float attackRange = 5.0f; // ���˵Ĺ�����Χ

    public float attackCooldown = 2.0f; // ������ȴʱ��
    //private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��

    public float Hp;

    private void Awake()
    {
        _Animator = GetComponent<Animator>();

        target = GameObject.Find("Player").transform;
        flag = false;
        birdMove=GetComponent<BirdMove>();

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();


        birdCol = GetComponent<Collider2D>();//������ײ��
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(birdCol, playerCol, true);
        theRB = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(birdCol, edge, true);
        Hp *= playerManager.monsterHealth;
    }
    public void SetAFalse()//�����������رպ���
    {
        _Animator.SetBool("isAttacking", false);
    }
    public void SetHFalse()//���ܻ������رպ���
    {
        _Animator.SetBool("isHited", false);
    }
    private void Update()
    {
        if(healthTime>0)
        {
            healthTime-= Time.deltaTime;
        }
        if (Hp <= 0) Destroy(gameObject);
        if (playerManager.hasAttackTime <= 0 && hasRushTime <= 0)
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }


        if (hasSkillTime <= 0)
        {
            if (birdMove.distance < attackDistance)
            {
                flag = true;
                hasGetDamageTime = 0.5f;
                hasSkillTime = skillTime;
            }
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
                _Animator.SetBool("isAttacking", true);
                Invoke("SetAFalse", 0.3f);

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
                playerManager.GetDamaged(1+ playerManager.inthurt);
                healthTime = 0.5f;
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
        _Animator.SetBool("isHited", true);
        Invoke("SetHFalse", 0.3f);
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
