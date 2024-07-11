using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _Animator;
    public GameObject player;
    PlayerManager playerManager;
    public float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
        _Animator = GetComponent<Animator>();
    }
    public void SetAFalse()//将攻击动画关闭函数
    {
        _Animator.SetBool("isAttacking", false);
    }
    public void SetHFalse()//将受击动画关闭函数
    {
        _Animator.SetBool("isHited", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(Vector2 target)
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, attackSpeed * Time.deltaTime);
        playerManager.theRB.velocity = target.normalized*attackSpeed;
        _Animator.SetBool("isAttacking", true);
        Invoke("SetAFalse", 0.1f);


    }
}
