using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemytospawn;

    public float timetospawn;
    private float spawnCounter;
    private Vector2 spawnPos;
    public Transform minSpawn, maxSpawn;

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

            Instantiate(enemytospawn,Selectpoint(),transform.rotation);

        }
    }

    public Vector3 Selectpoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y=Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }




        return spawnPoint;
    }



}
