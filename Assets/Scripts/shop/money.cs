using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class money : MonoBehaviour
{


    public string nextname;
    public Button _button;
    shop shop;
    // Start is called before the first frame update
    public int newmoney;
    void Start()
    {
        _button = GameObject.Find("Hp").GetComponent<Button>();
        shop = GameObject.FindGameObjectWithTag("shop").GetComponent<shop>();
        newmoney = PlayerPrefs.GetInt("16", 0);
    }

    // Update is called once per frame
    void Update()
    {
        newmoney = shop.money;
        _button.GetComponentInChildren<Text>().text = newmoney.ToString();


    }


}
