using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedgehogMovement : MonoBehaviour
{
    private SpriteRenderer _Sr;//������Ⱦ������
    public Transform target; // Ҫ�ӽ���Ŀ�������Transform���
    public float speed = 5.0f; // �ӽ�Ŀ����ٶ�

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
    private void Awake()
    {
        _Sr = GetComponent<SpriteRenderer>();//��ȡ��Ⱦ��ͼƬ

        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (!gameObject.GetComponent<hedgehogAttack>().flag)
        {
            if (target != null)
            {
                // ���㵱ǰ������Ŀ������֮��ľ���
                Vector3 direction = target.position - transform.position;
                float distance = direction.magnitude;
                Flip(direction.x);//��ʱ��תͼƬ

                // �������С��һ��ֵ����ֹͣ�ƶ�
                if (distance < 0.1f)
                {
                    return;
                }

                // �����ƶ�����
                Vector3 moveDirection = direction.normalized;

                // �����ٶȺ�ʱ�����λ��
                transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
       
    }
}

