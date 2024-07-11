using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D dogCol;
    Collider2D edge;
    private Animator _Animator;

    PlayerManager playerManager;


    public float healthTime;

    public bool flag;
    public float hasGetDamageTime;
    public Vector2 direction;
    public float rushSpeed;
    public float hasRushTime;
    public float rushTime;
    Rigidbody2D theRB;


    public Transform target; // ��ҵ�Transform���
    //public float attackRange = 5.0f; // ���˵Ĺ�����Χ

    //public float attackCooldown = 2.0f; // ������ȴʱ��
    //private float nextAttackTime = 0.0f; // �´ο��Թ�����ʱ��

    public float Hp;
    public void SetAFalse()//�����������رպ���
    {
        _Animator.SetBool("isAttacking", false);
    }
    public void SetHFalse()//���ܻ������رպ���
    {
        _Animator.SetBool("isHited", false);
    }
    private void Awake()
    {
        _Animator = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        flag = false;


        playerManager=GameObject.Find("Player").GetComponent<PlayerManager>();
        

        dogCol = GetComponent<Collider2D>();//������ײ��
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge=GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(dogCol, playerCol, true);
        theRB= GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(dogCol, edge,true);
        Hp *= playerManager.monsterHealth;
    }
    private void Update()
    {
        if(healthTime > 0)healthTime-=Time.deltaTime;
        if(Hp<=0)Destroy(gameObject);
        if (playerManager.hasAttackTime <= 0&&hasRushTime<=0)
        {
            Physics2D.IgnoreCollision(dogCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
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
                Physics2D.IgnoreCollision(dogCol, playerCol, false);
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
            Physics2D.IgnoreCollision(dogCol, playerCol, false);
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
                playerManager.GetDamaged(1+playerManager.inthurt);
                _Animator.SetBool("isAttacking", true);
                Invoke("SetAFalse", 0.5f);
                healthTime = 0.5f;
            }
            //Debug.Log("11");
        }
        else if(collision.gameObject.tag == "player" && hasRushTime <= 0)
        {
            Debug.Log("1");
            GetDamaged();
            _Animator.SetBool("isHited", true);
            Invoke("SetHFalse", 0.2f);
            flag = true;
            hasGetDamageTime = 0.5f;
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