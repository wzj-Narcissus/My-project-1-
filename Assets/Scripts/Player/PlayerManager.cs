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
    public float damageMulti;//伤害倍率
    public float hurtMulti;//受伤倍率
    //下面是新加属性
    public float getMoneyRate;//金币掉落率
    public float intShield;//离散型玩家减伤
    public float inthurt;//离散型怪物伤害加成
    public float monsterHealth;//怪物血量加成
    public float monsterMissRate;//怪物闪避率
    public float intMonsterShield;//离散型怪物减伤

   

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

    //Collider2D playerCol;
    //Collider2D dogCol;
    //Collider2D dogColClone;


    // Start is called before the first frame update
    void Start()
    {
        getdata();
        buffList=new List<Buff> ();
        theRB = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
        healthUp = GameObject.Find("Health").GetComponent<Health>();
        eBuff= GetComponent<EBuff>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flipX=GetComponent<FlipX>();
        healthUp.Init();



        /*dogCol = GameObject.Find("Enemy_Dog").GetComponent<Collider2D>();*///怪物碰撞体



        Time.timeScale = 1.0f;
        //playerCol = GetComponent<Collider2D>();

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


            //dogColClone = GameObject.Find("Enemy_Dog(Clone)").GetComponent<Collider2D>();
            //Physics2D.IgnoreCollision(dogCol, playerCol, true);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, true);


            speed2 = speed*10;
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


            //Physics2D.IgnoreCollision(dogCol, playerCol, false);
            //Physics2D.IgnoreCollision(dogColClone, playerCol, false);



            hasAttackTime = attackTime;
            playerAttack.Attack(direction);
        }

        //更新血量UI
        if (health <= 0)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GameObject G = Instantiate(deathPrefab);
                G.SetActive(true);
            }

        }
        UpdateHp();
        
        flipX.flipx(spriteRenderer,direction);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "monster")
    //    {
    //        if(hasAttackTime>0)
    //        {
    //            health-=hurtMulti;
    //            UpdateHp();
    //        }
    //    }
    //}
    public void UpdateHp()
    {
        healthUp.UpdateHp((int)(2 * health));
    } 

    public void GetDamaged(float damage)
    {
        if (Random.Range(0, 100) > missRate)
        {
            if (shield >= 1)
            {
                Debug.Log("Shield!");
                shield--;
            }
            else
            {
                if (intShield > damage * hurtMulti) { }
                else
                {
                    health = health + intShield - damage * hurtMulti;
                }
                //Debug.Log("h");
            }
        }
        else
        {
            Debug.Log("Miss!");
        }
        if (health <= 0)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GameObject G = Instantiate(deathPrefab);
                G.SetActive(true);
            }

        }
        else
        {
            UpdateHp();
        }

    }

    void getdata()
    {
        speed = PlayerPrefs.GetFloat("1", 2f);
        damage = PlayerPrefs.GetFloat("2", 1f);
        health = PlayerPrefs.GetFloat("3", 3f);
        maxHealth = PlayerPrefs.GetFloat("4", 3f);
        criticalStrikeRate = PlayerPrefs.GetFloat("5", 5f);
        missRate = PlayerPrefs.GetFloat("6", 5f);
        shield = PlayerPrefs.GetFloat("7", 0f);
        damageMulti = PlayerPrefs.GetFloat("8", 1f);
        hurtMulti = PlayerPrefs.GetFloat("9", 1f);
        //增加属性
        getMoneyRate = PlayerPrefs.GetFloat("10", 60f);
        intShield = PlayerPrefs.GetFloat("11", 0f);
        inthurt = PlayerPrefs.GetFloat("12", 0f);
        monsterHealth = PlayerPrefs.GetFloat("13", 1f);
        monsterMissRate = PlayerPrefs.GetFloat("14", 0f);
        intMonsterShield = PlayerPrefs.GetFloat("15", 0f);
    }



}
