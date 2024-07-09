using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public struct Buff
    {
        public int num;
        public float time;
    }
    public List<Buff> buffList;
    public Rigidbody2D theRB;
    private float speed2;//实际速度
    public float minDistance = 0.1f; 
    public float maxDistance = 10.0f;
    public float hasAttackTime;
    public float attackTime;//冲刺时间
    private Vector2 targetPosition;
    public float rushNum;//冲刺量
    private Vector2 direction;//冲刺方向

    public float speed;//初始速度
    public float damage;//野猪初始攻击力
    public float health ;//生命
    public float maxHealth ;//最大生命
    public float criticalStrikeRate;//初始暴击率
    public float missRate;//初始闪避率
    public float shield;//护盾
    public float damageMulti=1;//伤害倍率
    public float hurtMulti=1;//受伤倍率
    //public float hurtnum ;//

    //下面是buff后的真实参数
    //public float realSpeed;//速度
    //public float realDamage;//野猪初始攻击力
    //public float realHealth;//生命
    //public float realCriticalStrikeRate;//初始暴击率
    //public float realMissRate;//初始闪避率
    //public float realShield;//护盾

    public float experience;//经验
    public int money;

    public Buff buff;

    Health healthUp;
    EBuff eBuff;
    SpriteRenderer spriteRenderer;
    PlayerAttack playerAttack;
    FlipX flipX;
    public GameObject deathPrefab;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        buffList=new List<Buff> ();
        theRB = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
        healthUp = GameObject.Find("Health").GetComponent<Health>();
        eBuff= GetComponent<EBuff>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flipX=GetComponent<FlipX>();
        healthUp.Init();
        Time.timeScale = 1.0f;
        //buff.num = 1;
        //buff.time = 99999;
        //buffList.Add(buff);
        //eBuff.Ebuff(ref buffList, ref damage, ref speed, ref criticalStrikeRate, ref missRate, ref shield, ref maxHealth);
    }

    // Update is called once per frame
    void Update()
    {   /*eBuff.Ebuff(ref buffList,ref damage,ref  speed, ref  criticalStrikeRate, ref  missRate, ref  shield, ref  maxHealth);*/
        
        if (hasAttackTime <=0)
        {
            speed2= speed*10;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float distance = Vector2.Distance(transform.position, targetPosition);

            float moveSpeed = speed2 * (distance / maxDistance);
            if(moveSpeed>speed)moveSpeed=speed;
            direction = targetPosition - new Vector2(transform.position.x, transform.position.y);
            //transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            theRB.velocity=direction*moveSpeed;
        }
        else
        {
            hasAttackTime -= Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, targetPosition+direction.normalized * rushNum, playerAttack.attackSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            hasAttackTime = attackTime;
            playerAttack.Attack(direction);
        }

        //更新血量UI
        //healthUp.Updatehealth(health);
        if (health <= 0)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GameObject G = Instantiate(deathPrefab);
                G.SetActive(true);
            }
            
        }
        flipX.flipx(spriteRenderer,direction);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            if(hasAttackTime>0)
            {
                health-=hurtMulti;
                UpdateHp();
            }
        }
    }
    public void UpdateHp()
    {
        healthUp.UpdateHp((int)(2 * health));
    } 



}
