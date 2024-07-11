using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private SpriteRenderer _Sr;//������Ⱦ������
    DogAttack attack;
    public float distance;
    Rigidbody2D theRB;
    public Transform target;// Ҫ�ӽ���Ŀ�������Transform���
    public float speed = 0.01f; // �ӽ�Ŀ����ٶ�
    private void Awake()
    {
        _Sr = GetComponent<SpriteRenderer>();//��ȡ��Ⱦ��ͼƬ
        target = GameObject.Find("Player").transform;
        attack = GetComponent<DogAttack>();
        theRB = GetComponent<Rigidbody2D>();
    }
    void Flip(float x)//���ڷ�תͼƬ
    {
        if (x > 0)
        {
            _Sr.flipX = true;
        }

        if (x < 0)
        {
            _Sr.flipX = false;
        }
    }
    private void Update()
    {
        if (attack.hasRushTime > 0)
        {
            attack.hasRushTime -= Time.deltaTime;
        }
        else
        {
            if (target != null)
            {
                // ���㵱ǰ������Ŀ������֮��ľ���
                Vector3 direction = target.position - transform.position;
                distance = direction.magnitude;
                Flip(direction.x);//��ʱ��תͼƬ




                // �������С��һ��ֵ����ֹͣ�ƶ�
                //if (distance < 0.1f)
                //{
                //    return;
                //}

                //// �����ƶ�����
                Vector3 moveDirection = direction.normalized;
                theRB.velocity = moveDirection * speed;
                //// �����ٶȺ�ʱ�����λ��
                //transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
    }
}
