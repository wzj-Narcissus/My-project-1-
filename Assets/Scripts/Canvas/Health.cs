using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public PlayerManager PlayerManager;
    public GameObject Prefab0_5;
    public GameObject Prefab1_5;
    public GameObject Prefab2_5;
    public GameObject Prefab3_5;
    public GameObject Prefab4_5;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;
    public GameObject Prefab5;
    GameObject last;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerManager = GetComponent<PlayerManager>();
        //last=Instantiate(Prefab3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        last=Instantiate(Prefab3);
        spriteRenderer = last.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 2;
    }
    public void UpdateHp(int hp)
    {
        Destroy(last);
        switch (hp)
        {
            case 1:
                last = Instantiate(Prefab0_5);
                
                
                break;
            case 2:
                last = Instantiate(Prefab1);
                break;
            case 3:
                last = Instantiate(Prefab1_5);
                break;
            case 4:
                last = Instantiate(Prefab2);
                break;
            case 5:

                last = Instantiate(Prefab2_5);

                break;
            case 6:
                last = Instantiate(Prefab3);
                break;
            case 7:
                last = Instantiate(Prefab3_5);
                break;
            case 8:
                last = Instantiate(Prefab4);
                break;
            case 9:
                last = Instantiate(Prefab4_5);
                break;
            case 10:
                last = Instantiate(Prefab5);
                break;
        }
        spriteRenderer = last.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 2;
    }
}
