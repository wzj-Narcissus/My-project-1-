using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giantattack : MonoBehaviour
{
    public GameObject hurtproject;
    public GameObject fly;
    public Transform minSpawn1, maxSpawn1;
    public Transform minSpawn2, maxSpawn2;
    public float beingtime1 ;
    public float beingtime2 ;
    public float attacktime1 ;
    public float attacktime2 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beingtime1 += Time.deltaTime;
        if (beingtime1>attacktime1)
        {
            Instantiate(hurtproject, Selectpoint(), transform.rotation);
            Instantiate(hurtproject, Selectpoint(), transform.rotation);
            Instantiate(hurtproject, Selectpoint(), transform.rotation);
            Instantiate(hurtproject, Selectpoint(), transform.rotation);

            beingtime1 = 0;
        }

        beingtime2 += Time.deltaTime;
        if(beingtime2 > attacktime2)
        {
            boom(maxSpawn2);
            beingtime2 = 0;
        }


    }


    public Vector2 Selectpoint()
    {
        Vector2 spawnPoint = Vector2.zero;

        spawnPoint.x=Random.Range(minSpawn1.position.x,maxSpawn1.position.x);
        spawnPoint.y=Random.Range(minSpawn1.position.y,maxSpawn1.position.y);

        return spawnPoint;
    }


    void boom(Transform _pos)
    {
        Vector2 temp = new Vector2();
        temp.x = _pos.position.x;
        temp.y = _pos.position.y;
        for (int i = 0; i < 20; i++)
        {

            GameObject bullet = Instantiate(fly, temp, transform.rotation);
            Vector2 newDirection = new Vector2(0, -1); // 举例设置一个新的飞行方向
            bullet.GetComponent<bullet>().SetDirection(newDirection);
            temp.x -=2;
        }

    }
}
