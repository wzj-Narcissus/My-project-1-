using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Updatehealth(int health,int maxHealth)
    {
        healthText.text ="Current Health:"+health.ToString()+"/"+maxHealth.ToString();
    }
}
