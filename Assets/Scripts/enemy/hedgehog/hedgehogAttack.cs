using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class hedgehogAttack : MonoBehaviour
{
    Collider2D playerCol;
    Collider2D birdCol;
    Collider2D edge;
    private Animator _Animator;


    PlayerManager playerManager;

    GameObject player;

    public float wantDistance;
    public float distance;
    public Vector2 direction;

    public bool flag;
    public float relaxTime;
    public float Hp;

    Rigidbody2D theRB;
    //public float AlarmTime;
    //public float alertRange;
    //public bool MoveOrNot;
    //private bool isAlert; // �Ƿ��ڽ䱸״̬
    //private bool isRelax; // �Ƿ��ڷ���״̬
    //private float alertTimer; // �����ʱ��
    //public float alertDuration; // ����״̬����ʱ��
    //private float relaxTimer; // ���ɼ�ʱ��
    //public float relaxDuration; // ����״̬����ʱ��
    private void Awake()
    {

        _Animator = GetComponent<Animator>();

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();


        birdCol = GetComponent<Collider2D>();//������ײ��
        playerCol = GameObject.Find("Player").GetComponent<Collider2D>();
        edge = GameObject.Find("Edge").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(birdCol, playerCol, true);

        Physics2D.IgnoreCollision(birdCol, edge, true);

        player = GameObject.Find("Player");
        theRB= GetComponent<Rigidbody2D>(); 
        


        //relaxDuration = 3.0f;
        //relaxTimer = 0;
        //isAlert = false;
        //isRelax = false;
        //alertTimer = 0;
        //alertDuration = 1.0f;
        //alertRange = 3.0f; // ���䷶ΧΪ3
        //MoveOrNot = true; // ���ñ�������ƶ�
        //player = GameObject.Find("Player").transform;
    }
    public void SetHFalse()//���ܻ������رպ���
    {
        _Animator.SetBool("isHited", false);
    }
    private void Update()
    {
        if (playerManager.hasAttackTime <= 0 )
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.IgnoreCollision(birdCol, playerCol, false);
        }

        direction = player.transform.position - transform.position;
        distance = direction.magnitude;
        if(distance< wantDistance&&relaxTime<=0)
        {
            GetAlarm();
        }
        if(distance> wantDistance&& relaxTime <= 0&&flag==true)
        {
            flag = false;
            _Animator.SetBool("isAttacking", false);
            relaxTime = 5;
        }
        if(relaxTime>0)relaxTime-=Time.deltaTime;
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
        //CheckPlayerProximity();
        //HandleState();
    }
    void GetAlarm()
    {
        flag = true;
        _Animator.SetBool("isAttacking", true);
    }

    //private void CheckPlayerProximity()
    //{
    //    // �������Ƿ��ھ��䷶Χ�ڣ��κ���ײ�������Բ�غ϶��᷵��True
    //    if (Vector3.Distance(transform.position, player.position) <= alertRange)
    //    {
    //        // �������ڷ�Χ�ڣ����ý䱸״̬
    //        isAlert = true;
    //    }
    //    else
    //    {
    //        // �����Ҳ��ڷ�Χ�ڣ����÷���״̬
    //        isAlert = false;
    //    }
    //}

    //private void AlertState()
    //{
    //    //���¼�ʱ3s
    //    alertTimer = 0;
    //    MoveOrNot = false; // �Ա���ʩ�ӽ�ֹ�ƶ�
    //    // ����䱸״̬
    //    // ���������������˺��ͷ�����ײ�˺����߼�
    //    Debug.Log("hedgehog is now alert!");
    //}

    //private void RelaxState()
    //{
    //    MoveOrNot = true;// �Ա�������ֹ�ƶ�
    //    Debug.Log("hedgehog is now relax!");
    //    // ���������Ӻ�������ܵ��˺����߼������ܵ��˺���1
    //}

    //private void HandleState()
    //{
    //    if (isAlert && !isRelax)
    //    {
    //        relaxTimer = 0;
    //        MoveOrNot = false;
    //        AlertState();// ���뾯��״̬

    //    }
    //    else
    //    {
    //        alertTimer += Time.deltaTime; //����״̬����ʱ��
    //        if (alertTimer >= alertDuration)
    //        {
    //            //����һ��ʱ�����ɣ�����һ��ʱ���ڲ��ᾯ��
    //            RelaxState();
    //            isRelax = true;
    //            relaxTimer += Time.deltaTime; //����״̬����ʱ��
    //            if (relaxTimer >= relaxDuration)
    //            {
    //                isRelax = false;// ����ʱ���������ʱ���䣡
    //            }
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flag == false&&relaxTime>0)
        {
            GetDamaged();
        }
        else if (relaxTime <= 0 && flag == true)
        {
            playerManager.GetDamaged(playerManager.damage);
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
                if (playerManager.intMonsterShield < playerManager.damage * playerManager.damageMulti+1)
                    Hp = Hp + playerManager.intMonsterShield - playerManager.damage * playerManager.damageMulti-1;
            }
            else
            {
                if (playerManager.intMonsterShield < (playerManager.damage * playerManager.damageMulti+1) * 2)
                    Hp = Hp + playerManager.intMonsterShield - (playerManager.damage * playerManager.damageMulti+1) * 2;
            }
            if (Random.Range(0, 100) < playerManager.getMoneyRate)
            {
                playerManager.money++;
            }
        }


    }
}
