using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedgehogMovement : MonoBehaviour
{
    public Transform target; // Ҫ�ӽ���Ŀ�������Transform���
    public float speed = 5.0f; // �ӽ�Ŀ����ٶ�

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (gameObject.GetComponent<hedgehogAttack>().MoveOrNot)
        {
            if (target != null)
            {
                // ���㵱ǰ������Ŀ������֮��ľ���
                Vector3 direction = target.position - transform.position;
                float distance = direction.magnitude;

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
