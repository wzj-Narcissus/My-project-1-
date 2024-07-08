using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D theRB;
    private float speed2;//实际速度
    public float minDistance = 0.1f; 
    public float maxDistance = 10.0f;
    public float hasAttackTime;
    public float attackTime;//冲刺时间
    private Vector2 targetPosition;
    public float rushNum;//冲刺量
    private Vector2 dirction;//冲刺方向

    public float speed;//初始速度
    public int damage;//野猪初始攻击力
    public int health ;//生命
    public int maxHealth ;//最大生命
    public int criticalStrikeRate;//初始暴击率
    public int missRate;//初始闪避率

    Health healthUp;


    PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
        healthUp = GameObject.Find("Health").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {   //Ebuff(ref damage,ref );
        if (hasAttackTime <=0)
        {
            speed2= speed*10;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float distance = Vector2.Distance(transform.position, targetPosition);

            float moveSpeed = speed2 * (distance / maxDistance);
            dirction = targetPosition - new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            hasAttackTime -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition+dirction.normalized * rushNum, playerAttack.attackSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            hasAttackTime = attackTime;
            playerAttack.Attack(damage, targetPosition);
        }

        //更新血量UI
        healthUp.Updatehealth(health,maxHealth);

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            if(hasAttackTime>0)
            {
                health--;
            }
        }
    }



}
