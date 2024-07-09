using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBuff : MonoBehaviour
{

    //public GameObject player;
    //public PlayerManager manager;
    // Start is called before the first frame update
    void Start()
    {
        //manager= player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ebuff(ref List<PlayerManager.Buff> L,ref float damage,ref float speed,ref float criticalStrikeRate,ref float missRate,ref float shield,ref float maxHealth) 
    {
        for(int i = 0; i < L.Count; i++)
        {
            switch (L[i].num)
            {
                case 1:
                    damage += 0.5f;
                    break;
                case 2:
                    criticalStrikeRate += 25;
                    break;
                case 3:
                    missRate += 15;
                    break;
                case 4:
                    speed += 0.5f;
                    break;

                case 5:
                    maxHealth += 1;
                    break;
            }
        }
    }
}
