using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{

    Collider2D playerCol;
    Collider2D squirrelCol;
    Collider2D edge;
    PlayerManager playerManager;

    public float Hp;

    public GameObject lefthand;
    public GameObject righthand;
    public float beingtime=0;
    public float time1 = 5;
    public float time2 = 10;
    public int movekind;

    private Animator _Animator;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        beingtime = 5;
        movekind = 1;
        _Animator = GetComponent<Animator>();
        _Animator.SetBool("move1",true);
    }

    // Update is called once per frame
    void Update()
    {
        beingtime += Time.deltaTime;
        if (beingtime > time1) 
        {

            if (movekind > 4)
            {
                movekind %= 4;
            } 
            movement(movekind);
            movekind++;


            beingtime = 0;
        }


    }


    public void movement(int x)
    {
        switch (x)
        {
            case 1:
                _Animator.SetBool("move5", true);
                _Animator.SetBool("move2", false);
                lefthand.SetActive(true);
                righthand.SetActive(false);
                break;
            case 2:
                _Animator.SetBool("move2", true);
                _Animator.SetBool("move3", false);
                lefthand.SetActive(true);
                righthand.SetActive(true);
                break;
            case 3:
                _Animator.SetBool("move3", true);
                _Animator.SetBool("move4", false);
                lefthand.SetActive(true);
                righthand.SetActive(false);
                break;
            case 4:
                _Animator.SetBool("move4", true);
                _Animator.SetBool("move5", false);
                lefthand.SetActive(false);
                righthand.SetActive(false);
                break;


            default:
                break;
        }

    }


    public void GetDamaged()
    {
        if (Random.Range(0, 100) > playerManager.criticalStrikeRate)
        {
            Hp -= playerManager.damage * playerManager.damageMulti;
        }
        else
        {
            Hp -= playerManager.damage * playerManager.damageMulti * 2;
        }
        if (Random.Range(0, 100) > playerManager.getMoneyRate)
        {
            playerManager.money++;
        }


    }

}
