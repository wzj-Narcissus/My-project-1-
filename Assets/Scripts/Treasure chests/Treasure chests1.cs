using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Treasurechests : MonoBehaviour
{


    public float speed;//��ʼ�ٶ�
    public float damage;//Ұ����ʼ������
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

        x = Random.Range(0, 16);

        Buffs temp;

        temp = new Buffs();
        temp.sometext = "������";
        temp.name = "��������0.5";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "������";
        temp.name = "��������0.5";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "������";
        temp.name = "����������20%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "������";
        temp.name = "�����ʼ���20%";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "������";
        temp.name = "����������15%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "������";
        temp.name = "�����ʼ���15%";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "����";
        temp.name = "��������0.5��";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "����";
        temp.name = "���ټ���0.5��";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "��������";
        temp.name = "������������1��";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "����";
        temp.name = "��ɫ��ɵ������˺���Ϊԭ����2����ͬʱ�ܵ����˺���Ϊԭ����2��";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "����";
        temp.name = "�յ����˺�����0.5�㣬ͬʱ��ɵ���ײ�˺�����0.5�㡢�ٶȼ���0.5��";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "����";
        temp.name = "�ƶ��ٶ����3�㣬ͬʱ�յ����˺���Ϊԭ����2��";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "���ﱩ��";
        temp.name = "�����˺����0.5��";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "���ﱩ��";
        temp.name = "����Ѫ�����50%";
        mybuffs.Add(temp);

        temp = new Buffs();
        temp.sometext = "���ﱩ��";
        temp.name = "��������������20%";
        mybuffs.Add(temp);


        temp = new Buffs();
        temp.sometext = "����Σ��";
        temp.name = "��ҵ����ʽ���20%";
        mybuffs.Add(temp);


    }

    // Update is called once per frame
    void Update()
    {
        if (sign == 0)
        {
            _button.GetComponentInChildren<Text>().text = "��ϲ����һ�����buff";

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
                criticalStrikeRate += 2f;
                break;
            case 3:
                criticalStrikeRate -= 2f;
                break;
            case 4:
                missRate += 1.5f;
                break;
            case 5:
                missRate -= 1.5f;
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
                speed -= 0.5f;
                hurtMulti *= 0.5f;
                damageMulti *= 0.5f;
                break;
            case 11:
                speed += 3f;
                hurtMulti *= 2;
                break;
            case 12:
                inthurt += 0.5f;
                break;
            case 13:
                monsterMissRate += 0.5f;
                break;
            case 14:
                monsterMissRate += 0.2f;
                break;
            case 15:
                getMoneyRate -= 20f;
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