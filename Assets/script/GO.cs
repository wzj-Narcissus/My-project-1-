

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class go : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D _rigid;
    private bool isOnground = false;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool isRight = true;

    public GameObject prefab; // 引用预制体资源
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator=GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //        float y = Input.GetAxisRaw("Vertical");

        move(x);
        flip(x);
        jump();
        Shoot();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnground = true;
            Debug.Log("is on ground");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnground = false;
            Debug.Log("not on ground");
        }
    }

    void move(float x)
    {
        _animator.SetFloat("move", x);
        _animator.SetBool("onground",isOnground);
        _animator.SetFloat("verticalspeed", _rigid.velocity.y);
        _rigid.velocity=new Vector2(x*speed,_rigid.velocity.y);
    }


    void flip(float x)
    {
        if (x > 0)
        {
            _spriteRenderer.flipX = false;
            isRight= true;
        }

        if (x < 0)
        {
            _spriteRenderer.flipX = true;
            isRight = false;
        }

    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnground)
        {
            _rigid.AddForce(new Vector2(0, 300));
            _animator.SetTrigger("jump");
        }
    }


    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject bulletObj = Instantiate(prefab);
            bulletObj.transform.position = transform.position;

            bullet _bullet = bulletObj.GetComponent<bullet>();
            if (isRight)
                _bullet.setdirection(Vector2.right);
            else _bullet.setdirection(Vector2.left);
        }
    }

}

