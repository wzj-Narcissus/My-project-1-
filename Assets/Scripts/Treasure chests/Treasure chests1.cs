using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Treasurechests1 : MonoBehaviour
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

    public struct Buffs
    {
        public string sometext;
        public string name;
    }

    private int x;
    public Button _button;

    public List<Buffs> mybuffs = new List<Buffs>();


    private float counttime=0;
    int sign = 0;
    // Start is called before the first frame update
    void Start()
    {
        _button =GameObject.Find("Button").GetComponent<Button>();

        getdata();

        x = Random.Range(0, 18);

        Buffs temp;

        temp = new Buffs();
        temp.sometext = "攻击力";
        temp.name = "攻击增加0.5";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "攻击力";
        temp.name = "攻击减少0.5";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "暴击率";
        temp.name = "暴击率提升20%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "暴击率";
        temp.name = "暴击率减少10%";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "闪避率";
        temp.name = "闪避率提升15%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "闪避率";
        temp.name = "闪避率减少10%";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "移速";
        temp.name = "移速提升0.5点";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "移速";
        temp.name = "移速减少0.5点";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "生命上限";
        temp.name = "生命上限提升1点,最大为5";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "风险";
        temp.name = "角色造成的所有伤害变为原来的2倍，同时受到的伤害变为原来的2倍";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "风险";
        temp.name = "收到的伤害减少0.5点，同时造成的碰撞伤害减少0.5点,造成伤害最少为0.5,减少伤害最多为0.5点";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "风险";
        temp.name = "移动速度提高2点，同时收到的伤害变为原来的2倍";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "怪物暴动";
        temp.name = "怪物伤害提高0.5点";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "怪物暴动";
        temp.name = "怪物血量提高20%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "怪物暴动";
        temp.name = "怪物闪避率提升10%";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "金融危机";
        temp.name = "金币掉落率降低20%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "血瓶";
        temp.name = "获得一点生命值";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "护盾";
        temp.name = "获得一个护盾";
        mybuffs.Add(temp);



    }

    // Update is called once per frame
    void Update()
    {
        if (sign == 0)
        {
            _button.GetComponentInChildren<Text>().text = "恭喜你获得一个随机buff";

            sign = 1;
        }
        counttime += Time.deltaTime;
        if(counttime > 1.5f)
        {
            _button.GetComponentInChildren<Text>().text = "Buff: " + mybuffs[x].sometext + " - " + mybuffs[x].name;
        }
        if(counttime >4f)
        {
            change(x);
            loaddate();
            SceneManager.LoadScene(nextname);
        }
        
    }



    public void change(int x)
    {
        switch (x)
        {
            case 0:
                damage = (float)(damage + 0.5);
                break;
            case 1:
                damage = (float)(damage - 0.5);

                break;
            case 2:
                criticalStrikeRate += 20f;
                break;
            case 3:
                criticalStrikeRate -= 10f;
                break;
            case 4:
                missRate += 15f;
                break;
            case 5:
                missRate -= 10f;
                break;
            case 6:
                speed += 0.5f;
                break;
            case 7:
                speed -= 0.5f;
                break;
            case 8:
                maxHealth += 1f;
                health += 1f;
                break;
            case 9:
                damageMulti += 1;
                hurtMulti += 1;
                break;
            case 10:
                hurtMulti *= 0.5f;
                damageMulti *= 0.5f;
                break;
            case 11:
                speed += 2f;
                hurtMulti *= 2;
                break;
            case 12:
                inthurt += 0.5f;
                break;
            case 13:
                monsterHealth += 0.2f;
                break;
            case 14:
                monsterMissRate += 10f;
                break;
            case 15:
                getMoneyRate -= 20f;
                break;

            case 16:
                health += 1;
                if(health>maxHealth) health = maxHealth;
                break;
            case 17:
                shield += 1;
                break;

            default:
                break;
        }
    }


    void getdata()
    {
        speed = PlayerPrefs.GetFloat("1", 2f);
        damage = PlayerPrefs.GetFloat("2", 1f);
        health = PlayerPrefs.GetFloat("3", 3f);
        maxHealth = PlayerPrefs.GetFloat("4", 5f);
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
        if (maxHealth > 5)
        {
            maxHealth = 5;
        }
        if (health > 5)
        {
            health = 5;
        }

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
