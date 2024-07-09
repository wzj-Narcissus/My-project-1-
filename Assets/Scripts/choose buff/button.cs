using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public struct Buffs
{
    public string sometext;
    public string name;
}
public class butter : MonoBehaviour 
{

    public Text text, buffname;
    
    // Start is called before the first frame update
    public void updatebuttondisplay(Buffs thebuff)
    {
        text.text = thebuff.sometext;
        buffname.text = thebuff.name;

    }

    // Update is called once per frame

}
