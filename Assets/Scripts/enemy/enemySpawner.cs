using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemytospawn;

    public float timetospawn;
    private float spawnCounter;
    private Vector2 spawnPos;

     // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timetospawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos=new Vector2(Random.Range(10, 20), Random.Range(10, 20));
         spawnCounter -= Time.deltaTime;
        if(spawnCounter <=0)
        {
            spawnCounter = timetospawn;

            Instantiate(enemytospawn,spawnPos,transform.rotation);

        }
    }
}
