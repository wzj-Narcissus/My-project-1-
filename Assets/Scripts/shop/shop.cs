using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shop : MonoBehaviour
{


    public float speed;//��ʼ�ٶ�
    public float damage;//Ұ���ʼ������
    public float health;//����
    public float maxHealth;//�������
    public float criticalStrikeRate;//��ʼ������
    public float missRate;//��ʼ������
    public float shield;//����
    public float damageMulti;//�˺�����
    public float hurtMulti;//���˱���
    //�������¼�����
    public float getMoneyRate;//��ҵ�����
    public float intShield;//��ɢ����Ҽ���
    public float inthurt;//��ɢ�͹����˺��ӳ�
    public float monsterHealth;//����Ѫ���ӳ�
    public float monsterMissRate;//����������
    public float intMonsterShield;//��ɢ�͹������


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
            //��������
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
        //��������
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
        //��������
        PlayerPrefs.SetFloat("10", getMoneyRate);
        PlayerPrefs.SetFloat("11", intShield);
        PlayerPrefs.SetFloat("12", inthurt);
        PlayerPrefs.SetFloat("13", monsterHealth);
        PlayerPrefs.SetFloat("14", monsterMissRate);
        PlayerPrefs.SetFloat("15", intMonsterShield);


    }



}
