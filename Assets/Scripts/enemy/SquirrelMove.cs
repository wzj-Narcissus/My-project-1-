using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMove : MonoBehaviour
{
    //DogAttack attack;
    public float distance;
    Rigidbody2D theRB;
    public Transform target;// Ҫ�ӽ���Ŀ�������Transform���
    public float speed ; // �ӽ�Ŀ����ٶ�
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        //attack = GetComponent<DogAttack>();
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (attack.hasRushTime > 0)
        //{
        //    attack.hasRushTime -= Time.deltaTime;
        //}
        //else
        //{
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
        //}
    }
}
