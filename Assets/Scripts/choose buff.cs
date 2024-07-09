using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseBuff : MonoBehaviour
{
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
    string nextname;

    void Start()
    {
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
            temp.sometext = "gongjili";
            temp.name = "Increase Attack";
            mybuffs.Add(temp);

            temp = new Buffs();
            temp.sometext = "fangyuli";
            temp.name = "Increase Defense";
            mybuffs.Add(temp);

            temp = new Buffs();
            temp.sometext = "shanbi";
            temp.name = "Dodge";
            mybuffs.Add(temp);
            temp = new Buffs();
            temp.sometext = "gongjili";
            temp.name = "Increase Attack";
            mybuffs.Add(temp);

            temp = new Buffs();
            temp.sometext = "fangyuli";
            temp.name = "Increase Defense";
            mybuffs.Add(temp);

            temp = new Buffs();
            temp.sometext = "shanbi";
            temp.name = "Dodge";
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

        SceneManager.LoadScene(nextname);
    }
    public void whenButton2()
    {
        SceneManager.LoadScene(nextname);
    }
    public void whenButton3()
    {
        SceneManager.LoadScene(nextname);
    }

}