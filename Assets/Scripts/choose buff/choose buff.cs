using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseBuff : MonoBehaviour
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

            x = Random.Range(0, 8);
            y = Random.Range(0, 8);
            z = Random.Range(0, 8);

            while (x == y || y == z || z == x)
            {
                x = Random.Range(0, 8);
                y = Random.Range(0, 8);
                z = Random.Range(0, 8);
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
            temp.sometext = "��������";
            temp.name = "������������1�㣬���Ϊ5";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "����";
            temp.name = "��ɫ��ɵ������˺���Ϊԭ����2����ͬʱ�ܵ����˺���Ϊԭ����2��";
            mybuffs.Add(temp);

            temp = new Buffs();
            temp.sometext = "����";
            temp.name = "�յ����˺�����0.5�㣬ͬʱ��ɵ���ײ�˺�����0.5�㡢�ٶȼ���0.5�㣬����˺�����Ϊ0.5,�����˺����Ϊ0.5��";
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
        loaddate();
        SceneManager.LoadScene(nextname);
    }
    public void whenButton2()
    {
        change(y);
        loaddate();
        SceneManager.LoadScene(nextname);
    }
    public void whenButton3()
    {
        change(z);
        loaddate();
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
                maxHealth += 1f;
                health += 1f;
                break;
            case 5:
                damageMulti *= 2;
                hurtMulti *= 2;
                break;
            case 6:
                speed -= 0.5f;
                intShield = 0.5f;
                intMonsterShield = 0.5f;
                break;
            case 7:
                speed += 3f;
                hurtMulti *= 2;
                break;


            default:
                break;
        }
    }


    void getdata()
    {
        speed = PlayerPrefs.GetFloat("1",2f );
        damage = PlayerPrefs.GetFloat("2", 1f);
        health = PlayerPrefs.GetFloat("3", 3f);
        maxHealth = PlayerPrefs.GetFloat("4", 5f);
        criticalStrikeRate = PlayerPrefs.GetFloat("5", 5f);
        missRate = PlayerPrefs.GetFloat("6", 5f);
        shield = PlayerPrefs.GetFloat("7", 0f);
        damageMulti = PlayerPrefs.GetFloat("8", 1f);
        hurtMulti =PlayerPrefs.GetFloat("9", 1f);
        //��������
        getMoneyRate=PlayerPrefs.GetFloat("10", 60f);
        intShield = PlayerPrefs.GetFloat("11", 0f);
        inthurt= PlayerPrefs.GetFloat("12", 0f);
        monsterHealth= PlayerPrefs.GetFloat("13", 1f);
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
        PlayerPrefs.SetFloat("8",damageMulti);
        PlayerPrefs.SetFloat("9", hurtMulti);
        //��������
        PlayerPrefs.SetFloat("10",getMoneyRate);
        PlayerPrefs.SetFloat("11",intShield);
        PlayerPrefs.SetFloat("12",inthurt);
        PlayerPrefs.SetFloat("13",monsterHealth);
        PlayerPrefs.SetFloat("14",monsterMissRate);
        PlayerPrefs.SetFloat("15",intMonsterShield);


    }


}