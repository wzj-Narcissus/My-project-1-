using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choosebuff22 : MonoBehaviour
{

    public float speed;//初始速度
    public float damage;//野猪初始攻击力
    public float health;//生命
    public float maxHealth;//最大生命
    public float criticalStrikeRate;//初始暴击率
    public float missRate;//初始闪避率
    public float shield;//护盾
    public float damageMulti = 1;//伤害倍率
    public float hurtMulti = 1;//受伤倍率


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
            temp.sometext = "攻击力";
            temp.name = "攻击增加0.5";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "暴击率";
            temp.name = "暴击率提升20%";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "闪避率";
            temp.name = "闪避率提升15%";
            mybuffs.Add(temp);



            temp = new Buffs();
            temp.sometext = "移速";
            temp.name = "移速提升0.5点";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "风险";
            temp.name = "角色造成的所有伤害变为原来的2倍，同时受到的伤害变为原来的2倍";
            mybuffs.Add(temp);


            temp = new Buffs();
            temp.sometext = "风险";
            temp.name = "移动速度提高3点，同时收到的伤害变为原来的2倍";
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
                criticalStrikeRate += 0.2f;
                break;
            case 2:
                missRate += 0.15f;
                break;
            case 3:
                speed += 0.5f;
                break;
            case 4:
                damageMulti += 1;
                hurtMulti += 1;
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
    }


    public void loaddate(int x)
    {
        PlayerPrefs.SetFloat("1", speed);
        PlayerPrefs.SetFloat("2", damage);
        PlayerPrefs.SetFloat("3", health);
        PlayerPrefs.SetFloat("4", maxHealth);
        PlayerPrefs.SetFloat("5", criticalStrikeRate);
        PlayerPrefs.SetFloat("6", missRate);
        PlayerPrefs.SetFloat("7", shield);


    }


}
