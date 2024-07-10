using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    CatAttack attack;
    public float distance;
    public Transform target;// Ҫ�ӽ���Ŀ�������Transform���
    public float speed = 0.01f; // �ӽ�Ŀ����ٶ�

    Rigidbody2D theRB;
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        attack = GetComponent<CatAttack>();
        theRB = GetComponent<Rigidbody2D>();
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