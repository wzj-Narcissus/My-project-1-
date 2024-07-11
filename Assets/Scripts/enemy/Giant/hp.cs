using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hp : MonoBehaviour
{


    public string nextname;
    public Button _button;
    // Start is called before the first frame update
    Giant Giant;
    public int newhp;
    void Start()
    {
        _button = GameObject.Find("Hp").GetComponent<Button>();
        Giant = GameObject.Find("Giant").GetComponent<Giant>();
        newhp = (int)Giant.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        newhp = (int)Giant.Hp;
        _button.GetComponentInChildren<Text>().text = "hp:"+newhp.ToString();


    }


}
