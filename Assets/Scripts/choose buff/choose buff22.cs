using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choosebuff22 : MonoBehaviour
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

    public struct Buffs
    {
        public string sometext;
        public string name;
    }

    private int x;
    private int y;
    private int z;
    public Button[] buttons;
    public List<Buffs> mybuffs = new List<Buffs>();

    void Start()
    {
        getdata();

        buttons[0] = GameObject.Find("Button1").GetComponent<Button>();
        buttons[1] = GameObject.Find("Button2").GetComponent<Button>();
        buttons[2] = GameObject.Find("Button3").GetComponent<Button>();

        if (buttons[0] != null && buttons[1] != null && buttons[2] != null)
        {

            x = Random.Range(0, 6);
            y = Random.Range(0, 6);
            z = Random.Range(0, 6);

            while (x == y || y == z || z == x)
            {
                x = Random.Range(0, 6);
                y = Random.Range(0, 6);
                z = Random.Range(0, 6);
            }

            Buffs temp;

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
            temp.name = "����������15%";
            mybuffs.Add(temp);



            temp = new Buffs();
            temp.sometext = "����";
            temp.name = "��������0.5��";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "����";
            temp.name = "��ɫ��ɵ������˺���Ϊԭ����2����ͬʱ�ܵ����˺���Ϊԭ����2��";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "����";
            temp.name = "�ƶ��ٶ����3�㣬ͬʱ�յ����˺���Ϊԭ����2��";
            mybuffs.Add(temp);


            buttons[0].GetComponentInChildren<Text>().text = "Buff: " + mybuffs[x].sometext + " - " + mybuffs[x].name;
            buttons[1].GetComponentInChildren<Text>().text = "Buff: " + mybuffs[y].sometext + " - " + mybuffs[y].name;
            buttons[2].GetComponentInChildren<Text>().text = "Buff: " + mybuffs[z].sometext + " - " + mybuffs[z].name;

        }
        else
        {
            Debug.Log("One or more buttons are not assigned. Please check the button assignments.");
        }
    }
    public void whenButton1()
    {
        change(x);
        loaddate(x);
        SceneManager.LoadScene(nextname);
    }
    public void whenButton2()
    {
        change(y);
        loaddate(y);
        SceneManager.LoadScene(nextname);
    }
    public void whenButton3()
    {
        change(z);
        loaddate(z);
        SceneManager.LoadScene(nextname);
    }


    public void change(int x)
    {
        switch (x)
        {
            case 0:
                damage = (float)(damage + 0.5);
                break;
            case 1:
                criticalStrikeRate += 20f;
                break;
            case 2:
                missRate += 15f;
                break;
            case 3:
                speed += 0.5f;
                break;
            case 4:
                damageMulti *= 2;
                hurtMulti *= 2;
                break;
            case 5:
                speed += 3f;
                hurtMulti *= 2;
                break;


            default:
                break;
        }
    }


    void getdata()
    {
        speed = PlayerPrefs.GetFloat("1", 0f);
        damage = PlayerPrefs.GetFloat("2", 0f);
        health = PlayerPrefs.GetFloat("3", 0f);
        maxHealth = PlayerPrefs.GetFloat("4", 0f);
        criticalStrikeRate = PlayerPrefs.GetFloat("5", 0f);
        missRate = PlayerPrefs.GetFloat("6", 0f);
        shield = PlayerPrefs.GetFloat("7", 0f);
        //��������
        getMoneyRate = PlayerPrefs.GetFloat("8", 0f);
        intShield = PlayerPrefs.GetFloat("9", 0f);
        inthurt = PlayerPrefs.GetFloat("10", 0f);
        monsterHealth = PlayerPrefs.GetFloat("11", 0f);
        monsterMissRate = PlayerPrefs.GetFloat("12", 0f);
        intMonsterShield = PlayerPrefs.GetFloat("13", 0f);

    }


    public void loaddate(int x)
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
        //��������
        PlayerPrefs.SetFloat("8", getMoneyRate);
        PlayerPrefs.SetFloat("9", intShield);
        PlayerPrefs.SetFloat("10", inthurt);
        PlayerPrefs.SetFloat("11", monsterHealth);
        PlayerPrefs.SetFloat("12", monsterMissRate);
        PlayerPrefs.SetFloat("13", intMonsterShield);


    }


}
