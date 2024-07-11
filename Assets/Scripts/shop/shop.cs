using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shop : MonoBehaviour
{


    public float speed;//初始速度
    public float damage;//野猪初始攻击力
    public float health;//生命
    public float maxHealth;//最大生命
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


    public string nextname;
    public int money;
    public float counttime;
    public GameObject lockmoney;

    public int sign1 = 0;
    public int sign2 = 0;
    public int sign3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        getdata();
        counttime = 0;
        money = PlayerPrefs.GetInt("16", 0); ;
    }

    // Update is called once per frame
    void Update()
    {
        if(lockmoney.activeSelf == true)
        {
            counttime += Time.deltaTime;
            if(counttime > 1f )
            {
                lockmoney.SetActive(false);
                counttime = 0f;
            }
        }
    }


    public void whenbutton1()
    {
        if (money >= 2&&sign1==0)
        {
            sign1 = 1;
            money -= 2;
            shield++;
            loaddate();

        }
        if(money<2)
        {
            lockmoney.SetActive(true);

        }
    }
    public void whenbutton2()
    {

        if (money >=2&&sign2==0)
        {
            sign2 = 1;
            health++;
            if (health > maxHealth)
            {
                health=maxHealth;
            }
            money -= 2;
            loaddate();

        }
        if(money < 2)
        {
            lockmoney.SetActive(true);

        }
    }
   public void whenbutton3()
    {
        if (money >= 8&&sign3==0)
        {

            sign3 = 1;
            speed = 2f;
            damage =  1f;
            criticalStrikeRate = 5f;
            missRate = 5f;
            shield = 0f;
            damageMulti = 1f;
            hurtMulti = 1f;
            maxHealth = 3;
            //增加属性
            getMoneyRate = 60f;
            intShield = 0f;
            inthurt = 0f;
            monsterHealth = 1f;
            monsterMissRate = 0f;
            intMonsterShield = 0f;
            money -= 8;
            loaddate();
  
        }
        if(money<8)
        {
            lockmoney.SetActive(true);

        }
    }
    public void whenbutton4()
    {
        PlayerPrefs.SetInt("16",money);
        SceneManager.LoadScene(nextname);
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


    public void loaddate()
    {
        PlayerPrefs.SetFloat("1", speed);
        PlayerPrefs.SetFloat("2", damage);
        PlayerPrefs.SetFloat("3", health);
        PlayerPrefs.SetFloat("4", maxHealth);
        PlayerPrefs.SetFloat("5", criticalStrikeRate);
        PlayerPrefs.SetFloat("6", missRate);
        PlayerPrefs.SetFloat("7", shield);
        PlayerPrefs.SetFloat("8", damageMulti);
        PlayerPrefs.SetFloat("9", hurtMulti);
        //增加属性
        PlayerPrefs.SetFloat("10", getMoneyRate);
        PlayerPrefs.SetFloat("11", intShield);
        PlayerPrefs.SetFloat("12", inthurt);
        PlayerPrefs.SetFloat("13", monsterHealth);
        PlayerPrefs.SetFloat("14", monsterMissRate);
        PlayerPrefs.SetFloat("15", intMonsterShield);


    }



}
